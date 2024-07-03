using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyClass
{
    public int Year { get; set; }
    public string Name { get; set; }
    public MyClass(int n, string s)
    {
        Year = n;
        Name = s;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность: ");
        int n = int.Parse(Console.ReadLine());
        MyClass[] huesoss = new MyClass[n];
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            int nubm = random.Next(1, 1001);
            string text = "Vadim" + random.Next(1, 1001);
            huesoss[i] = new MyClass(nubm, text);
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1}. Количество лет: {huesoss[i].Year}, Имя: {huesoss[i].Name}");
        }
    }
}
