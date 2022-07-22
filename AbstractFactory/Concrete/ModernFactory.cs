using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete;

class ModernFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ICoffeTable CreateCoffeTable()
    {
        return new ModernCoffeTable();
    }

    public ISofa CreateSofa()
    {
        return new ModernSofa();
    }
}
