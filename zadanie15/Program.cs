using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static Random random = new Random();
    static readonly object locker = new object();
    static int Colvo = 0;
    static void Main()
    {
        long[] executionTimes = new long[10];
        int X = random.Next(0, 1001);

        for (int i = 0; i < 10; i++)
        {
            int taskIndex = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int[] array = GenerateAndSortArray();

                int count = array.Count(n => n == X);

                stopwatch.Stop();
                executionTimes[taskIndex] = stopwatch.ElapsedMilliseconds;

                // Выводим результат (для отладки)
                Console.WriteLine($"Task {taskIndex + 1}: Found {count} elements equal to {X} in {executionTimes[taskIndex]} ms");
                lock (locker)
                {
                    Colvo++;
                    Monitor.Pulse(locker);
                }
            });
        }
        lock (locker){
            while(Colvo < 10)
            {
                Monitor.Wait(locker);
            }
        }


        // Вычисляем минимальное, максимальное и среднее время выполнения
        long minTime = executionTimes.Min();
        long maxTime = executionTimes.Max();
        double averageTime = executionTimes.Average();

        Console.WriteLine($"Min time: {minTime} ms");
        Console.WriteLine($"Max time: {maxTime} ms");
        Console.WriteLine($"Average time: {averageTime} ms");
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
