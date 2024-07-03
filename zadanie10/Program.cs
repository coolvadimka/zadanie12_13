interface MyInterface
{
    public void Hello();
    public void KakDela();
    public void Poka();
}
class Vadim : MyInterface
{
    public void Hello()
    {
        Console.WriteLine("Привет, меня зовут Вадим!");
    }
    public void KakDela()
    {
        Console.WriteLine("У меня все отлично)");
    }
    public void Poka()
    {
        Console.WriteLine("Мне пора идти, пока!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        MyInterface myInterface = new Vadim();
        myInterface.Hello();
        myInterface.KakDela();
        myInterface.Poka();
    }
}