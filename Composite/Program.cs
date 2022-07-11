namespace Composite;



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




// C:\
// C:\Program Files
// C:\Program Files\Adobe
// C:\Program Files\Microsoft
// C:\Users