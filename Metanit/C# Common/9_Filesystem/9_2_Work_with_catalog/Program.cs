﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_2_Work_with_catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFileList();
            CreateCatalog();
            GetInfo();
            DeleteCatalog();
            MoveIntoOtherCatalog();
        }
        //Get list of files and subdirectories
        public static void GetFileList()
        {
            var dirName = "C:\\";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Subdirectories:");
                var subdirectories = Directory.GetDirectories(dirName);
                foreach (var s in subdirectories)
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine();

                Console.WriteLine("Files");
                var files = Directory.GetFiles(dirName);
                foreach (var s in files)
                {
                    Console.WriteLine(s);
                }

                Console.ReadLine();
            }
        }
        //Create new catalog
        public static void CreateCatalog()
        {
            string path = @"C:\SomeDir";
            string subpath = @"program/Ilya";

            var drInfo = new DirectoryInfo(path);
            if (!drInfo.Exists)
            {
                drInfo.Create();
            }
            drInfo.CreateSubdirectory(subpath);

            Console.ReadLine();
        }
        //Get Info from Catalog
        public static void GetInfo()
        {
            string dir = @"C:\Program Files";
            var dirInfo = new DirectoryInfo(dir);

            Console.WriteLine("Name of catalog: {0}", dirInfo.Name);
            Console.WriteLine("FullName of catalog: {0}", dirInfo.FullName);
            Console.WriteLine("Creation time: {0}", dirInfo.CreationTime);
            Console.WriteLine("Root: {0}", dirInfo.Root);

            Console.ReadLine();
        }
        //Delete some catalog
        public static void DeleteCatalog()
        {
            var dirName = @"C:\someDir";

            try
            {
                var dir = new DirectoryInfo(dirName);
                dir.Delete(true);
                Console.WriteLine("Катало {0}, удален", dir.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
        //Move into other catalog
        public static void MoveIntoOtherCatalog()
        {
            var oldPath = @"C:\SomeDir";
            var newPath = @"C:\SomeOtherDir";

            var dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo.MoveTo(newPath);
            }
            Console.ReadLine();
        }
    }
}
