using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(3);
            numbers.Enqueue(5);
            numbers.Enqueue(7);

            int element = numbers.Dequeue();
            Console.WriteLine(element);

            Queue < Person > persons = new Queue<Person>();
            persons.Enqueue(new Person() { Name="Vasya"} );
            persons.Enqueue(new Person() { Name = "Petya" });
            persons.Enqueue(new Person() { Name = "Lexa" });

            Console.WriteLine("Peek");
            Person p = persons.Peek();
            Console.WriteLine("Выбранный элемент из очереди "+p.Name);
            foreach (Person pp in persons)
            {
                Console.WriteLine(pp.Name);
            }
            Console.WriteLine("Dequeue");
            Person p1 = persons.Dequeue();
            Console.WriteLine("Выбранный элемент из очереди " + p1.Name);
            foreach (Person pp in persons)
            {
                Console.WriteLine(pp.Name);
            }
            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
}
