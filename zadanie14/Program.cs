using zadanie14;

class Program
{
    static void Main()
    {
        var context = new MyDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var Vadim = new Student() { Name = "Vadim"};
        var Nikita = new Student() { Name = "Nikita" };

        var ocenka1 = new Ocenka() { Ball = 54, Student = Nikita};
        var ocenka2 = new Ocenka() { Ball = 25, Student = Vadim};

        context.Students.AddRange(Vadim, Nikita);
        context.Marks.AddRange(ocenka1, ocenka2);

        context.SaveChanges();

        var marks = context.Marks.ToList();
        foreach( var mark in marks)
        {
            Console.WriteLine($"{mark.Id}, {mark.StudentId}, {mark.Ball}");
        }
    }
}