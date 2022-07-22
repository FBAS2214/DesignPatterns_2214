using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class VictorianSofa : ISofa
{
    public bool HasCorner { get; set; }
    public bool CanOpen { get; set; }

    public VictorianSofa()
    {
        Console.WriteLine("Victorian Sofa");
    }

    public void SitOn()
        => throw new NotImplementedException();
}
