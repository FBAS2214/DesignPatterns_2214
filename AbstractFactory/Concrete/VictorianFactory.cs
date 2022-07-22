using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class VictorianFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ICoffeTable CreateCoffeTable()
    {
        return new VictorianCoffeTable();
    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }
}
