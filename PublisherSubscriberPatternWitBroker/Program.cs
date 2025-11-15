using System;
using System.Collections.Generic;


namespace PublisherSubscriberPatternWitBroker
{
    // Event Data
    public class OrderEventArgs : EventArgs
    {
        public int OrderID { get; }
        public string CustomerName { get; }
        public double TotalPrice { get; }

        public OrderEventArgs(int orderID, string customerName, double totalPrice)
        {
            OrderID = orderID;
            CustomerName = customerName;
            TotalPrice = totalPrice;
        }
    }

    // Broker (Event Bus)
    public class EventBus
    {
        private readonly Dictionary<string, List<Action<OrderEventArgs>>> _subscribers
            = new Dictionary<string, List<Action<OrderEventArgs>>>();

        // Subscribe
        public void Subscribe(string topic, Action<OrderEventArgs> handler)
        {
            if (!_subscribers.ContainsKey(topic))
                _subscribers[topic] = new List<Action<OrderEventArgs>>();

            _subscribers[topic].Add(handler);
        }

        // Publish
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

    // Publisher
    public class Order
    {
        private readonly EventBus _bus;
        public Order(EventBus bus) => _bus = bus;

        public void CreateOrder(int id, string customer, double price)
        {
            var orderEvent = new OrderEventArgs(id, customer, price);
            _bus.Publish("OrderCreated", orderEvent); // ينشر الحدث عبر الـ Broker
        }
    }

    // Subscribers
    public class Email
    {
        public Email(EventBus bus)
        {
            bus.Subscribe("OrderCreated", DisplayEmail);
        }

        private void DisplayEmail(OrderEventArgs e)
        {
            Console.WriteLine("---- Email ----");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Customer: {e.CustomerName}");
            Console.WriteLine($"Total: {e.TotalPrice}");
        }
    }

    public class SMS
    {
        public SMS(EventBus bus)
        {
            bus.Subscribe("OrderCreated", DisplaySMS);
        }

        private void DisplaySMS(OrderEventArgs e)
        {
            Console.WriteLine("---- SMS ----");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Customer: {e.CustomerName}");
            Console.WriteLine($"Total: {e.TotalPrice}");
        }
    }

    public class Shipping
    {
        public Shipping(EventBus bus)
        {
            bus.Subscribe("OrderCreated", DisplayShipping);
        }

        private void DisplayShipping(OrderEventArgs e)
        {
            Console.WriteLine("---- Shipping ----");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Customer: {e.CustomerName}");
            Console.WriteLine($"Total: {e.TotalPrice}");
        }
    }

    // Program
    class Program
    {
        static void Main() 
        {
            var bus = new EventBus();   // الوسيط (Broker)
            var email = new Email(bus); // كل Subscriber يسجل نفسه عند الـ Broker
            var sms = new SMS(bus);
            var shipping = new Shipping(bus);

            var order = new Order(bus); // Publisher يمرر الـ Broker
            order.CreateOrder(1, "Adil", 99.33);
        }
    }

    
}
