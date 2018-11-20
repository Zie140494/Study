using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_6_Binary
{
    struct State
    {
        public string name;
        public string capital;
        public int area;
        public double people;

        public State(string n,string c,int a, double p)
        {
            this.area = a;
            this.capital = c;
            this.name = n;
            this.people = p;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            State[] states = new State[2];
            states[0] = new State("Германия", "Берлин", 357168, 80.8);
            states[1] = new State("Франция", "Париж", 640679, 64.7);

            string path = @"C:\SomeDir\states.dat";

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path,FileMode.OpenOrCreate)))
                {
                    foreach (var st in states)
                    {
                        writer.Write(st.area);
                        writer.Write(st.capital);
                        writer.Write(st.name);
                        writer.Write(st.people);
                    }
                }
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar()>-1)
                    {
                        string name = reader.ReadString();
                        string capital = reader.ReadString();
                        int area = reader.ReadInt32();
                        double people = reader.ReadDouble();

                        Console.WriteLine($"Страна:{name}, столица:{capital}, Площадь:{area}, Население:{people} чел.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
