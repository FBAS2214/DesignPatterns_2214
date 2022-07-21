namespace Memento; // Xatirə



// Also known as: Snapshot - Anlık görüntü

// Originator - Yaratıcı
// Memento - Xatirə
// Caretaker - Gözətçi





// Originator
class Coordinate
{
    private int _x;
    private int _y;

    public Coordinate(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void Increment()
    {
        _x++;
        _y++;
    }

    public override string ToString()
        => $"x: {_x},  y: {_y}";


    public void Setup(CoordinateMemento memento)
    {
        _x = memento.X;
        _y = memento.Y;
    }

    public CoordinateMemento BackUp()
        => new(_x, _y);
}






// Memento
class CoordinateMemento
{
    public int X { get; set; }
    public int Y { get; set; }

    public CoordinateMemento(int x, int y)
    {
        X = x;
        Y = y;
    }
}


// Caretaker
class CoordinateCaretaker
{
    private Stack<CoordinateMemento> _memento;


    public CoordinateCaretaker()
        => _memento = new();

    public CoordinateMemento Undo()
        => _memento.Pop();


    public void Save(CoordinateMemento memento)
        => _memento.Push(memento);
    
}





class Program
{
    static void Main()
    {
        CoordinateCaretaker caretaker = new();


        Coordinate coordinate = new Coordinate(15, 15);
        coordinate.Increment();
        Console.WriteLine(coordinate);



        caretaker.Save(coordinate.BackUp());


        coordinate.Increment();
        coordinate.Increment();
        coordinate.Increment();


        caretaker.Save(coordinate.BackUp());


        coordinate.Increment();
        coordinate.Increment();
        Console.WriteLine(coordinate);


        coordinate.Setup(caretaker.Undo());
        coordinate.Setup(caretaker.Undo());
        Console.WriteLine(coordinate);
    }
}