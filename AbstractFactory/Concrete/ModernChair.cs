using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class ModernChair : IChair
{
    public bool HasLegs { get; set; }

    public ModernChair()
    {
        Console.WriteLine("Modern Chair");
    }

    public void SitOn()
        => throw new NotImplementedException();
}
