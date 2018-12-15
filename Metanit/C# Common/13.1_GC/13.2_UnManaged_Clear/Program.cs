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
    public class Person:IDisposable
    {
        public void Dispose()
        {
            Console.Beep();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Test1();
            Test2();

            //Указатели
            unsafe
            {
                int* x;
                int y = 10;

                x = &y;//x=10
                uint adr = (uint)x;
                Console.WriteLine($"adress {adr}");

                byte* bytePointer = (byte*)(adr + 4);
                Console.WriteLine($"byte adr - {*bytePointer}");

                uint oldAdr = (uint)(bytePointer - 4);
                int* intPointer = (int*)oldAdr;
                Console.WriteLine($"oldadr - {*intPointer}");

                int** z = &x;
                Console.WriteLine(**z);

            }

            Console.Read();
        }
        //Destructor
        private static void Test()
        {
            PersonDes person = new PersonDes();
        }
        //Dispose1
        private static void Test1()
        {
            Person p = null;
            try
            {
                p = new Person();
            }
            finally
            {
                if (p != null)
                    p.Dispose();
            }
        }
        private static void Test2()
        {
            using (Person p = new Person())
            {

            }
        }
    }
}
