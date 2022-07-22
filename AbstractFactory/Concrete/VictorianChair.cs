using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class VictorianChair : IChair
{
    public bool HasLegs { get; set; }

    public VictorianChair()
    {
        Console.WriteLine("Victorian Chair");
    }

    public void SitOn()
        => throw new NotImplementedException();
}
