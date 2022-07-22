namespace Visitor;


interface IAccept
{
    void Accept(IMobileVisitor visitor);
}


class MobilePhone : IAccept
{
    public string Model { get; set; }

    public MobilePhone(string model)
    {
        Model = model;
    }

    public void Accept(IMobileVisitor visitor)
        => visitor.Visit(this);
}

class IphoneX : MobilePhone
{
    public IphoneX() : base("IphoneX") { }
}

class Mi8 : MobilePhone
{
    public Mi8() : base("Mi8") { }
}

class Nokia3310 : MobilePhone
{
    public Nokia3310() : base("Nokia3310") { }
}



interface IMobileVisitor
{
    void Visit(MobilePhone mobilePhone);
}

class PhotoVisitor : IMobileVisitor
{
    public void Visit(MobilePhone mobilePhone)
    {
        Console.WriteLine($"{mobilePhone.Model} telefonu ile shekil chekildi");
    }
}

class SnakeGameVisitor : IMobileVisitor
{
    public void Visit(MobilePhone mobilePhone)
    {
        Console.WriteLine($"{mobilePhone.Model} telefonu ile ilan oyunu oynanilir");
    }
}

class ZoomVisitor : IMobileVisitor
{
    public void Visit(MobilePhone mobilePhone)
    {
        Console.WriteLine($"{mobilePhone.Model} telefonu ile zoom edildi");
    }
}




class Program
{
    static void Main()
    {
        PhotoVisitor photoVisitor = new();
        SnakeGameVisitor snakeGameVisitor = new();
        ZoomVisitor zoomVisitor = new();




        IphoneX iphoneX = new();
        iphoneX.Accept(photoVisitor);
        iphoneX.Accept(zoomVisitor);



        Mi8 mi8 = new();
        mi8.Accept(photoVisitor);



        Nokia3310 nokia3310 = new();
        nokia3310.Accept(snakeGameVisitor);




        //  List<MobilePhone> phones = new()
        //  {
        //      new Mi8(),
        //      new Nokia3310(),
        //      new IphoneX()
        //  };
        //  
        //  
        //  
        //  foreach (var phone in phones)
        //      phone.Accept(photoVisitor);
    }

}
