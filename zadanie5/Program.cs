MyClass naslednik = new MyClass();
naslednik.Paka();
naslednik.PrintName();
abstract class MyAbstract
{
    public virtual void PrintName()
    {
        Console.WriteLine("I'm abctact class!");
    }
    public abstract void Paka();
}
class MyClass : MyAbstract
{
    public override void PrintName()
    {
        Console.WriteLine("I'm class");
    }
    public override void Paka()
    {
        Console.WriteLine("25 ballov");
    }
}