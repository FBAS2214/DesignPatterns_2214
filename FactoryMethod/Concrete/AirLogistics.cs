using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete;

class AirLogistics : Logistics
{
    public override ITransport CreateTransport() => new Plane();
}
