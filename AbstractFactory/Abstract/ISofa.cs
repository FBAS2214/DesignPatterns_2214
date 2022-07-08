namespace AbstractFactory;

interface ISofa
{
    bool HasCorner { get; set; }
    bool CanOpen { get; set; }

    void SitOn();
}
