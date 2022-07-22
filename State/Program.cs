namespace State; // Vəziyyət


class Television
{
    public IState State { get; set; }

    public Television()
    {
        State = new OffState();
    }

    public void PressToggleButton() => State.Do(this);
}



interface IState
{
    void Do(Television tv);
}

class OffState : IState
{
    public void Do(Television tv)
    {
        Console.WriteLine("Televizor achildi");
        tv.State = new OnState();
    }
}

class OnState : IState
{
    public void Do(Television tv)
    {
        Console.WriteLine("Televizor baglandi");
        tv.State = new OffState();
    }
}



class Program
{
    static void Main()
    {
        Television tv = new Television();

        tv.PressToggleButton();
        tv.PressToggleButton();
        tv.PressToggleButton();
        tv.PressToggleButton();
    }
}