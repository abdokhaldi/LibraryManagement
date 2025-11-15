using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderEventArgs : EventArgs
{
    public int OrderID { get; }
    public string CostumerName { get; }
    public double OrderTotalPrice { get; }

    public OrderEventArgs(int orderID, string costumerName, double orderTotalPrice)
    {
        this.OrderID = orderID;
        this.OrderTotalPrice = orderTotalPrice;
        this.CostumerName = costumerName; ;
    }
}

public class Order
{

    public event EventHandler<OrderEventArgs> OnMessageOrder;

    protected virtual void onMessageOrder(OrderEventArgs e)
    {
        OnMessageOrder?.Invoke(this,e);
    }

    public void onMessageOrder(int orderID,string costumerName, double orderTotalPrice)
    {
        var orderEvent = new OrderEventArgs(orderID, costumerName, orderTotalPrice);
        onMessageOrder(orderEvent);
    }
}

public class Email
{
    public void Subscribe(Order order)
    {
        order.OnMessageOrder += displayEmail;
    }

    public void UnSubscribe(Order order)
    {
        order.OnMessageOrder -= displayEmail;
    }
    public void displayEmail(object sender, OrderEventArgs e)
    {
        Console.WriteLine("--------Email---------");
        Console.WriteLine($"Order ID : {e.OrderID}");
        Console.WriteLine($"Costumer Name : {e.CostumerName}");
        Console.WriteLine($"Order Total Price : {e.OrderTotalPrice}");
        Console.WriteLine("----------------------");
    }
}

public class SMS
{
    public void Subscribe(Order order)
    {
        order.OnMessageOrder += displaySMS;
    }
    public void UnSubscribe(Order order)
    {
        order.OnMessageOrder -= displaySMS;
    }

    public void displaySMS(object sender, OrderEventArgs e)
    {
        Console.WriteLine("--------SMS---------");
        Console.WriteLine($"Order ID : {e.OrderID}");
        Console.WriteLine($"Costumer Name : {e.CostumerName}");
        Console.WriteLine($"Order Total Price : {e.OrderTotalPrice}");
        Console.WriteLine("----------------------");
    }
}


public class Shipping
{
    public void Subscribe(Order order)
    {
        order.OnMessageOrder += displayShipping;
    }
    public void UnSubscribe(Order order)
    {
        order.OnMessageOrder += displayShipping;
    }

    public void displayShipping(object sender, OrderEventArgs e)
    {
        Console.WriteLine("--------Shipping---------");
        Console.WriteLine($"Order ID : {e.OrderID}");
        Console.WriteLine($"Costumer Name : {e.CostumerName}");
        Console.WriteLine($"Order Total Price : {e.OrderTotalPrice}");
        Console.WriteLine("----------------------");
    }
}




namespace NewOrderEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            var sms = new SMS();
            var shipping = new Shipping();
            var email = new Email();
            sms.Subscribe(order);
            email.Subscribe(order);
            shipping.Subscribe(order);
            email.UnSubscribe(order);
            order.onMessageOrder(1,"Adil",99.33);
        }
    }
}
