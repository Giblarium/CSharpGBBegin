using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGBBegin_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите минимальную температуру: ");
            Decimal.TryParse(Console.ReadLine(), out decimal minTemperature);
            Console.Write("Введите максимальную температуру: ");
            Decimal.TryParse(Console.ReadLine(), out decimal maxTemperature);

            decimal avrgTemperature = (maxTemperature + minTemperature) / 2;

            Console.WriteLine("Средняя температура равна: {0}", avrgTemperature.ToString());

        }
    }
}
