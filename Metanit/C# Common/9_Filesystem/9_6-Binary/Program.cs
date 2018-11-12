using System;
using System.Collections.Generic;
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
        }
    }
}
