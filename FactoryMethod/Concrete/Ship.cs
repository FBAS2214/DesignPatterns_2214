using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete;

class Ship : ITransport
{
    public void Deliver()
        => Console.WriteLine("Deliver by sea in a container");
}
