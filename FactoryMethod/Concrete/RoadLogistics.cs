using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete;

class RoadLogistics : Logistics
{
    public override ITransport CreateTransport() => new Truck();
}
