namespace AbstractFactory.Abstract;

interface ISofa
{
    bool HasCorner { get; set; }
    bool CanOpen { get; set; }

    void SitOn();
}
