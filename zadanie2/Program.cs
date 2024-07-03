class MyClass
{
    private void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void CallPrivateMethod(string message)
    {
        ShowMessage(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass myObject = new MyClass();
        myObject.CallPrivateMethod("OOOOO");
    }
}
