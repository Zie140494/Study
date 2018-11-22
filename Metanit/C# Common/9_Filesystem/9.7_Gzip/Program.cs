using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace _9._7_Gzip
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "D://test/book.pdf"; // исходный файл
            string compressedFile = "D://test/book.gz"; // сжатый файл
            string targetFile = "D://test/book_new.pdf"; // восстановленный файл

            //Создание сжатого файла
            Compress(sourceFile, compressedFile);
            //Чтение из сжатого файла
            Decompress(compressedFile,targetFile);


            
        }

        private static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }

        private static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream fs = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(sourceFile))
                {
                    using (GZipStream gz = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        fs.CopyTo(gz);
                        Console.WriteLine($"Сжатие файла {sourceFile} прошло успешно. Исходный размер {fs.Length}, сжатый размер:{targetStream.Length}");
                    }

                }
            }
        }
    }
}
