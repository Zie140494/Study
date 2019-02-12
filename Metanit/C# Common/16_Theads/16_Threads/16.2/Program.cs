using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ia = 4;
            Thread t1 = new Thread(new ThreadStart(Count));
            t1.Start();
            Thread t2 = new Thread(new ParameterizedThreadStart(Count));
            t2.Start(ia);
            Counter c = new Counter();
            c.x = 5;
            c.y = 7;
            t2.Start(c);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"Main {i}");
                Thread.Sleep(500);
            }
            Console.ReadLine();
        }
        public static void Count()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"Count{i}");
                Thread.Sleep(400);
            }
        }
        public static void Count(object ia)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"Count{i}");
                Thread.Sleep(400);
            }
        }
    }
    public class Counter
        {
        public int x { get; set; }
        public int y { get; set; }
    }
}
