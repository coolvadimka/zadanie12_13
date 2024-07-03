using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using zadanie12_13;

class Program
{
    static void Main(string[] args)
    {
        var context = new MyDB();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        for(int i = 0; i < 1000000; i++)
        {
            string name = "vadim" + i.ToString();
            var temp = new TableEntity() { Name = name };
            context.Add(temp);
        }
        context.SaveChanges();
        SearchTimes(context);
        //var Vadim = new TableEntity() { Name = "Vadim" };
        //context.Add(Vadim);
        //context.SaveChanges();
        //Console.WriteLine($"{Vadim.Id}, {Vadim.Name}");
    }
    static void SearchTimes(MyDB context)
    {
        Random random = new Random();
        var timer1 = new Stopwatch();
        Console.WriteLine("Поиск по ключу");
        timer1.Start();
        for(int i = 0; i < 1000; i++)
        {
            int id = random.Next(1_000_000);
            var item = context.Tables.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"Запись с ключём {item.Id} найдена");
        }
        timer1.Stop();

        var timer2 = new Stopwatch();
        Console.WriteLine("Поиск по значению");
        timer2.Start();
        for (int i = 0; i < 1000; i++)
        {
            string name = "vadim" + random.Next(1_000_000).ToString();
            var item = context.Tables.FirstOrDefault(x => x.Name == name);
            Console.WriteLine($"Запись с ключём {item.Name} найдена");
        }
        timer2.Stop();

        Console.WriteLine($"Среднее время поиска по ключу:{timer1.Elapsed.TotalSeconds} сек");
        Console.WriteLine($"Среднее время поиска по имени:{timer2.Elapsed.TotalSeconds} сек");
    }
}
