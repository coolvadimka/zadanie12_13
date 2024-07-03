using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static readonly object lockObject = new object();
    static Random random = new Random();
    static long[] waitTimes = new long[10];
    static int Colvo = 0;

    static void Main()
    {
        Task[] task = new Task[10];
        int X = random.Next(0, 1001);

        for (int i = 0; i < 10; i++)
        {
            int taskIndex = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                lock (lockObject)
                {
                    stopwatch.Stop();
                    waitTimes[taskIndex] = stopwatch.ElapsedTicks;

                    int[] array = GenerateAndSortArray();

                    int count = array.Count(n => n == X);

                    Console.WriteLine($"Task {taskIndex + 1}: Found {count} elements equal to {X}");

                    Colvo++;

                    Monitor.Pulse(lockObject);
                }
            });
        }

        lock(lockObject)
        {
            while(Colvo < 10)
            {
                Monitor.Wait(lockObject);
            }
        }

        long minWait = waitTimes.Where(t => t > 0).Min();
        long maxWait = waitTimes.Max();
        double averageWait = waitTimes.Where(t => t > 0).Average();

        Console.WriteLine($"Min: {minWait} ticks");
        Console.WriteLine($"Max: {maxWait} ticks");
        Console.WriteLine($"Average: {averageWait} ticks");
    }
    static int[] GenerateAndSortArray()
    {
        int arraySize = random.Next(10_000_000, 15_000_001);
        int[] array = new int[arraySize];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 1001);
        }

        Array.Sort(array);

        return array;
    }
}
