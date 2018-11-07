using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_3_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInfo();
            Delete();
            MoveAndCopy();
        }
        public static void GetInfo()
        {
            string path = @"C:/Test/Инструкция.txt";
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }
            Console.Read();
        }
        public static void Delete()
        {
            string path = "C:/test/test1.txt";
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
        public static void MoveAndCopy()
        {
            var path = @"C:/Test/test1.txt";
            var newpath = @"C:/";
            var newpath2 = @"D:/";
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(newpath);
                fileInfo.MoveTo(newpath2);
            }
        }
    }
}
