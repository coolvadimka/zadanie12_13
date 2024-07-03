var temp = new MyClass<object>();
temp.PrintType();
class MyClass<T>
{
    public void PrintType()
    {
        Console.WriteLine(typeof(T).Name);
    }
}