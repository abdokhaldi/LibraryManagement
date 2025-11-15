using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriberDesignPattern
{
    public class NewsArticle 
    {
        public string title { get; }
        public string description { get; }

        public NewsArticle(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
    public class Publisher
    {
        public event EventHandler<NewsArticle> OnNewsPublished;

        protected virtual void onNewsPublished(NewsArticle Article)
        {
            OnNewsPublished?.Invoke(this,Article);
        }
        public void onNewsPublished(string title, string description)
        {
            var Article = new NewsArticle(title, description);
            onNewsPublished(Article);
        }
    }

    public class Subscriber
    {
       private string name { get; }
       public Subscriber(string name)
        {
            this.name = name;
        }
       public void subscribe(Publisher publisher)
        {
            publisher.OnNewsPublished += desplayNews;
        }
        public void unsubscribe(Publisher publisher)
        {
            publisher.OnNewsPublished -= desplayNews;
        }

        private void desplayNews(object sender,NewsArticle Article)
        {
            Console.WriteLine($"Dear subscriber {name} there is new articles published now .");
            Console.WriteLine($"Title : {Article.title}");
            Console.WriteLine($"Description : {Article.description}");
            Console.WriteLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();
            var subscriber1 = new Subscriber("Subsciber1");
            subscriber1.subscribe(publisher);

            var subscriber2 = new Subscriber("Subsciber2");
            subscriber2.subscribe(publisher);

            var subscriber3 = new Subscriber("Subsciber3");
            subscriber3.subscribe(publisher);

            subscriber2.unsubscribe(publisher);
            publisher.onNewsPublished("Gaza under fire","3 childreen dead in gaza this morning");            
                        
        
        }
    }
}
