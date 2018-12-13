using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._2_UnManaged_Clear
{
    //Class with destructor
    public class PersonDes
    {
        ~PersonDes()
        {
            Console.WriteLine("Object is cleared");
            Console.Beep();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
        }
        private static void Test()
        {
            PersonDes person = new PersonDes();
        }
    }
}
