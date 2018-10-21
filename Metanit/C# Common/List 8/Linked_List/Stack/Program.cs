using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        //Stack
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(8);

            int stackElement = numbers.Pop();
            Console.WriteLine(stackElement);

            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person {Name="Vasya" });
            persons.Push(new Person { Name = "Petya" });
            persons.Push(new Person { Name = "Lexa" });

            Console.WriteLine("Initial Data");

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Pop " + persons.Pop().Name);

            Console.WriteLine("After POP");

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Peek " +persons.Peek().Name);

            Console.WriteLine("After Peek");

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
}
