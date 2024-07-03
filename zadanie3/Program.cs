class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность массива:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Random randon = new Random();
        for(int i = 0; i < n; i++)
        {
            array[i] = randon.Next(n + 1);
        }
        int[] array1 = (int[])array.Clone();
        Array.Sort(array1);
        Console.WriteLine(string.Join(", ", array1));
        double median = VichMedian(array);
        Console.WriteLine(median);
    }
    static double VichMedian(int[] array)
    {
        int[] sortarray = (int[])array.Clone();
        Array.Sort(sortarray);
        int middle = sortarray.Length / 2;
        if (sortarray.Length % 2 == 0)
        {
            return (sortarray[middle - 1] + sortarray[middle]) / 2.0;
        }
        else
        {
            return sortarray[middle];
        }

    }
}