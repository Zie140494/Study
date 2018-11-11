using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._5_streamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:/Test/vas.txt";
            Console.WriteLine("Считываем весь файл");
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            Console.WriteLine();
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
