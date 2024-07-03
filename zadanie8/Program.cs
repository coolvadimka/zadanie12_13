var vodka = new Vodka("Talka", 300);
var pivo = new Pivo("Essa", 70);

var cl1 = new MyClass<Vodka>(vodka);
var cl2 = new MyClass<Vodka>(pivo);

cl1.PrintName();
cl2.PrintName();
class Vodka
{
    public string Name { get; set; }
    public int Price {  get; set; }
    public Vodka(string name, int price)
    {
        Name = name;
        Price = price;
    }
}
class Pivo : Vodka
{
    public Pivo(string name, int price) : base(name, price) { }
}
class MyClass<T> where T : Vodka
{
    private T Value;
    public MyClass(T value)
    {
        Value = value;
    }
    public void PrintName()
    {
        Console.WriteLine(Value.GetType());
    }
}