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