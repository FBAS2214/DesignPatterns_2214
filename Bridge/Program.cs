namespace Bridge;


interface IDevice
{
    bool IsEnabled { get; }

    int Volume { get; set; }
    int Channel { get; set; }

    void Enable();
    void Disable();
}


class TV : IDevice
{
    public bool IsEnabled { get; private set; }
    public int Volume { get; set; }
    public int Channel { get; set; }


    public void Enable()
        => IsEnabled = true;
    public void Disable()
        => IsEnabled = false;
}

class Radio : IDevice
{
    public bool IsEnabled { get; private set; }
    public int Volume { get; set; }
    public int Channel { get; set; }


    public void Enable()
        => IsEnabled = true;
    public void Disable()
        => IsEnabled = false;
}




class RemoteControl
{
    protected IDevice? _device;

    public RemoteControl(IDevice? device)
    {
        _device = device;
    }

    public void TogglePower()
    {
        if (_device?.IsEnabled ?? false)
            _device.Disable();
        else
            _device?.Enable();
    }

    public void VolumeDown()
    {
        if (_device is not null)
            _device.Volume--;
    }

    public void VolumeUp()
    {
        if (_device is not null)
            _device.Volume++;
    }


    public void ChannelDown()
    {
        if (_device is not null)
            _device.Channel--;
    }

    public void ChannelUp()
    {
        if (_device is not null)
            _device.Channel++;
    }

}



class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice? device)
        : base(device) { }


    public void Mute()
    {
        if (_device is not null)
            _device.Volume = 0;
    }

}


class Program
{
    static void Main()
    {
        IDevice device = new TV();
        var remote = new AdvancedRemoteControl(device);


        remote.TogglePower();
        remote.VolumeUp();
        remote.ChannelUp();


        // remote.Mute();


        Console.WriteLine(device.IsEnabled);
        Console.WriteLine(device.Volume);
        Console.WriteLine(device.Channel);


        remote.ChannelDown();
        remote.VolumeDown();
        remote.TogglePower();
    }
}
















/*
interface IColor
{
    string? Name { get; set; }
    float Opacity { get; set; }

    void FromRGB(int r, int g, int b);
}

class Red : IColor
{
    public string? Name { get; set; } = "Red";
    public float Opacity { get; set; } = 100f;
    public void FromRGB(int r, int g, int b)
    {
        Console.WriteLine($"FromRGB R:{r} G:{g} B:{b}");
    }
}

class Blue : IColor
{
    public string? Name { get; set; } = "Blue";
    public float Opacity { get; set; } = 99f;
    public void FromRGB(int r, int g, int b)
    {
        Console.WriteLine($"FromRGB R:{r} G:{g} B:{b}");
    }
}




abstract class Shape
{
    public IColor? Color { get; set; }

    public double Area { get; protected set; }
    public byte Corner { get; init; }
    public string? Name { get; set; }


    protected Shape(IColor? color, double area, byte corner, string? name)
    {
        Color = color;
        Area = area;
        Corner = corner;
        Name = name;
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(IColor color, double width, double height)
        : base(color, width * height, 4, nameof(Rectangle))
    {
        Width = width;
        Height = height;
    }

}

class Circle : Shape
{
    public double Radius { get; set; }


    public Circle(IColor color, double radius)
        : base(color, 3.14 * Math.Pow(radius, 2), 0, nameof(Circle))
    {
        Radius = radius;
    }
}



class Program
{
    static void Main()
    {
        IColor color = new Red();
        // color = new Blue();

        Shape shape = new Rectangle(color, 10, 7);
        shape = new Circle(color, 10);


        Console.WriteLine(shape.Name);
        Console.WriteLine(shape.Area);
        Console.WriteLine(shape.Corner);
        Console.WriteLine(shape.Color?.Name);
        Console.WriteLine(shape.Color?.Opacity);

        shape.Color?.FromRGB(22, 14, 22);
    }
}
*/