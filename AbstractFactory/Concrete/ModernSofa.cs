using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class ModernSofa : ISofa
{
    public bool HasCorner { get; set; }
    public bool CanOpen { get; set; }

    public ModernSofa()
    {
        Console.WriteLine("Modern Sofa");
    }

    public void SitOn()
        => throw new NotImplementedException();
}
