using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete;

class Plane : ITransport
{
    public void Deliver()
        => Console.WriteLine("Deliver by air in a container");
}
