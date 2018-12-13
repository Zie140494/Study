using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13GC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Free memory - {GC.GetTotalMemory(false)}");

            //Call GC
            GC.Collect();
            //wait thread while GC don't finish
            GC.WaitForPendingFinalizers();
            //Clear 0 generation
            GC.Collect(0);
            //Clear 0 generation immedietly
            GC.Collect(1, GCCollectionMode.Forced);


            Console.ReadLine();
        }
    }
}
