using FactoryMethod.Abstract;
using FactoryMethod.Concrete;

namespace FactoryMethod;


class Program
{
    static void Main()
    {
        // Logistics logistics = new AirLogistics();
        // ITransport transport = logistics.CreateTransport();
        // transport.Deliver();






        Logistics? logistics = null;
        ITransport? transport = null;

        while (true)
        {
            Console.WriteLine(@"
                                1: Road
                                2: Sea
                                3: Air
                                Any: Exit");

            Console.Write("\n\tEnter choice: ");


            logistics = Console.ReadLine() switch
            {
                "1" => new RoadLogistics(),
                "2" => new SeaLogistics(),
                "3" => new AirLogistics(),
                _ => null
            };

            if (logistics == null)
                break;


            transport = logistics?.CreateTransport();
            transport?.Deliver();
        }
    }
}
