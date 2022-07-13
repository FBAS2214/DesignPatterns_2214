using System.Text;

namespace Decorator;


interface INotifier
{
    void Send(string message);
}

class Notifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Message sent with Email");
    }
}




abstract class BaseDecorator : INotifier
{
    protected INotifier _notifier;
    protected BaseDecorator(INotifier notifier)
        => _notifier = notifier;

    public virtual void Send(string message)
        => _notifier.Send(message);
}



class WhatsappDecorator: BaseDecorator
{
    public WhatsappDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Message sent with Whatsapp");
    }
}

class TelegramDecorator : BaseDecorator
{
    public TelegramDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Message sent with Telegram");
    }
}

class SmsDecorator : BaseDecorator
{
    public SmsDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Message sent with Sms");
    }
}




class Program
{
    static void Main()
    {
        INotifier notifier = new Notifier();
        
        notifier = new WhatsappDecorator(notifier);
        notifier = new SmsDecorator(notifier);
        notifier = new TelegramDecorator(notifier);

        
        notifier.Send("Discount 50%");
    }
}