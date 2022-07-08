namespace AbstractFactory;

class VictorianCoffeTable : ICoffeTable
{
    public bool HasLegs { get; set; }
    public bool HasGrow { get; set; }

    public VictorianCoffeTable()
    {
        Console.WriteLine("Victorian CoffeTable");
    }
}
