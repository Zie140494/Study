using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();
            countries.Add(1, "Russia");
            countries.Add(3, "Great Britain");
            countries.Add(2, "USA");
            countries.Add(4, "China");

            foreach (KeyValuePair<int,string> kvp in countries)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }

            //get
            string country = countries[4];
            //set
            countries[4] = "spain";

            countries.Remove(2);

            Console.WriteLine("Delete Element with key 2");
            Console.WriteLine("After delete");

            foreach (KeyValuePair<int, string> kvp in countries)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }

            Dictionary<char, Person> persons = new Dictionary<char, Person>();
            persons.Add('v', new Person { Name="Vasya" });
            persons.Add('p', new Person { Name = "Petya" });
            persons.Add('l', new Person { Name = "Lexa" });

            Console.WriteLine("key");
            foreach (char c in persons.Keys)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Values");
            foreach (Person p in persons.Values)
            {
                Console.WriteLine(p.Name);
            }


            Console.ReadLine();
        }
        class Person
        {
            public string Name { get; set; }
        }
    }
}
