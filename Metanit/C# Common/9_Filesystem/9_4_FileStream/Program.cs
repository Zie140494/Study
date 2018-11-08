using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_4_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для записи в файл");
            string text = Console.ReadLine();

            using (FileStream fs = new FileStream(@"C:/Test/Vasa.txt", FileMode.OpenOrCreate))
            {

            }
        }
    }
}
