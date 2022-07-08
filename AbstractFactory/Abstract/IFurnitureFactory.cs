namespace AbstractFactory;

interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeTable CreateCoffeTable();
}
