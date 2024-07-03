Console.WriteLine("Введите размерность массива:");
int n = int.Parse(Console.ReadLine());
MyNaslednik[] mas1 = new MyNaslednik[n];
MyNaslednik[] mas2 = new MyNaslednik[n];
Random random = new Random();
for(int i = 0; i < n; i++)
{
    mas1[i] = new MyNaslednik("Father", random.Next(2) == 0);
    mas2[i] = new MyNaslednik("Son", random.Next(2) == 0);
}

int count1 = 0;
int count2 = 0;

foreach (var x in mas1)
{
    if (x.Flag == false)
    {
        count1++;
    }
}

foreach (var x in mas2)
{
    if (x.Flag == false)
    {
        count2++;
    }
}

Console.WriteLine($"Массив 1 содержит {count1} значений false.");
Console.WriteLine($"Массив 2 содержит {count2} значений false.");

if (count1 > count2)
{
    Console.WriteLine("Массив 1 содержит больше значений false.");
}
else if (count2 > count1)
{
    Console.WriteLine("Массив 2 содержит больше значений false.");
}
else
{
    Console.WriteLine("Оба массива содержат одинаковое количество значений false.");
}
class MyClass
{
    public string Name { get; set; }
    public bool Flag {  get; set; }
    public MyClass(string name, bool flag)
    {
        Name = name;
        Flag = flag;
    }
}
class MyNaslednik : MyClass
{
    public MyNaslednik(string name, bool flag) : base(name, flag) { }
}