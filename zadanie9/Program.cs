Delegate1 delegate1 = PrintMessage;
delegate1(25, "Поздравляю!!! Ваша оценка:", true);
Delegate2 delegate2 = Ocenka;
int[] mas = { 25, 26, 27 };
int message = delegate2(mas, 2);
Console.WriteLine(message);
void PrintMessage(int ocenka, string message, bool sdal)
{
    if(sdal == true)
    {
        Console.WriteLine($"Поздравляю!!! Ваша оценка:{ocenka}");
    }
    else
    {
        Console.WriteLine($"Сегодня удача не на вашей стороне!");
    }
}
int Ocenka(int[] mas_ocenka, double kf)
{
    int sum = 0;
    for(int i = 0; i < mas_ocenka.Length; i++)
    {
        mas_ocenka[i] = mas_ocenka[i] *  (int)kf;
        sum += mas_ocenka[i];
    }
    return sum;
}
delegate void Delegate1(int ocenka, string message, bool sdal);
delegate int Delegate2(int[] mas_ocenka, double kf);
