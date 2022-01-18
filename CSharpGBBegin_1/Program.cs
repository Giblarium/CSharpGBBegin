using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGBBegin_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.UserName;
            string date = DateTime.Now.ToString("dd MMMM");

            Console.WriteLine("Привет, {0}! Сегодня {1}", username, date);
            
            Console.ReadLine();
        }
    }
}
