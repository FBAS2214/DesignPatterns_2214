namespace Mediator;


// Also known as: Intermediary, Controller - Vasitəçi, Nəzarətçi

interface ICenter
{
    void AddAirplane(Airplane airplane);
    void LandingPermission(Airplane airplane);
    void TakeOffPermission(Airplane airplane);
}


class Center : ICenter
{
    private List<Airplane> _airplanes = new();

    public void AddAirplane(Airplane airplane)
    {
        _airplanes.Add(airplane);
    }

    public void LandingPermission(Airplane airplane)
    {
        for (int i = 0; i < _airplanes.Count; i++)
        {
            Airplane next = _airplanes[i];

            if (next.GetType() != airplane.GetType())
            {
                airplane.HandleMessage(next, "Eniş icazesi");
            }
        }
    }

    public void TakeOffPermission(Airplane airplane)
    {
        for (int i = 0; i < _airplanes.Count; i++)
        {
            Airplane next = _airplanes[i];

            if (next.GetType() != airplane.GetType())
            {
                airplane.HandleMessage(next, "Uçuş icazesi");
            }
        }
    }
}







abstract class Airplane
{
    public string? Code { get; set; }


    private readonly ICenter _center;
    public ICenter Center => _center;


    protected Airplane(ICenter center)
    {
        _center = center;
    }

    public virtual void HandleMessage(Airplane airplane, string message)
    {
        Console.WriteLine($"{Code} kodlu teyyareden {airplane.Code} kodlu teyyareye : {message}");
    }

    public abstract void LandingPermission();
    public abstract void TakeOffPermission();
}


class AHY : Airplane
{
    public AHY(ICenter center, string code) : base(center)
    {
        Code = "AHY " + code;
    }

    public override void LandingPermission()
    {
        Center.LandingPermission(this);
    }

    public override void TakeOffPermission()
    {
        Center.TakeOffPermission(this);
    }
}


class Buta : Airplane
{
    public Buta(ICenter center, string code) : base(center)
    {
        Code = "Buta " + code;
    }

    public override void LandingPermission()
    {
        Center.LandingPermission(this);
    }

    public override void TakeOffPermission()
    {
        Center.TakeOffPermission(this);
    }
}







class Program
{
    static void Main()
    {
        ICenter center = new Center();

        AHY ahy1 = new AHY(center, "A-123");
        AHY ahy2 = new AHY(center, "A-957");
        Buta buta1 = new Buta(center, "B-542");
        Buta buta2 = new Buta(center, "B-781");

        center.AddAirplane(ahy1);
        center.AddAirplane(ahy2);
        center.AddAirplane(buta1);
        center.AddAirplane(buta2);



        ahy1.LandingPermission();
        buta1.TakeOffPermission();

        buta2.LandingPermission();
        ahy2.TakeOffPermission();
    }
}