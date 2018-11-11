using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Numeric
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Календарь зачатия (KZ)
        private void KZButton_Click(object sender, RoutedEventArgs e)
        {
            //KZtb1.Text = "25.4.2018";
            //KZtb2.Text = "25.4.2018";
            
            DateTime dt1;
            DateTime dt2;
            bool IsDate1 = DateTime.TryParse(KZtb1.Text,out dt1);
            bool IsDate2 = DateTime.TryParse(KZtb2.Text, out dt2);
            //GetSequence(dt1);
            int res;
            bool isInt = Int32.TryParse(KZtb3.Text, out res);
            if (isInt)
            {
                if (IsDate1 && IsDate2)
                {
                    var nr1 = GetRow(dt1);
                    var nr2 = GetRow(dt2);
                    var nr3 = new NumericRow(GetFakeSum(res));
                    var sumNr = SumNum(nr1, nr2, nr3);
                    var Nr12 = new NumericRow12(0);
                    Nr12.n1 = GetFakeSum(sumNr.n1);
                    Nr12.n2 = GetFakeSum(sumNr.n2);
                    Nr12.n3 = GetFakeSum(sumNr.n3);
                    Nr12.n4 = GetFakeSum(sumNr.n4);
                    Nr12.n5 = GetFakeSum(sumNr.n5);
                    Nr12.n6 = GetFakeSum(sumNr.n6);
                    Nr12.n7 = GetFakeSum(sumNr.n7);
                    Nr12.n8 = GetFakeSum(sumNr.n8);
                    Nr12.n9 = GetFakeSum(sumNr.n1);
                    Nr12.n10 = GetFakeSum(sumNr.n2);
                    Nr12.n11 = GetFakeSum(sumNr.n3);
                    Nr12.n12 = GetFakeSum(sumNr.n4);
                    try
                    {
                        string pathEx = @"C:\Test\Test.xlsx";
                        string pathPdf = string.Format(@"C:\Test\{0}.pdf",KZtbF.Text);
                        
                        for (int i = 1; i < Int32.MaxValue; i++)
                        {
                            if (!IsExists(pathPdf))
                            {
                                break;
                            }
                            pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", KZtbF.Text, i.ToString());
                        }
                        
                        Excel excel = new Excel(pathEx, 1);
                        //MessageBox.Show(excel.ReadCell(0, 0));
                        excel.WriteToCell(4, 1, Nr12.n1.ToString());
                        excel.WriteToCell(5, 1, Nr12.n2.ToString());
                        excel.WriteToCell(6, 1, Nr12.n3.ToString());
                        excel.WriteToCell(7, 1, Nr12.n4.ToString());
                        excel.WriteToCell(8, 1, Nr12.n5.ToString());
                        excel.WriteToCell(9, 1, Nr12.n6.ToString());
                        excel.WriteToCell(10, 1, Nr12.n7.ToString());
                        excel.WriteToCell(11, 1, Nr12.n8.ToString());
                        excel.WriteToCell(12, 1, Nr12.n9.ToString());
                        excel.WriteToCell(13, 1, Nr12.n10.ToString());
                        excel.WriteToCell(14, 1, Nr12.n11.ToString());
                        excel.WriteToCell(15, 1, Nr12.n12.ToString());
                        excel.WriteToCell(0,1,KZtbF.Text);
                        excel.WriteToCell(1, 1, KZtb1.Text);
                        excel.Save();
                        excel.Close();
                        ExportWorkbookToPdf(pathEx, pathPdf);
                        MessageBox.Show(string.Format( "Файл {0} успешно создан", pathPdf));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy");
                }
            }
            else
            {
                MessageBox.Show("Год не является целым числом");
            }

            
        }
        //Финансовый календарь (F)
        private void FButton_Click(object sender, RoutedEventArgs e)
        {
            //Ftb1.Text = "14.04.1994";
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(Ftb1.Text, out dt1);
            int res;
            bool isInt = Int32.TryParse(Ftb4.Text, out res);
            if (isInt)
            {
                if (IsDate1)
                {
                    var t = GetLC6(dt1);
                    var t2 = GetLC6(dt1);
                    var t3 = GetLC6(dt1);
                    int iY = Ftb3.Text.Length - Ftb2.Text.Length;
                    if (iY < 0)
                        iY = 0;
                    var tY = new NumericRow6(GetFakeSum(Convert.ToInt32(Ftb4.Text)));
                    var tSum = SumNum6(t, t2);
                    tSum = SumNum6(tSum, t3);
                    tSum = SumNum6(tSum, tY);
                    var nr12 = new NumericRow12(0);
                    nr12.n1 = GetFakeSum(tSum.n1);
                    nr12.n2 = GetFakeSum(tSum.n2);
                    nr12.n3 = GetFakeSum(tSum.n3);
                    nr12.n4 = GetFakeSum(tSum.n4);
                    nr12.n5 = GetFakeSum(tSum.n5);
                    nr12.n6 = GetFakeSum(tSum.n6);
                    nr12.n7 = iY;
                    nr12.n8 = GetFakeSum(tSum.n1);
                    nr12.n9 = GetFakeSum(tSum.n2);
                    nr12.n10 = GetFakeSum(tSum.n3);
                    nr12.n11 = GetFakeSum(tSum.n4);
                    nr12.n12 = GetFakeSum(tSum.n5);
                    try
                    {
                        string pathEx = @"C:\Test\FTest.xlsx";
                        string pathPdf = string.Format(@"C:\Test\{0}.pdf", FtbF.Text);

                        for (int i = 1; i < Int32.MaxValue; i++)
                        {
                            if (!IsExists(pathPdf))
                            {
                                break;
                            }
                            pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", FtbF.Text, i.ToString());
                        }

                        Excel excel = new Excel(pathEx, 1);
                        excel.WriteToCell(4, 1, nr12.n1.ToString());
                        excel.WriteToCell(5, 1, nr12.n2.ToString());
                        excel.WriteToCell(6, 1, nr12.n3.ToString());
                        excel.WriteToCell(7, 1, nr12.n4.ToString());
                        excel.WriteToCell(8, 1, nr12.n5.ToString());
                        excel.WriteToCell(9, 1, nr12.n6.ToString());
                        excel.WriteToCell(10, 1, nr12.n7.ToString());
                        excel.WriteToCell(11, 1, nr12.n8.ToString());
                        excel.WriteToCell(12, 1, nr12.n9.ToString());
                        excel.WriteToCell(13, 1, nr12.n10.ToString());
                        excel.WriteToCell(14, 1, nr12.n11.ToString());
                        excel.WriteToCell(15, 1, nr12.n12.ToString());
                        excel.WriteToCell(0, 1, FtbF.Text);
                        excel.WriteToCell(1, 1, Ftb1.Text);
                        excel.Save();
                        excel.Close();
                        ExportWorkbookToPdf(pathEx, pathPdf);
                        MessageBox.Show(string.Format("Файл {0} успешно создан", pathPdf));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy");
                }
            }
            else
            {
                MessageBox.Show("Год не является целым числом");
            }
        }
        //Семилетка (SY)
        private void SYButton_Click(object sender, RoutedEventArgs e)
        {
            //SYtb1.Text = "14.04.1994";
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(SYtb1.Text, out dt1);
            if (IsDate1)
            {
                var nr12 = SYMethod(dt1);

                try
                {
                    string pathEx = @"C:\Test\SYTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", SYtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", SYtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);
                    excel.WriteToCell(4, 1, nr12.n1.ToString());
                    excel.WriteToCell(5, 1, nr12.n2.ToString());
                    excel.WriteToCell(6, 1, nr12.n3.ToString());
                    excel.WriteToCell(7, 1, nr12.n4.ToString());
                    excel.WriteToCell(8, 1, nr12.n5.ToString());
                    excel.WriteToCell(9, 1, nr12.n6.ToString());
                    excel.WriteToCell(10, 1, nr12.n7.ToString());
                    excel.WriteToCell(11, 1, nr12.n8.ToString());
                    excel.WriteToCell(12, 1, nr12.n9.ToString());
                    excel.WriteToCell(13, 1, nr12.n10.ToString());
                    excel.WriteToCell(14, 1, nr12.n11.ToString());
                    excel.WriteToCell(15, 1, nr12.n12.ToString());
                    excel.WriteToCell(0, 1, SYtbF.Text);
                    excel.WriteToCell(1, 1, SYtb1.Text);
                    excel.Save();
                    excel.Close();
                    ExportWorkbookToPdf(pathEx, pathPdf);
                    MessageBox.Show(string.Format("Файл {0} успешно создан", pathPdf));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy");
            }
        }
        //Матрица пифагора(MP)
        private void MPButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(MPtb1.Text, out dt1);
            if (IsDate1)
            {
                var nr8 = GetRow(dt1);
                string s = nr8.n1.ToString() + nr8.n2.ToString() + nr8.n3.ToString() + nr8.n4.ToString() + nr8.n5.ToString() + nr8.n6.ToString() + nr8.n7.ToString() + nr8.n8.ToString();
                int numOfFate = GetFakeSum(Convert.ToInt32(s));
                int LC = GetLC(dt1);
                int firstNum = nr8.n1 + nr8.n2 + nr8.n3 + nr8.n4 + nr8.n5 + nr8.n6 + nr8.n7 + nr8.n8;
                int secondNum = GetFakeSum(firstNum);
                int cnt;
                if (nr8.n1 != 0)
                    cnt = 2 * nr8.n1;
                else
                    cnt = 2 * nr8.n2;
                int thirdNum = firstNum - cnt;
                int fourthNum = GetFakeSum(thirdNum);
                int addingNum;
                if (dt1.Year > 1999)
                {
                    addingNum = dt1.Year - dt1.Day - dt1.Month - firstNum - secondNum - thirdNum - fourthNum;
                }
                else
                    addingNum = 0;
                var d = GetSequenceForm(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum, addingNum);
                var d2 = GetSequenceForm(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum, addingNum);
                var nr12 = SYMethod(dt1);
                try
                {
                    string pathEx = @"C:\Test\MPTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);
                    excel.WriteToCell(0, 1, MPtbF.Text);
                    excel.WriteToCell(1, 1, MPtb1.Text);
                    excel.WriteToCell(2, 1, numOfFate.ToString());
                    excel.WriteToCell(2, 3, LC.ToString());
                    excel.WriteToCell(4, 1, firstNum.ToString());
                    excel.WriteToCell(4,2, secondNum.ToString());
                    excel.WriteToCell(5, 1, thirdNum.ToString());
                    excel.WriteToCell(5, 2, fourthNum.ToString());

                    excel.WriteToCell(7, 0, d[1]!=""?d[1]:"нет");
                    excel.WriteToCell(9, 0, d[2] != "" ? d[2] : "нет");
                    excel.WriteToCell(11, 0, d[3] != "" ? d[3] : "нет");
                    excel.WriteToCell(7, 1, d[4] != "" ? d[4] : "нет");
                    excel.WriteToCell(9, 1, d[5] != "" ? d[5] : "нет");
                    excel.WriteToCell(11, 1, d[6] != "" ? d[6] : "нет");
                    excel.WriteToCell(7, 2, d[7] != "" ? d[7] : "нет");
                    excel.WriteToCell(9, 2, d[8] != "" ? d[8] : "нет");
                    excel.WriteToCell(11, 2, d[9] != "" ? d[9] : "нет");

                    excel.WriteToCell(5, 3, (d2[3].Length+ d2[5].Length + d2[7].Length).ToString());
                    excel.WriteToCell(7, 3, (d2[1].Length + d2[4].Length + d2[7].Length).ToString());
                    excel.WriteToCell(9, 3, (d2[2].Length + d2[5].Length + d2[8].Length).ToString());
                    excel.WriteToCell(11, 3, (d2[3].Length + d2[6].Length + d2[9].Length).ToString());
                    excel.WriteToCell(13, 0, (d2[1].Length + d2[2].Length + d2[3].Length).ToString());
                    excel.WriteToCell(13, 1, (d2[4].Length + d2[5].Length + d2[6].Length).ToString());
                    excel.WriteToCell(13, 2, (d2[7].Length + d2[8].Length + d2[9].Length).ToString());
                    excel.WriteToCell(13, 3, (d2[1].Length + d2[5].Length + d2[9].Length).ToString());

                    excel.WriteToCell(15, 1, nr12.n1.ToString());
                    excel.WriteToCell(16, 1, nr12.n2.ToString());
                    excel.WriteToCell(17, 1, nr12.n3.ToString());
                    excel.WriteToCell(18, 1, nr12.n4.ToString());
                    excel.WriteToCell(19, 1, nr12.n5.ToString());
                    excel.WriteToCell(20, 1, nr12.n6.ToString());
                    excel.WriteToCell(21, 1, nr12.n7.ToString());
                    excel.WriteToCell(22, 1, nr12.n8.ToString());
                    excel.WriteToCell(23, 1, nr12.n9.ToString());
                    excel.WriteToCell(24, 1, nr12.n10.ToString());
                    excel.WriteToCell(25, 1, nr12.n11.ToString());
                    excel.WriteToCell(26, 1, nr12.n12.ToString());

                    excel.Save();
                    excel.Close();
                    ExportWorkbookToPdf(pathEx, pathPdf);
                    MessageBox.Show(string.Format("Файл {0} успешно создан", pathPdf));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy");
            }
        }
        //Метод существование файла
        public bool IsExists(string s)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");
            var f = dir.GetFiles();
            foreach (var t in f)
            {
                if (t.FullName.ToString()==s)
                {
                    return true;
                }
            }
            return false;
        }
        //Из даты в строку
        public NumericRow GetRow(DateTime dt)
        {
            var nr = new NumericRow(0);
            string sDate = dt.ToString();
            sDate = sDate.Replace(".", string.Empty);
            char [] t = sDate.ToCharArray();
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
        public NumericRow SumNum(NumericRow nr1,NumericRow nr2,NumericRow nr3)
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
        //Метод высчитывания по псевдосумме
        public int GetFakeSum(int i)
        {
            string s;
            while (i >= 10)
                {
                    s= i.ToString();
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
        public bool ExportWorkbookToPdf(string workbookPath, string outputPath)
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
        public int GetLC(DateTime dt)
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
            
            return i;
        }
        //Из даты в жизненный код(6)
        public NumericRow6 GetLC6(DateTime dt)
        {
            NumericRow6 nr6 = new NumericRow6(0);
            string s = dt.ToShortDateString();
            s = s.Replace(".",string.Empty);
            var c = s.ToCharArray();
            char[] ch1 = new char[2] { c[0],c[1]};
            char[] ch2 = new char[2] { c[2], c[3] };
            char[] ch3 = new char[4] { c[4], c[5], c[6], c[7] };
            string s1 = new string(ch1);
            string s2 = new string(ch2);
            string s3 = new string(ch3);
            int i = Convert.ToInt32(s1)*Convert.ToInt32(s2)* Convert.ToInt32(s3);
            while (i<100000)
            {
                i *= 10;
            }
            var chc = i.ToString().ToCharArray();
            nr6.n1= (int)char.GetNumericValue(chc[0]);
            nr6.n2 = (int)char.GetNumericValue(chc[1]);
            nr6.n3 = (int)char.GetNumericValue(chc[2]);
            nr6.n4 = (int)char.GetNumericValue(chc[3]);
            nr6.n5 = (int)char.GetNumericValue(chc[4]);
            nr6.n6 = (int)char.GetNumericValue(chc[5]);
            return nr6;
        }
        //Из даты в жизненный код(8)
        public NumericRow7 GetLC7(DateTime dt)
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
        public NumericRow6 SumNum6(NumericRow6 nr1, NumericRow6 nr2)
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
        public void OneIfDoubleNull(int i1, int i2, out int a, out int b)
        {
            if (i1==0 && i2==0)
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
        public Dictionary<int, string> GetSequenceForm(int dt, int n1, int n2,int n3,int n4,int ad)
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

            if (ad!=0)
            {
                string sAdd = ad.ToString();
                chA = sAdd.ToCharArray();
                foreach (var ch in chA)
                {
                    string st = ch.ToString();
                    int i = (int)char.GetNumericValue(ch);
                    d[i] = d[i] + $"({st})";
                }
            }

            return d;
        }
        //Получить последовательность для рассчетов
        public Dictionary<int, string> GetSequencecalc(int dt, int n1, int n2, int n3, int n4, int ad)
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
            sAllNum = dt.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString()+ad.ToString();
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
        public NumericRow12  SYMethod(DateTime dt)
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

    }
}
