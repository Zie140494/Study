using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNumeric.Calculation
{
    public static class Calculate
    { 
        //Из даты в строку
        public static NumericRow GetRow(DateTime? dt)
        {
            var nr = new NumericRow(0);
            nr.n1 = dt.Value.Day / 10;
            nr.n2 = dt.Value.Day %10;
            nr.n3 = dt.Value.Month / 10;
            nr.n4 = dt.Value.Month %10;
            nr.n5 = dt.Value.Year/1000;
            nr.n6 = dt.Value.Year / 100%10;
            nr.n7 = dt.Value.Year / 10%10;
            nr.n8 = dt.Value.Year%10;

            return nr;
        }
        //для английского формата даты
        public static NumericRow GetRow1(DateTime? dt)
        {
            var nr = new NumericRow(0);
            nr.n3 = dt.Value.Day / 10;
            nr.n4 = dt.Value.Day % 10;
            nr.n1 = dt.Value.Month / 10;
            nr.n2 = dt.Value.Month % 10;
            nr.n5 = dt.Value.Year / 1000;
            nr.n6 = dt.Value.Year / 100 % 10;
            nr.n7 = dt.Value.Year / 10 % 10;
            nr.n8 = dt.Value.Year % 10;

            return nr;
        }
        //Метод высчитывания по псевдосумме
        public static int GetFakeSum(int i)
        {
            //throw new Exception("Test");
            string s;
            while (i >= 10)
            {
                s = i.ToString();
                char[] c = s.ToCharArray();
                int sum = 0;
                foreach (char ch in c)
                {
                    sum += (int)char.GetNumericValue(ch);
                }
                i = sum;
            };
            return i;
        }
        //Из даты в жизненный код
        public static int GetLC(DateTime? dt)
        {
            string s = dt.Value.ToShortDateString();
            s = s.Replace(".", string.Empty);
            var c = s.ToCharArray();
            char[] ch1 = new char[2] { c[0], c[1] };
            char[] ch2 = new char[2] { c[2], c[3] };
            char[] ch3 = new char[4] { c[4], c[5], c[6], c[7] };
            string s1 = new string(ch1);
            string s2 = new string(ch2);
            string s3 = new string(ch3);
            int i = Convert.ToInt32(s1) * Convert.ToInt32(s2) * Convert.ToInt32(s3);

            return i;
        }
        //для англ
        public static int GetLC1(DateTime? dt)
        {
            
            int i = dt.Value.Month * dt.Value.Day * dt.Value.Year;

            return i;
        }
        //Получить последовательность для формы
        public static Dictionary<int, string> GetSequenceForm(int dt, int n1, int n2, int n3, int n4, int ad)
        {
            if (n3 < 0)
                n3 = n3 * (-1);
            if (n4 < 0)
                n4 = n4 * (-1);
            var d = new Dictionary<int, string>();
            d.Add(0, "");
            d.Add(1, "");
            d.Add(2, "");
            d.Add(3, "");
            d.Add(4, "");
            d.Add(5, "");
            d.Add(6, "");
            d.Add(7, "");
            d.Add(8, "");
            d.Add(9, "");
            string sAllNum;
            sAllNum = dt.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString();
            var chA = sAllNum.ToCharArray();
            foreach (var ch in chA)
            {
                string st = ch.ToString();
                int i = (int)char.GetNumericValue(ch);
                d[i] = d[i] + st;
            }

            if (ad != 0)
            {
                string sAdd = ad.ToString();
                chA = sAdd.ToCharArray();
                foreach (var ch in chA)
                {
                    string st = ch.ToString();
                    int i = (int)char.GetNumericValue(ch);
                    d[i] = d[i] + $"[{st}]";
                }
            }

            return d;
        }
        //Получить последовательность для рассчетов
        public static Dictionary<int, string> GetSequencecalc(int dt, int n1, int n2, int n3, int n4, int ad)
        {
            var d = new Dictionary<int, string>();
            d.Add(0, "");
            d.Add(1, "");
            d.Add(2, "");
            d.Add(3, "");
            d.Add(4, "");
            d.Add(5, "");
            d.Add(6, "");
            d.Add(7, "");
            d.Add(8, "");
            d.Add(9, "");
            string sAllNum;
            sAllNum = dt.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString() + ad.ToString();
            var chA = sAllNum.ToCharArray();
            foreach (var ch in chA)
            {
                string st = ch.ToString();
                int i = (int)char.GetNumericValue(ch);
                d[i] = d[i] + st;
            }
            return d;
        }
        //Подчет для второстепенных качеств
        public static string GetNumSecSkill(string s1, string s2, string s3)
        {
            int i = s1.Length + s2.Length + s3.Length;
            if (i == 0)
                return "нет";
            else
                return i.ToString();
        }
    }

}