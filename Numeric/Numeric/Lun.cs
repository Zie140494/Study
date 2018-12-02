using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeric
{

    public class Lun
    {
        public int Year { get; set; }
        public int Sun { get; set; }
        public int Luna { get; set; }
        public int Sum { get; set; }
        public Lun(int year,int sun,int luna)
        {
            Year = year;
            Sun = sun;
            Luna = luna;
            Sum = Sun - Luna;
        }
    }
}
