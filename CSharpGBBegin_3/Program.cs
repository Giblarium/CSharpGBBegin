using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGBBegin_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Quest1(); //заполнение массива случайными числами и вывод элементов на диагонали
            //Quest2(); //телефонный справочник
            Quest3(); //строка наоборот
            //Quest4(); //морской бой
        }

        private static void Quest1()
        {
            Console.WriteLine("Исходный массив: ");
            Random random = new Random();
            int[,] array = new int[5, 5];
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    array[i, j] = random.Next(0, 10);
                    Console.Write("{0, 2}", array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Элементы по диагонали");
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write("{0, 2}", array[i, j]);
                    }
                }
            }


            EndQuest();
        }

        private static void Quest2()
        {
            
            string[,] array = new string[5, 2] 
            {
                {"Иванов","+790095353333"},
                {"Петров","+790095353377"},
                {"Ойлюц","+790095883333"},
                {"Сидоров","+799995353333"},
                {"Ильчук","ilschukdemo@gmail.com"},
            };
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();

            }


            EndQuest();
        }

        private static void Quest3()
        {
            Console.Write("Введите фразу: ");
            string str = Console.ReadLine();
            //string str = "ойлюц";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }

            EndQuest();
        }

        private static void Quest4()
        {
            char[,] cells = new char[10, 10] 
            {
                {'O', 'O', 'X', 'X', 'X', 'X', 'O', 'O', 'O', 'X'},
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'X', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'X', 'O', 'O', 'O', 'O', 'X', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O'},
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'O'},
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'O', 'X'},
                {'X', 'O', 'O', 'X', 'X', 'O', 'O', 'O', 'O', 'O'},
            };

            for (int i = 0; i <= cells.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= cells.GetUpperBound(1); j++)
                {
                    Console.Write(cells[i, j]);
                }
                Console.WriteLine();
            }





            EndQuest();
        }

        private static void EndQuest()
        {
            Console.ReadLine();
            Console.Clear();
        } //ожидание ввода и очистка консоли

    }
}
