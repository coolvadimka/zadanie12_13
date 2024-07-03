var class1 = new MyClass() { Ch1 = 2, Ch2 = 3 };
var class2 = new MyClass() { Ch1 = 4, Ch2 = 5 };
var class3 = class1 + class2;
Console.WriteLine($"{class3.Ch1}, {class3.Ch2}");
class MyClass
{
    public int Ch1 { get; set; }
    public int Ch2 { get; set; }
    public static MyClass operator +(MyClass x, MyClass y)
    {
        return new MyClass() { Ch1 = x.Ch1 + y.Ch1, Ch2 = x.Ch2 + y.Ch2 };
    }
}