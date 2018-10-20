using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> numbers = new LinkedList<int>();
            numbers.AddLast(1);//Add Last Node
            numbers.AddFirst(2);//Add First Node
            numbers.AddAfter(numbers.Last, 3);
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            LinkedList<Person> persons = new LinkedList<Person>();

            LinkedListNode<Person> tom = persons.AddLast(new Person () {Name = "Tom" });
            persons.AddLast(new Person() { Name = "Vasya" });
            persons.AddFirst(new Person() { Name = "Petya" });
            Console.WriteLine(tom.List.First.Value);
            Console.WriteLine(tom.List.Last.Value);
            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
}
