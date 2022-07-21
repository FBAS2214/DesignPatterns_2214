namespace Observer;

public interface IObserver
{
    string Fullname { get; set; }
    void Update(bool isAvailable);
}

public class CustomerObserver : IObserver
{
    public string Fullname { get; set; }

    public void Update(bool isAvailable)
    {
        if (isAvailable)
            Console.WriteLine($"Hi, {Fullname}, your looking forward product is now available on our store");
    }

    public CustomerObserver(string fullname, ISubject subject)
    {
        Fullname = fullname;
        subject.AddSubscriber(this);
    }
}

public interface ISubject
{
    void AddSubscriber(IObserver observer);
    void RemoveSubscriber(IObserver observer);
    void NotifySubscribers();
}


public class Store : ISubject
{
    private List<IObserver> _subscribers = new();
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }

    private bool _isAvailable;

    public bool IsAvailable
    {
        get { return _isAvailable; }
        set
        {
            _isAvailable = value;
            if (value)
            {
                Console.WriteLine("Product availability changed!!! It's IN STOCK.");
                NotifySubscribers();
            }
            else
                Console.WriteLine("The product currently is not available .");
        }
    }


    public Store(string productName, double productPrice, bool isAvailable)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        IsAvailable = isAvailable;
    }


    public void AddSubscriber(IObserver subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine($"New subscriber is added: {subscriber.Fullname}");
    }

    public void RemoveSubscriber(IObserver subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers()
    {
        Console.WriteLine($"Product details: {ProductName}, Price: {ProductPrice}\n\n");
        foreach (IObserver subscriber in _subscribers)
        {
            subscriber.Update(IsAvailable);
        }
    }

  
}


class Program
{
    static void Main()
    {
        Store product = new("Iphone 14", 3100, false);

        new CustomerObserver("Leyla Gocayeva", product);
        new CustomerObserver("Nihat Rustamli", product);
        new CustomerObserver("Kenan Nebizade", product);
        new CustomerObserver("Ferman Esedov", product);
        IObserver customer5 = new CustomerObserver("Elgun Salmanov", product);

        Console.WriteLine("\n\n");

        product.RemoveSubscriber(customer5);

        product.IsAvailable = true;
    }
}