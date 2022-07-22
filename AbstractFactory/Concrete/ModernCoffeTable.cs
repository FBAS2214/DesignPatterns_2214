using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class ModernCoffeTable : ICoffeTable
{
    public bool HasLegs { get; set; }
    public bool HasGrow { get; set; }

    public ModernCoffeTable()
    {
        Console.WriteLine("Modern CoffeTable");
    }
}
