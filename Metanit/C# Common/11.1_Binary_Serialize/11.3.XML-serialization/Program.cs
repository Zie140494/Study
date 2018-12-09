using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace _11._3.XML_serialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
        public Person()
        {
                
        }
        public Person(string name, int age, Company comp)
        {
            Name = name;
            Age = age;
            Company = comp;
        }
    }
    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public Company()
        {
                
        }
        public Company(string name)
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("vasya", 27, new Company("Microsoft"));
            Person person2 = new Person("Petya", 23, new Company("VSK"));
            Person[] people = new Person[] { person1,person2};

            XmlSerializer xs = new XmlSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs,people);
            }

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                Person[] newPeople = (Person[])xs.Deserialize(fs);
                foreach (var np in newPeople)
                {
                    Console.WriteLine($"Name - {np.Name} is {np.Age}, works in company {np.Company.Name} ");
                }
            }
            Console.ReadLine();
        }
    }
}
