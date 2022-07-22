namespace AbstractFactory.Abstract;

interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeTable CreateCoffeTable();
}
