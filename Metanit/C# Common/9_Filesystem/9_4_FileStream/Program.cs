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
            WritePart();
            Console.Read();
        }
        public static void WriteAndReadFIle()
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
        }
        public static void WritePart()
        {
            string text = "Hello world!";
            using (FileStream fs = new FileStream(@"D:/test.txt", FileMode.OpenOrCreate))
            {
                byte[] input = Encoding.Default.GetBytes(text);
                fs.Write(input, 0, input.Length);
                Console.WriteLine("Текст записан в файл");

                fs.Seek(-5, SeekOrigin.End);

                byte[] output = new byte[4];
                fs.Read(output, 0, output.Length);
                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine($"Текст из файла {textFromFile}");

                string replacetext = "house";
                fs.Seek(-5, SeekOrigin.End);
                input = Encoding.Default.GetBytes(replacetext);
                fs.Write(input, 0, input.Length);

                fs.Seek(0, SeekOrigin.Begin);
                output = new byte[fs.Length];
                fs.Read(output, 0, output.Length);
                textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine($"Текст из файла:{textFromFile}");
            }
        }
    }
}
