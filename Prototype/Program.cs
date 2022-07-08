namespace Prototype;



// NOTE: Copy Constructor
// NOTE: Deep Copy and Shallow Copy


/*
class Car : ICloneable
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }

    public Car(string? make, string? model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }


    public object Clone()
    {
        // return new Car(Make, Model, Year);
        return MemberwiseClone();
    }
}
*/








interface IPrototype
{
    IPrototype? Clone();
}


struct Car : IPrototype
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }

    public Car(string? make, string? model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }


    public IPrototype? Clone()
    {
        return new Car(Make, Model, Year);
        // return MemberwiseClone() as IPrototype;
    }
}





class Program
{
    static void Main()
    {
        Car car = new Car("Kia", "Cerato", 2013);
        Car? carCopy = car.Clone() as Car?;

        car.Model = "Optima";

        Console.WriteLine(car.Model);
        Console.WriteLine(carCopy?.Model);
    }
}