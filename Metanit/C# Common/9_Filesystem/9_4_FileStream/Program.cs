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
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(array, 0, text.Length);
                Console.WriteLine("Данные записаны в файл");
            }
            using (FileStream fs = File.OpenRead(@"C:/Test/Vasa.txt"))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

            }
            Console.Read();
        }
    }
}
