using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleLab21_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину участка - ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка - ");
            int M = Convert.ToInt32(Console.ReadLine());
            Garden land = new Garden();
            //создаём сад
            land.SetGarden(N, M);
            //вывод массива
            land.GetGarden();
            Console.WriteLine();
            //обработка участка садовниками
            ThreadStart threadStart2 = new ThreadStart(land.Sadovnik2);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();
            land.Sadovnik1();
            //вывод обработанного масива
            Console.WriteLine("Для вывода результата нажмите любую клавишу");
            Console.ReadKey();
            land.GetGarden();
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }

        class Garden
        {
            int n;
            int m;
            int[,] garden;

            public void SetGarden(int N, int M)
            {
                n = N;
                m = M;
                garden = new int[n, m];
            }

            public void GetGarden()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("{0}\t", garden[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            public void Sadovnik1()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (garden[i, j] == 0)
                        {
                            garden[i, j] = 1;
                            Thread.Sleep(1);
                        }
                    }
                }
            }

            public void Sadovnik2()
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        if (garden[i, j] == 0)
                        {
                            garden[i, j] = 2;
                            Thread.Sleep(1);
                        }
                    }
                }
            }
        }
        
        
        
    }
}