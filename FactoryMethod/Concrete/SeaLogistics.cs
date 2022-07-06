using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete;

class SeaLogistics : Logistics
{
    public override ITransport CreateTransport() => new Ship();
}
