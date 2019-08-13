using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeric.Calculation
{
    public static class Calc
    {
        //Если 0, то 50/50 для луны
        public static string TransfLun(int i)
        {
            if (i == 0)
                return "50/50";
            else
                return i.ToString();
        }

        //Получить солнце
        public static int GetSun(int age, int lc)
        {
            var ch = (lc / age).ToString().ToCharArray();
            char[] ch1 = { ch[2], ch[3] };
            int result = GetSum(Convert.ToInt32(new string(ch1)));
            return result;
        }
        //Получить луну
        public static int GetLuna(int age, int lc)
        {
            var ch = (lc / age).ToString().ToCharArray();
            char[] ch1 = { ch[0], ch[1] };
            int result = GetSum(Convert.ToInt32(new string(ch1)));
            return result;
        }
        //Получить возраст
        public static int GetAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }


        //Для девятилетнего цикла создание словаря
        public static Dictionary<int, int> GetDicForLC(int n)
        {
            var result = new Dictionary<int, int>();
            for (int i = 0; i < 5; i++)
            {
                int sum = n + i;
                if (sum > 9)
                    sum = n + i - 9;
                result.Add(sum, DateTime.Now.Year + i);
            }
            return result;
        }
        //метод для комбинаций 
        public static bool hideRowMatch(string sR, string sAll, int i)
        {
            string[] wordsR = sR.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsAll = sAll.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int fd = 0;
            foreach (string si in wordsR)
            {
                foreach (string sj in wordsAll)
                {
                    if (sj == si)
                        fd++;
                }
            }
            if (wordsR.Length == fd)
                return true;
            else
                return false;
        }
        public static string ZeroToString(string s)
        {
            if (s == "нет")
                return "0";
            return s;
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
        //Выбор единственных значений и сортировка 4
        public static IEnumerable<int> GetWithoutDublicate4(int i1, int i2, int i3, int i4)
        {
            List<int> list = new List<int>();
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            list.Add(i4);
            IEnumerable<int> list1 = list.Distinct();
            list1 = list1.OrderBy(x => x);
            return list1;
        }
        public static void addWithAddingNum(List<int> list, int i)
        {
            if (i > 57)
                i = GetSum(i);
            switch (i)
            {
                case 56:
                    list.Add(1);
                    break;
                case 20:
                    list.Add(1);
                    break;
                case 33:
                    list.Add(3);
                    break;
                case 22:
                    list.Add(4);
                    break;
                case 50:
                    list.Add(5);
                    break;
                case 16:
                    list.Add(6);
                    break;
                case 37:
                    list.Add(7);
                    break;
                case 48:
                    list.Add(8);
                    break;
                case 49:
                    list.Add(9);
                    break;
                default:
                    break;
            }

            list.Add(i);
        }
        //Выбор единственных значений и сортировка 6
        public static IEnumerable<int> GetWithoutDublicate6(NumericRow6 nr6)
        {
            List<int> list = new List<int>();
            addWithAddingNum(list, nr6.n1);
            addWithAddingNum(list, nr6.n2);
            addWithAddingNum(list, nr6.n3);
            addWithAddingNum(list, nr6.n4);
            addWithAddingNum(list, nr6.n5);
            addWithAddingNum(list, nr6.n6);
            //list.Add(nr6.n1);
            //list.Add(nr6.n2);
            //list.Add(nr6.n3);
            //list.Add(nr6.n4);
            //list.Add(nr6.n5);
            //list.Add(nr6.n6);
            IEnumerable<int> list1 = list.Distinct();
            list1 = list1.OrderBy(x => x);
            return list1;
        }
        //Выбор единственных значений и сортировка 12
        public static IEnumerable<int> GetWithoutDublicate12(NumericRow12 nr12)
        {
            List<int> list = new List<int>();
            list.Add(nr12.n1);
            list.Add(nr12.n2);
            list.Add(nr12.n3);
            list.Add(nr12.n4);
            list.Add(nr12.n5);
            list.Add(nr12.n6);
            list.Add(nr12.n7);
            list.Add(nr12.n8);
            list.Add(nr12.n9);
            list.Add(nr12.n10);
            list.Add(nr12.n11);
            list.Add(nr12.n12);
            IEnumerable<int> list1 = list.Distinct();
            list1 = list1.OrderBy(x => x);
            return list1;
        }
        //для 56 судеб перевод итога
        public static string TransSU(int i)
        {
            if (i > 57)
                i = GetSum(i);
            switch (i)
            {
                case 56:
                    return "56/1";
                    break;
                case 20:
                    return "20/1";
                    break;
                case 33:
                    return "33/3";
                    break;
                case 22:
                    return "22/4";
                    break;
                case 50:
                    return "50/5";
                    break;
                case 16:
                    return "16/6";
                    break;
                case 37:
                    return "37/7";
                    break;
                case 48:
                    return "48/8";
                    break;
                case 49:
                    return "49/9";
                    break;
                default:
                    return i.ToString();
                    break;
            }
        }
        //Добавление нулей до шестизначного числа
        public static NumericRow6 AddNullsTo6(int i)
        {
            var nr6 = new NumericRow6(0);
            while (i < 1000000)
            {
                i *= 10;
            }
            string s = i.ToString();
            var c = s.ToCharArray();
            nr6.n1 = (int)char.GetNumericValue(c[0]);
            nr6.n2 = (int)char.GetNumericValue(c[1]);
            nr6.n3 = (int)char.GetNumericValue(c[2]);
            nr6.n4 = (int)char.GetNumericValue(c[3]);
            nr6.n5 = (int)char.GetNumericValue(c[4]);
            nr6.n6 = (int)char.GetNumericValue(c[5]);
            return nr6;
        }
        //константа месяца
        public static string GetConstMonth(string s)
        {
            switch (s)
            {
                case "1":
                    return "7";
                    break;
                case "2":
                    return "9";
                    break;
                case "3":
                    return "28";
                    break;
                case "4":
                    return "10";
                    break;
                case "5":
                    return "8";
                    break;
                case "6":
                    return "16";
                    break;
                case "7":
                    return "11";
                    break;
                case "8":
                    return "14";
                    break;
                case "9":
                    return "17";
                    break;
                case "10":
                    return "25";
                    break;
                case "11":
                    return "2";
                    break;
                case "12":
                    return "19";
                    break;
                default:
                    return null;
            }
        }
        //метод заполнения чисел последовательно для 56 судеб
        public static string GetFiveNums(string s, int i, int ld, int t, out int td)
        {
            int n = 0;
            td = 0;
            while (n < i)
            {
                if (t > ld)
                    t = 1;
                s += t.ToString() + ";";
                td = t;
                n++;
                t++;
            }
            td++;
            return s;
        }
        //Метод существование файла
        public static bool IsExists(string s)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");
            var f = dir.GetFiles();
            foreach (var t in f)
            {
                if (t.FullName.ToString() == s)
                {
                    return true;
                }
            }
            return false;
        }
        //Из даты в строку
        public static NumericRow GetRow(DateTime dt)
        {
            var nr = new NumericRow(0);
            string sDate = dt.ToString();
            sDate = sDate.Replace(".", string.Empty);
            char[] t = sDate.ToCharArray();
            nr.n1 = (int)char.GetNumericValue(t[0]);
            nr.n2 = (int)char.GetNumericValue(t[1]);
            nr.n3 = (int)char.GetNumericValue(t[2]);
            nr.n4 = (int)char.GetNumericValue(t[3]);
            nr.n5 = (int)char.GetNumericValue(t[4]);
            nr.n6 = (int)char.GetNumericValue(t[5]);
            nr.n7 = (int)char.GetNumericValue(t[6]);
            nr.n8 = (int)char.GetNumericValue(t[7]);

            return nr;
        }
        //Сумма трех трок(8) (Только для КЗ)
        public static NumericRow SumNum(NumericRow nr1, NumericRow nr2, NumericRow nr3)
        {
            NumericRow nr = new NumericRow(0);
            nr.n1 = nr1.n1 + nr2.n1 + nr3.n1;
            nr.n2 = nr1.n2 + nr2.n2 + nr3.n2;
            nr.n3 = nr1.n3 + nr2.n3 + nr3.n3;
            nr.n4 = nr1.n4 + nr2.n4 + nr3.n4;
            nr.n5 = nr1.n5 + nr2.n5 + nr3.n5;
            nr.n6 = nr1.n6 + nr2.n6 + nr3.n6;
            nr.n7 = nr1.n7 + nr2.n7 + nr3.n7;
            nr.n8 = nr1.n8 + nr2.n8 + nr3.n8;
            return nr;
        }
        //Метод высчитывания по сумме
        public static int GetSum(int i)
        {
            string s;
            s = i.ToString();
            char[] c = s.ToCharArray();
            int sum = 0;
            foreach (char ch in c)
            {
                sum += (int)char.GetNumericValue(ch);
            }
            i = sum;
            return i;
        }
        //Метод высчитывания по псевдосумме
        public static int GetFakeSum(int i)
        {
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
        //Из эксель в пдф
        public static bool ExportWorkbookToPdf(string workbookPath, string outputPath)
        {
            // If either required string is null or empty, stop and bail out
            if (string.IsNullOrEmpty(workbookPath) || string.IsNullOrEmpty(outputPath))
            {
                return false;
            }

            // Create COM Objects
            Microsoft.Office.Interop.Excel.Application excelApplication;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook;

            // Create new instance of Excel
            excelApplication = new Microsoft.Office.Interop.Excel.Application();

            // Make the process invisible to the user
            excelApplication.ScreenUpdating = false;

            // Make the process silent
            excelApplication.DisplayAlerts = false;

            // Open the workbook that you wish to export to PDF
            excelWorkbook = excelApplication.Workbooks.Open(workbookPath);

            // If the workbook failed to open, stop, clean up, and bail out
            if (excelWorkbook == null)
            {
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;

                return false;
            }

            var exportSuccessful = true;
            try
            {
                // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
                excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputPath);
            }
            catch (System.Exception ex)
            {
                // Mark the export as failed for the return value...
                exportSuccessful = false;

                // Do something with any exceptions here, if you wish...
                // MessageBox.Show...        
            }
            finally
            {
                // Close the workbook, quit the Excel, and clean up regardless of the results...
                excelWorkbook.Close();
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;
            }

            // You can use the following method to automatically open the PDF after export if you wish
            // Make sure that the file actually exists first...
            if (System.IO.File.Exists(outputPath))
            {
                System.Diagnostics.Process.Start(outputPath);
            }

            return exportSuccessful;
        }
        //Из даты в жизненный код
        public static int GetLC(DateTime dt)
        {
            string s = dt.ToShortDateString();
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
        //Из даты в жизненный код(6)
        public static NumericRow6 GetLC6(DateTime dt)
        {
            NumericRow6 nr6 = new NumericRow6(0);
            string s = dt.ToShortDateString();
            s = s.Replace(".", string.Empty);
            var c = s.ToCharArray();
            char[] ch1 = new char[2] { c[0], c[1] };
            char[] ch2 = new char[2] { c[2], c[3] };
            char[] ch3 = new char[4] { c[4], c[5], c[6], c[7] };
            string s1 = new string(ch1);
            string s2 = new string(ch2);
            string s3 = new string(ch3);
            int i = Convert.ToInt32(s1) * Convert.ToInt32(s2) * Convert.ToInt32(s3);
            while (i < 100000)
            {
                i *= 10;
            }
            var chc = i.ToString().ToCharArray();
            nr6.n1 = (int)char.GetNumericValue(chc[0]);
            nr6.n2 = (int)char.GetNumericValue(chc[1]);
            nr6.n3 = (int)char.GetNumericValue(chc[2]);
            nr6.n4 = (int)char.GetNumericValue(chc[3]);
            nr6.n5 = (int)char.GetNumericValue(chc[4]);
            nr6.n6 = (int)char.GetNumericValue(chc[5]);
            return nr6;
        }
        //Из даты в жизненный код(8)
        public static NumericRow7 GetLC7(DateTime dt)
        {
            NumericRow7 nr7 = new NumericRow7(0);
            string s = dt.ToShortDateString();
            s = s.Replace(".", string.Empty);
            var c = s.ToCharArray();
            char[] ch1 = new char[2] { c[0], c[1] };
            char[] ch2 = new char[2] { c[2], c[3] };
            char[] ch3 = new char[4] { c[4], c[5], c[6], c[7] };
            string s1 = new string(ch1);
            string s2 = new string(ch2);
            string s3 = new string(ch3);
            int i = Convert.ToInt32(s1) * Convert.ToInt32(s2) * Convert.ToInt32(s3);
            while (i < 1000000)
            {
                i *= 10;
            }
            var chc = i.ToString().ToCharArray();
            nr7.n1 = (int)char.GetNumericValue(chc[0]);
            nr7.n2 = (int)char.GetNumericValue(chc[1]);
            nr7.n3 = (int)char.GetNumericValue(chc[2]);
            nr7.n4 = (int)char.GetNumericValue(chc[3]);
            nr7.n5 = (int)char.GetNumericValue(chc[4]);
            nr7.n6 = (int)char.GetNumericValue(chc[5]);
            nr7.n7 = (int)char.GetNumericValue(chc[6]);
            return nr7;
        }
        //Сумма из двух строк (6)
        public static NumericRow6 SumNum6(NumericRow6 nr1, NumericRow6 nr2)
        {
            var nr = new NumericRow6(0);
            nr.n1 = nr1.n1 + nr2.n1;
            nr.n2 = nr1.n2 + nr2.n2;
            nr.n3 = nr1.n3 + nr2.n3;
            nr.n4 = nr1.n4 + nr2.n4;
            nr.n5 = nr1.n5 + nr2.n5;
            nr.n6 = nr1.n6 + nr2.n6;
            return nr;
        }
        //Для семилетки, если два нуля, то минус один
        public static void OneIfDoubleNull(int i1, int i2, out int a, out int b)
        {
            if (i1 == 0 && i2 == 0)
            {
                a = -1;
                b = -1;
            }
            else
            {
                a = i1;
                b = i2;
            }

        }
        //Получить последовательность для формы
        public static Dictionary<int, string> GetSequenceForm(int dt, int n1, int n2, int n3, int n4)
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

            return d;
        }
        //Получить последовательность для рассчетов
        public static Dictionary<int, string> GetSequencecalc(int dt, int n1, int n2, int n3, int n4)
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
            sAllNum = dt.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString();
            var chA = sAllNum.ToCharArray();
            foreach (var ch in chA)
            {
                string st = ch.ToString();
                int i = (int)char.GetNumericValue(ch);
                d[i] = d[i] + st;
            }
            return d;
        }
        //метод для семилетки
        public static NumericRow12 SYMethod(DateTime dt)
        {
            var nr7 = GetLC7(dt);
            OneIfDoubleNull(nr7.n3, nr7.n4, out nr7.n3, out nr7.n4);
            OneIfDoubleNull(nr7.n4, nr7.n5, out nr7.n4, out nr7.n5);
            OneIfDoubleNull(nr7.n5, nr7.n6, out nr7.n5, out nr7.n6);
            OneIfDoubleNull(nr7.n6, nr7.n7, out nr7.n6, out nr7.n7);
            var nr12 = new NumericRow12(0);
            nr12.n1 = nr7.n1;
            nr12.n2 = nr7.n2;
            nr12.n3 = nr7.n3;
            nr12.n4 = nr7.n4;
            nr12.n5 = nr7.n5;
            nr12.n6 = nr7.n6;
            nr12.n7 = nr7.n7;
            nr12.n8 = nr7.n1;
            nr12.n9 = nr7.n2;
            nr12.n10 = nr7.n3;
            nr12.n11 = nr7.n4;
            nr12.n12 = nr7.n5;
            return nr12;
        }
        //получить число для семилетки в нужный год
        public static int SYCurrentValue(NumericRow12 nr, DateTime dt)
        {
            int age = GetAge(dt,DateTime.Now);
            switch (age)
            {
                case int n when (n < 7):
                    return nr.n1;
                case int n when (n < 14):
                    return nr.n2;
                case int n when (n < 21):
                    return nr.n3;
                case int n when (n < 28):
                    return nr.n4;
                case int n when (n < 35):
                    return nr.n5;
                case int n when (n < 42):
                    return nr.n6;
                case int n when (n < 49):
                    return nr.n7;
                case int n when (n < 56):
                    return nr.n8;
                case int n when (n < 63):
                    return nr.n9;
                case int n when (n < 70):
                    return nr.n10;
                case int n when (n < 77):
                    return nr.n11;
                case int n when (n < 84):
                    return nr.n12;
                default: throw new Exception("Для такого возраста не существует значения");
            }
        }
    }
}
