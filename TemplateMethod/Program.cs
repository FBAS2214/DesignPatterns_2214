namespace TemplateMethod;

abstract class SQLEngine
{
    public virtual void TemplateMethod()
    {
        Connect();
        ExecuteCommand();
        CloseConnection();
    }

    public abstract void Connect();
    public abstract void ExecuteCommand();
    public abstract void CloseConnection();

}


class MsSql : SQLEngine
{
    public override void CloseConnection()
    {
        Console.WriteLine("MsSql CloseConnection");
    }

    public override void Connect()
    {
        Console.WriteLine("MsSql Connect");
    }

    public override void ExecuteCommand()
    {
        Console.WriteLine("MsSql ExecuteCommand");
    }
}

class MySql : SQLEngine
{
    public override void CloseConnection()
    {
        Console.WriteLine("MySql CloseConnection");
    }

    public override void Connect()
    {
        Console.WriteLine("MySql Connect");
    }

    public override void ExecuteCommand()
    {
        Console.WriteLine("MySql ExecuteCommand");
    }
}



class Program
{
    static void Main()
    {
        SQLEngine sql = new MsSql();
        sql.TemplateMethod();

        sql = new MySql();
        sql.TemplateMethod();
    }
}