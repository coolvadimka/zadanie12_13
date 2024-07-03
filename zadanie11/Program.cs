
using static Program;

class Program
{
    static void Main(string[] args)
    {
        var Vadim = new Vadim();
        Vadim.Notify += PrintName;
        Vadim.PrintMessage("Меня зовут Вадим");
        Vadim.Notify -= PrintName;
        Vadim.PrintMessage("хаха");
    }
    static void PrintName(string name)
    {
        Console.WriteLine(name);
    }
}
class Vadim
{
    private Proverka? notify;
    public event Proverka Notify
    {
        add
        {
            notify += value;
            Console.WriteLine($"{value.Method.Name} добавлено");
        }
        remove
        {
            notify -= value;
            Console.WriteLine($"{value.Method.Name} удалено");
        }
    }
    public void PrintMessage(string message)
    {
        if(notify != null)
        {
            notify?.Invoke(message);
        }
        else
        {
            Console.WriteLine("Событие пустое");
        }
    }
}
delegate void Proverka(string name);