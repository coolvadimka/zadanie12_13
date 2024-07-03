bool flag = false;
object locker = new object();
ThreadPool.QueueUserWorkItem(_ => {
    Enter();
});
while (true)
{
    var knopka = Console.ReadKey();
    if(knopka.Key == ConsoleKey.Enter)
    {
        lock(locker)
        {
            flag = true;
            Monitor.Pulse(locker);

        }
    }
}
void Enter()
{
    while (true)
    {
        lock (locker)
        {
            while (!flag)
            {
                Monitor.Wait(locker);
            }
            flag = false;
        }
        Console.WriteLine("Enter\n");

    }
}