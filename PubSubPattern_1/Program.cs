using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class OrderEventArgs
{
    public int OrderID { get; }
    public double TotalPrice { get; }
    public string CostumerName { get; }

    public OrderEventArgs(int orderID, double totalPrice, string costumerName)
    {
        this.OrderID = orderID;
        this.TotalPrice = totalPrice;
        this.CostumerName = costumerName;
   }

}

public class EventBus
{
    public readonly Dictionary<string, List<Action<OrderEventArgs>>> _subscribers
        = new Dictionary <string,List<Action<OrderEventArgs>>>();

    public void Subscribe(string topic, Action<OrderEventArgs> handler)
    {
        if (!_subscribers.ContainsKey(topic))
        {
            _subscribers[topic] = new List<Action<OrderEventArgs>>();
        }
        _subscribers[topic].Add(handler);
    }

    public void Publish(string topic, OrderEventArgs eventArgs)
    {
        if (_subscribers.ContainsKey(topic))
        {
            foreach (var handler in _subscribers[topic])
            {
                handler(eventArgs);
            }
        }
    }

    }

    public class Order
     {
       private readonly EventBus _Bus;
       public Order(EventBus bus) => _Bus = bus;

    public void OnCreateOrder(int id , double totalPrice, string customerName)
    {
        var eventArgs = new OrderEventArgs(id, totalPrice, customerName);
        _Bus.Publish("OnOrderCreated", eventArgs);
            
    }

     }

public class Email
{
   
    public Email(EventBus bus) => bus.Subscribe("OnOrderCreated", SendEmail);

    public void SendEmail(OrderEventArgs e)
    {
        Console.WriteLine("------- Email --------");
        Console.WriteLine($"Order id : {e.OrderID}");
        Console.WriteLine($"total price : {e.TotalPrice}");
        Console.WriteLine("----------------------");
    }
}
    public class Shipping{
        
     public Shipping(EventBus bus) => bus.Subscribe("OnOrderCreated",SendShipping);

        public void SendShipping(OrderEventArgs e)
        {
            Console.WriteLine("-------- Shipping -------");
            Console.WriteLine($"Order ID : {e.OrderID}");
            Console.WriteLine($"Customer Name : {e.CostumerName}" );
            Console.WriteLine("------------------");
        }

    }


namespace PubSubPattern_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();
            var email = new Email(eventBus);
            var shipping = new Shipping(eventBus);

            var order = new Order(eventBus);
            order.OnCreateOrder(3,66.99,"Abdenabi");
        }
    }
}
