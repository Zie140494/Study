using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace _11._2_SOAP_Serialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom",27);
            Person person2 = new Person("Jerry",23);
            Person[] people = new Person[] { person, person2 };

            SoapFormatter sf = new SoapFormatter();

            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                sf.Serialize(fs,people);
                Console.WriteLine("Объект сериализован");
            }
            //Десериализация
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                Person[] newPeople = (Person[])sf.Deserialize(fs);
                Console.WriteLine("Object is deserialize");
                foreach (var np in newPeople)
                {
                    Console.WriteLine($"Имя - {np.Name}, возраст - {np.Age}");
                }
            }
            Console.ReadLine();

        }
    }
}
