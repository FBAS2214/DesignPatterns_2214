namespace Singleton;


/*
class President
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public float Height { get; set; }

    private static President? _instance = null;

    private President()
    {
        Name = "XXX";
        Surname = "XXXXX";
        Height = 195;
    }


    public static President GetInstance()
    {
        if (_instance == null)
            _instance = new President();

        return _instance;
    }
}
*/





// Thread Safe Singleton (with Property)
// Double Check


class President
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public float Height { get; set; }

    public static object _lock = new object();
    
    private static President? _instance = null;

    private President()
    {
        Name = "XXX";
        Surname = "XXXXX";
        Height = 195;
    }


    public static President Instance
    {
        get
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                        _instance = new President();

            return _instance; 
        }
    }
}



class Program
{
    static void Main()
    {
        President president1 = President.Instance;
        President president2 = President.Instance;

        Console.WriteLine(president1 == president2);
    }
}
