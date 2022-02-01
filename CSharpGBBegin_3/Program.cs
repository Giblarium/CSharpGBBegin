using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpGBBegin_3
{
    
    internal class Program
    {
        const int sizeArray = 10;

        static void Main(string[] args)
        {
            Quest1(); //заполнение массива случайными числами и вывод элементов на диагонали
            Quest2(); //телефонный справочник
            Quest3(); //строка наоборот
            Quest4(); //морской бой
        }

        private static void Quest1()
        {
            Console.WriteLine("Исходный массив: ");
            Random random = new Random();
            int[,] array = new int[sizeArray, sizeArray];
            for (int i = 0; i <= array.GetUpperBound(0); i++) // заполнение массива случайными числами и вывод на экран
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
                    if (i == j) //если индексы равны, то это элемент на диагонали
                    {
                        Console.Write("{0, 2}", array[i, j]);
                    }
                }
            }
            Console.WriteLine();


            int indexDiagColumnElement = array.GetUpperBound(1);    //индекс колонки элемента на диагонали
            int indexDiagRowElement = 0;                            //индекс строки элемента на диагонали
            Console.WriteLine("Элементы по другой диагонали");
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= indexDiagColumnElement; j++)
                {
                    if (i == indexDiagRowElement && j == indexDiagColumnElement) //если индекс колонки и строки совпадает с итератором
                    {
                        Console.Write("{0, 2}", array[i, j]); //вывод элемента
                        indexDiagColumnElement--;   //уменьшение индекса колонки
                        indexDiagRowElement++;      //увеличение индекса строки
                        break; //прервать просмотр строки
                    }
                }
            }
            Console.WriteLine();

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
