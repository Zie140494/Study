using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //Split
            string[] sa2 = s12.Split(new char[] {' '});
            foreach (var s14 in sa2)
            {
                Console.WriteLine($"Split {s14}", StringSplitOptions.RemoveEmptyEntries);
            }

            //Trim
            string s15 = "Hello world";
            s15 = s15.Trim(new char[] { 'H', 'd' });
            Console.WriteLine($"Trim {s15}");

            //Substring
            string s16 = "Hello world";
            s16 = s16.Substring(6);
            Console.WriteLine($"substring1 - {s16}");
            s16 = s16.Substring(0, 2);
            Console.WriteLine($"substring2 - {s16}");

            //Insert
            string s17 = "Hello";
            string s18 = "World";
            s17 = s17.Insert(5,s18);
            Console.WriteLine($"Insert {s18}");

            //Remove
            string s19 = "hello world";
            s19 = s19.Remove(0,1);
            s19 = s19.Remove(s19.Length-1);
            Console.WriteLine($"Remove {s19}");

            //Replace
            string s20 = "Hello world";
            s20 = s20.Replace('o','0');
            Console.WriteLine($"Replace {s20}");

            //switch register
            string s21 = "Hello world";
            Console.WriteLine($"Upper {s21.ToUpper()}");
            Console.WriteLine($"Lower {s21.ToLower()}");

            //float
            double num = 23.7;
            Console.WriteLine(string.Format("{0:C}",num));//23.7
            Console.WriteLine(string.Format("{0:C2}",num));

            //int with adding zero
            int num1 = 23;
            Console.WriteLine(string.Format("{0:d}",num1));
            Console.WriteLine(string.Format("{0:d4}", num1));

            //float format
            double num2 = 45.88;
            Console.WriteLine(string.Format("{0:f1}",num2));
            Console.WriteLine(string.Format("{0:f3}", num2));


            //Percent
            decimal num3 = 0.1543m;
            Console.WriteLine(string.Format("{0:P2}",num3));

            //Phone and ToString()
            long num4 = 79528848904;
            Console.WriteLine(string.Format("{+# (###) ###-##-##}"));
            Console.WriteLine(num4.ToString("+# (###) ###-##-##"));

            //Interpolation
            Console.WriteLine($"{num4:#-###-###-##-##}");
            //Add space
            string name = "Vasya";
            int age = 24;
            Console.WriteLine($"Имя: {name, -5},возраст - {age} ");
            Console.WriteLine($"Имя: {name,5},возраст - {age} ");


            //String builder
            StringBuilder sb = new StringBuilder("Hello world");
            Console.WriteLine($"Length of string - {sb.Length}");
            Console.WriteLine($"Capacity of string - {sb.Capacity}");

            //empty string
            StringBuilder sb1 = new StringBuilder(20);

            //sb append
            StringBuilder sb2 = new StringBuilder("Руководство ");
            Console.WriteLine($"Capacity1 {sb2.Capacity}");
            sb.Append("Po");
            Console.WriteLine($"Capacity2 {sb2.Capacity}");

            //sb other methods
            StringBuilder sb3 = new StringBuilder("Hello world");
            sb3.Append("!");
            sb3.Insert(7, "World");
            Console.WriteLine(sb3);

            sb3.Remove(7, 13);
            Console.WriteLine(sb3);

            //Regular expression
            string s23 = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
            Regex regex = new Regex(@"Туп(\w)",RegexOptions.Compiled|RegexOptions.IgnoreCase);
            MatchCollection match = regex.Matches(s23);
            if (match.Count>0)
            {
                foreach (var m in match)
                    Console.WriteLine(m);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }




            Console.ReadLine();
        }
    }
}
