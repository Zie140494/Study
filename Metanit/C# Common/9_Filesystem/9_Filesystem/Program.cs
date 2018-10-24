using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Filesystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drivers)
            {
                Console.WriteLine("Имя:{0}",dr.Name);
                Console.WriteLine("Type:{0}", dr.DriveType);
                if (dr.IsReady)
                {
                    Console.WriteLine("Объем диска:{0}",dr.TotalSize);
                    Console.WriteLine("Свободное пространство", dr.TotalFreeSpace);
                    Console.WriteLine("Метка", dr.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
