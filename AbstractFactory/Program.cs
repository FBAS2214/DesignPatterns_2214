using AbstractFactory.Abstract;

namespace AbstractFactory;


class Program
{
    static void Main()
    {
        IFurnitureFactory factory = new ModernFactory();

        IChair chair = factory.CreateChair();
        ISofa sofa = factory.CreateSofa();
        ICoffeTable coffeTable = factory.CreateCoffeTable();

    }
}