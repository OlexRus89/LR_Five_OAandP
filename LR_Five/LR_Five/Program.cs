using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Threading;

namespace LR_Five
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вариант 27
            /*
             *Дана исходная матрица M  N целых чисел, принадлежащих отрезку
             *[-103, 103]. В выходной файл необходимо вывести следующие значения:
             *1) исходную матрицу;
             *2) среднее арифметическое для каждой строки;
             *3) среднее арифметическое нечетных элементов для каждого столбца.
             */

            int N, M;
            string FileName;

            Console.Write("Введите целое число N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите целое число M: ");
            M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите имя ткстового файла (без расширения .txt): ");
            FileName = Console.ReadLine();
            FileName += ".txt";
            Console.WriteLine("Идет создание рандомных чисел...");

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(FileName);
            Console.SetOut(new_out);

            Console.WriteLine(N);
            Console.WriteLine(M);

            Random r = new Random(DateTime.Now.Millisecond);
            int x = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    x = r.Next(-1000, 1001);
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out); new_out.Close();
            Console.WriteLine("Файл " + FileName + " была создана!");
            Console.WriteLine();
            Console.WriteLine("Идет инициализация массива из исходного массива");
            Console.WriteLine("Идет расчитывание среднего арифметического для каждой строки");
            Console.WriteLine("Идет расчитывание среднего арифметического нечетных элементов для каждого стобца");

            TextWriter save_out1 = Console.Out;
            TextReader save_in = Console.In;
            var new_out1 = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(FileName);
            Console.SetOut(new_out1);
            Console.SetIn(new_in);

            int N1 = Convert.ToInt32(Console.ReadLine());
            int M1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("*** Ввод матрицы ***");

            // Ввод данных из исходной матрицы
            int[,] mas = new int[N1,M1];
            for (int i = 0; i < N1; i++)
            {
                String str_all = Console.ReadLine();
                string[] str_elem = str_all.Split(' ');
                for (int j = 0; j < M1; j++)
                {
                    mas[i,j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Среднее арифметическое для каждой строки
            Console.WriteLine("***Среднее арифметическое для каждой строки***");
            double[] mas1 = new double[N1];
            for (int i = 0; i < N1; i++)
            {
                mas1[i] = 0;
            }
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    mas1[i] += mas[i, j];
                }
            }
            for (int i = 0; i < N1; i++)
            {
                mas1[i] /= N1;
                Console.WriteLine(mas1[i]);
            }
            Console.WriteLine();

            // Среднее арифметическое нечетных элементов для каждого столбца
            Console.WriteLine("***Среднее арифметическое нечетных элементов для каждого столбца***");
            double[] mas2 = new double[M1];
            int[] countMas = new int[M1];
            for (int j = 0; j < M1; j++)
            {
                mas2[j] = 0;
                countMas[j] = 0;
            }
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    if (mas[i, j] < 0)
                    {
                        mas2[j] += mas[i, j];
                        countMas[j] += 1;
                    }
                }
            }
            for (int j = 0; j < M1; j++)
            {
                mas2[j] /= countMas[j];
                Console.WriteLine("{0:0.0000}",mas2[j]);
            }


            Console.SetOut(save_out1); new_out1.Close();
            Console.SetIn(save_in); new_in.Close();
            Console.WriteLine();
            Console.WriteLine("Расчеты были завершены!");
            Console.WriteLine("Результаты " + FileName + " и output.txt находятся в @/LR_Five/LR_Five/bin/Debug/netcoreapp3.1");
        }
    }
}
