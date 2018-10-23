using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator
{
    class Week
    {
        string[] days = {"Monday","Tuesday", "Wednesday","Thursday", "Friday", "Sunday"};

        public IEnumerator<string> GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }
    class WeekEnumerator : IEnumerator<string>
    {
        string[] days;
        int position = -1;
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }
        public string Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine(week);
            }
            Console.ReadLine();
        }
    }
}
