using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = new String('a',6);
            string s2 = new String(new char[] {'w','o','r','l','d'});
            Console.WriteLine(s);
            Console.WriteLine(s2);

            //Concat
            string s3 = "Hello";
            string s4 = "world";
            string s5 = $"{s3} {s4}";
            string s6 = String.Concat(s5,"!!!");
            Console.WriteLine("Concat "+s6);

            //Join 
            string[] sa = new string[] { "Join", "Hello", "World" };
            string s9 = string.Join(" ",sa);
            Console.WriteLine(s9);

            //Compare
            string s10 = "Hello";
            string s11 = "world";
            int result1 = String.Compare(s10, s11);
            if (result1 < 0)
                Console.WriteLine("Compare Hello is first");
            else if (result1 > 0)
                Console.WriteLine("Compare worldis first");
            else
                Console.WriteLine("Compare they are equals");

            //Search and StartWith
            string s12 = "Hello world";
            char ch1 = 'o';
            string s13 = "world";
            int indexOfChar = s12.IndexOf(ch1);
            bool isStart = s12.StartsWith(s13);


            Console.ReadLine();
        }
    }
}
