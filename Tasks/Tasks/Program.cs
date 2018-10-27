using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            Task task = new Task(() =>
            {
                for (int i=0;i<int.MaxValue;i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task is canceled");
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            },token);

            Console.WriteLine("Press key to start");
            Console.ReadLine();
            task.Start();
            Console.ReadLine();
            cts.Cancel();
            Console.WriteLine("Done!");
            Console.ReadLine();

        }
    
    }
}
