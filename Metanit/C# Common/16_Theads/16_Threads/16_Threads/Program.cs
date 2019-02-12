using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;

            Console.WriteLine(t.IsAlive);
            Console.WriteLine(t.IsBackground);
            Console.WriteLine(t.IsThreadPoolThread);
            Console.WriteLine(t.Priority);
            Console.WriteLine(t.ThreadState);
            Console.ReadLine();
        }
    }
}
