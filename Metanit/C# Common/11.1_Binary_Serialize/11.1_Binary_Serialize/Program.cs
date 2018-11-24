using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _11._1_Binary_Serialize
{
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom", 27);
            Person person2 = new Person("Vasya", 30);
            Person[] people = new Person[] {person,person2};
            Console.WriteLine("Object is created");

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person[] newPerson = (Person[])formatter.Deserialize(fs);
                Console.WriteLine("Объект десериалзован");
                foreach (var ns in newPerson)
                    Console.WriteLine($"Имя:{ns.Name} Возвраст:{ns.Age}");
            }

            Console.ReadLine();
        }
    }
}
