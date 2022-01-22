using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGBBegin_2
{
    internal class Program
    {
        public static decimal avgrTemp = 0;
        public static int numberMonth = 0;
        static void Main(string[] args)
        {
            Quest1(); // ввод минимальной и максимальной температуры за сутки и вывод среднесуточной температуры

            Quest2(); //Ввод порядкового номера текущего месяца и вывод его названия
            Quest3(); // Четное или нечетное число
            Quest4(); //печать чека
            Quest5(); //дождливая ли зима?
            Quest6(); //поиск работающего сегодня офиса
        }

        private static void Quest1()
        {
            Console.Write("Введите минимальную температуру: ");
            Decimal.TryParse(Console.ReadLine(), out decimal minTemp);
            Console.Write("Введите максимальную температуру: ");
            Decimal.TryParse(Console.ReadLine(), out decimal maxTemp);

            avgrTemp = (minTemp + maxTemp) / 2;
            Console.Write("Средняя температура за день равна: {0}", avgrTemp);


            EndQuest();
        }

        private static void Quest2()
        {
            Console.Write("Введите номер месяца: ");
            Int32.TryParse(Console.ReadLine(), out numberMonth);
            string nameMonth;
            switch (numberMonth)
            {
                case 1:
                    nameMonth = "январь";
                    break;
                case 2:
                    nameMonth = "февраль";
                    break;
                case 3:
                    nameMonth = "март";
                    break;
                case 4:
                    nameMonth = "апрель";
                    break;
                case 5:
                    nameMonth = "май";
                    break;
                case 6:
                    nameMonth = "июнь";
                    break;
                case 7:
                    nameMonth = "июль";
                    break;
                case 8:
                    nameMonth = "август";
                    break;
                case 9:
                    nameMonth = "сентябрь";
                    break;
                case 10:
                    nameMonth = "октябрь";
                    break;
                case 11:
                    nameMonth = "ноябрь";
                    break;
                case 12:
                    nameMonth = "декабрь";
                    break;
                default:
                    Console.WriteLine("Введен не номер месяца");
                    EndQuest();
                    return;
            }


            Console.WriteLine("Месяц {0}.", nameMonth);


            EndQuest();
        }

        private static void Quest3()
        {
            Console.Write("Введите число: ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out int number);
            if (isNumber)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("Число четное.");
                }
                else
                {
                    Console.WriteLine("Число нечетное.");
                }
            }
            else
            {
                Console.WriteLine("Введено не число.");
            }


            EndQuest();
        }

        #region Quest4

        class Goods //описание товара и конструктор
        {
            public string name;
            public double price;

            public Goods(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        }

        private static void Quest4()
        {
            string shop = "Пятерочка";
            string addres = "г. Воронеж";

            Goods[] goods = new Goods[5]
            {
                new Goods("Яблоки", 99.99),
                new Goods("Сливки", 60.69),
                new Goods("Молоко", 56.99),
                new Goods("Морковь", 1399.70),
                new Goods("Пакет", 59.99)
            };

            string dateTime = DateTime.Now.ToString("dd.MM.yy");

            int numberReceipt = new Random().Next(10, 99);

            double sum = 0;
            foreach (var good in goods)
            {
                sum += good.price;
            }

            WriteLine();
            WriteCenter(shop);
            WriteCenter(addres);
            WriteLine();
            Console.WriteLine("|{0, -9} чек № {1, 2}|", dateTime, numberReceipt);
            WriteLine();
            foreach (var good in goods)
            {
                WriteGoods(good);
            }
            WriteLine();
            Console.WriteLine("|Итого {0, 12}|", sum);
            WriteLine();
            EndQuest();
        }

        /// <summary>
        /// печать строки с товаром
        /// </summary>
        /// <param name="good">объект Goods</param>
        private static void WriteGoods(Goods good)
        {
            string priceStr = good.price.ToString("f2");
            for (int i = 0; i < 20; i++)
            {
                if (i == 0 || i == 19)
                {
                    Console.Write("|");
                    continue;
                }
                if (i == 1)
                {
                    Console.Write(good.name);
                    i += good.name.Length - 1;
                }
                if (i == 18 - priceStr.Length)
                {
                    Console.Write(priceStr);
                    i += priceStr.Length;
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();

        }
        /// <summary>
        /// Печать строки прочерков
        /// </summary>
        private static void WriteLine()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// печать текста по центру строки
        /// </summary>
        /// <param name="str"></param>
        private static void WriteCenter(string str)
        {
            int mid = str.Length / 2;
            for (int i = 0; i < 20; i++)
            {
                if (i == 0 || i == 19)
                {
                    Console.Write("|");
                    continue;
                }
                if (i == 10 - mid)
                {
                    Console.Write(str);
                    i += str.Length - 1;
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();

        }
        #endregion

        private static void Quest5()
        {
            if ((numberMonth == 12 || numberMonth == 1 || numberMonth == 2) && avgrTemp > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
            else 
            {
                Console.WriteLine("Не дождливая не зима");
            }

            EndQuest();
        }

        #region Quest6

        public class Office 
        {
            public string name;
            public int schedule;

            public Office(string name, int schedule)
            {
                this.name = name;
                this.schedule = schedule;
            }
        }

        private static void Quest6()
        {
            Office[] offices = new Office[] {

            new Office("Office1", 0b_11111_00),
            new Office("Office2", 0b_01111_10),
            new Office("Office3", 0b_00111_11),
            new Office("Office4", 0b_10011_11),
            new Office("Office5", 0b_11001_11),
            new Office("Office6", 0b_11100_11),
            new Office("Office7", 0b_11110_01),
            };


        
            Console.Write("Введите день недели: ");
            bool isInt = Int32.TryParse(Console.ReadLine(), out int dayOfWeek);
            if (!isInt || (dayOfWeek < 1 || dayOfWeek > 7))
            {
                dayOfWeek = (int)DateTime.Now.DayOfWeek;
                Console.WriteLine("Изменено на {0}", dayOfWeek.ToString());
            }

            int workOfficeMask = 0;

            switch (dayOfWeek)
            {
                case 1:
                    workOfficeMask = 0b_10000_00;
                    break;
                case 2:
                    workOfficeMask = 0b_01000_00;
                    break;
                case 3:
                    workOfficeMask = 0b_00100_00;
                    break;
                case 4:
                    workOfficeMask = 0b_00010_00;
                    break;
                case 5:
                    workOfficeMask = 0b_00001_00;
                    break;
                case 6:
                    workOfficeMask = 0b_00000_10;
                    break;
                case 7:
                    workOfficeMask = 0b_00000_01;
                    break;
                default:
                    break;
            }

            Console.WriteLine("В {0} день недели работают офисы: ", dayOfWeek);
            foreach (var office in offices)
            {
                int i = office.schedule & workOfficeMask;
                if (i == workOfficeMask)
                {
                    Console.WriteLine(office.name);
                }
            }

            EndQuest();
        }
        #endregion
        private static void EndQuest()
        {
            Console.ReadLine();
            Console.Clear();
        } //ожидание ввода и очистка консоли
    }
}
