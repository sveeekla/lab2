using Microsoft.VisualBasic.FileIO;
using System;



internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите значение E:");
        double eps = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите значение x:");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите значение x_n:");
        double x_n = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите значение шага h:");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.Write('\n');

        int size = (int)((x_n - x) / h) + 1;

        double[] x_array = new double[size + 1];
        double[] function_results = new double[size + 1];
        double[] calculations = new double[size + 1];

        for (int i = 0; i < size; i++)
        {
            x_array[i] = x + i * h;
            function_results[i] = 1/(1+x_array[i]);

            double sum = 0;
            double a = 1;
            while (Math.Abs(a) > eps)
            {
                sum = sum + a;
                a *= -x_array[i];
            }

            calculations[i] = sum;
        }

        if (x_array[size - 1] != x_n)
        {
            x_array[size] = x_n;
            function_results[size] = 1 / (1 + x_array[size]);

            double sum = 0;
            double a = 1;
            while (Math.Abs(a) > eps)
            {
                sum = sum + a;
                a *= -x_array[size];
            }
            calculations[size] = sum;
        }
        else
            size--;


        int count_backslash = (int)(size / 5) + 1;
        int k = 0;
        while (k < count_backslash)
        {
            Console.Write("{0, -17}", "x:");
            for (int j = k * 5; j < 5 * (k + 1) && j < size + 1; j++)
                Console.Write(string.Format("{0, -16}", string.Format("{0:G8}", x_array[j])));
            Console.Write('\n');

            Console.Write("{0, -17}", "f(x) по формуле:");
            for (int j = k * 5; j < 5 * (k + 1) && j < size + 1; j++)
                Console.Write(string.Format("{0, -16}", string.Format("{0:G8}", function_results[j])));
            Console.Write('\n');

            Console.Write("{0, -17}", "f(x) вычисл.:");
            for (int j = k * 5; j < 5 * (k + 1) && j < size + 1; j++)
                Console.Write(string.Format("{0, -16}", string.Format("{0:G8}", calculations[j])));

            Console.Write("\n\n");
            ++k;
        }
    }
}