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
            bool IsDate1 = DateTime.TryParse(KZtb1.Text, out dt1);
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
                        string pathPdf = string.Format(@"C:\Test\{0}.pdf", KZtbF.Text);

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
                        excel.WriteToCell(0, 1, KZtbF.Text);
                        excel.WriteToCell(1, 1, KZtb1.Text);

                        var del = 33;
                        for (int h = 0; h < 10; h++)
                        {
                            excel.Hide(del + h);
                        }
                        foreach (var nt in GetWithoutDublicate12(Nr12))
                        {
                            excel.Unhide(del + nt);
                        }

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
                        var del = 33;
                        for (int h = 0; h < 10; h++)
                        {
                            excel.Hide(del + h);
                        }
                        foreach (var nt in GetWithoutDublicate12(nr12))
                        {
                            excel.Unhide(del + nt);
                        }

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

                    var del = 31;
                    for (int h = -1; h < 10; h++)
                    {
                        excel.Hide(del + h);
                    }
                    foreach (var nt in GetWithoutDublicate12(nr12))
                    {
                        excel.Unhide(del + nt);
                    }

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
                var d2 = GetSequencecalc(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum, addingNum);

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

                    excel.WriteToCell(3, 2, firstNum.ToString());
                    excel.WriteToCell(3, 3, secondNum.ToString());
                    excel.WriteToCell(4, 2, thirdNum.ToString());
                    excel.WriteToCell(4, 3, fourthNum.ToString());


                    excel.WriteToCell(6, 0, d[1] != "" ? d[1] : "нет");
                    excel.WriteToCell(8, 0, d[2] != "" ? d[2] : "нет");
                    excel.WriteToCell(10, 0, d[3] != "" ? d[3] : "нет");
                    excel.WriteToCell(6, 1, d[4] != "" ? d[4] : "нет");
                    excel.WriteToCell(8, 1, d[5] != "" ? d[5] : "нет");
                    excel.WriteToCell(10, 1, d[6] != "" ? d[6] : "нет");
                    excel.WriteToCell(6, 2, d[7] != "" ? d[7] : "нет");
                    excel.WriteToCell(8, 2, d[8] != "" ? d[8] : "нет");
                    excel.WriteToCell(10, 2, d[9] != "" ? d[9] : "нет");

                    var del = 13;
                    for (int h = 0; h < 10; h++)
                    {
                        excel.Hide(del + h);
                    }
                    excel.Unhide(del + numOfFate - 1);
                    string fs = $"{firstNum}.{secondNum}";
                    string tf = $"{thirdNum}.{fourthNum}";

                    for (int i = 24; i < 63; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == fs)
                            excel.Unhide(i + 1);
                    }
                    for (int i = 62; i < 100; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == tf)
                            excel.Unhide(i + 1);
                    }
                    string SecSkill1 = GetNumSecSkill(d2[3], d2[5], d2[7]);
                    string SecSkill2 = GetNumSecSkill(d2[1], d2[4], d2[7]);
                    string SecSkill3 = GetNumSecSkill(d2[2], d2[5], d2[8]);
                    string SecSkill4 = GetNumSecSkill(d2[3], d2[6], d2[9]);
                    string SecSkill5 = GetNumSecSkill(d2[1], d2[2], d2[3]);
                    string SecSkill6 = GetNumSecSkill(d2[4], d2[5], d2[6]);
                    string SecSkill7 = GetNumSecSkill(d2[7], d2[8], d2[9]);
                    string SecSkill8 = GetNumSecSkill(d2[1], d2[5], d2[9]);

                    for (int i = 101; i < 111; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill1)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 112; i < 122; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill2)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 123; i < 133; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill3)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 134; i < 144; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill4)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 145; i < 155; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill5)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 156; i < 166; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill6)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 167; i < 177; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill7)
                            excel.Unhide(i + 1);
                    }

                    for (int i = 178; i < 188; i++)
                    {
                        excel.Hide(i + 1);
                        if (excel.ReadCell(i, 4) == SecSkill8)
                            excel.Unhide(i + 1);
                    }

                    d2[1] = d2[1] == "" ? "(-1)" : d2[1];
                    d2[2] = d2[2] == "" ? "(-2)" : d2[2];
                    d2[3] = d2[3] == "" ? "(-3)" : d2[3];
                    d2[4] = d2[4] == "" ? "(-4)" : d2[4];
                    d2[5] = d2[5] == "" ? "(-5)" : d2[5];
                    d2[6] = d2[6] == "" ? "(-6)" : d2[6];
                    d2[7] = d2[7] == "" ? "(-7)" : d2[7];
                    d2[8] = d2[8] == "" ? "(-8)" : d2[8];
                    d2[9] = d2[9] == "" ? "(-9)" : d2[9];


                    string all = $"{d2[1]}/{d2[2]}/{d2[3]}/{d2[4]}/{d2[5]}/{d2[6]}/{d2[7]}/{d2[8]}/{d2[9]}/Те{SecSkill1}/Це{SecSkill2}/Се{SecSkill3}/Ст{SecSkill4}/Са{SecSkill5}/Бы{SecSkill6}/Та{SecSkill7}/Ду{SecSkill8}/ЧС{numOfFate}";
                    for (int i = 190; i < 2700; i++)
                    {
                        excel.Hide(i);

                        if (hideRowMatch(excel.ReadCell(i - 1, 4), all, i))
                            excel.Unhide(i);
                    }

                    excel.HideCol(5);

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
        //56 судеб (SU)
        private void SUButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            DateTime dt2;
            DateTime dt3;
            DateTime last;
            int a;

            bool IsDate1 = DateTime.TryParse(SUtb1.Text, out dt1);
            bool IsDate2 = DateTime.TryParse(SUtF.Text, out dt2);
            bool IsDate3 = DateTime.TryParse(SUtM.Text, out dt3);
            bool isInt1 = Int32.TryParse(SUtb3.Text, out a);
            bool isInt2 = Int32.TryParse(SUtb4.Text, out a);
            if (0 < a && a < 13)
            {
                if (isInt1 && isInt2)
                {
                    if (IsDate1 && IsDate2)
                    {
                        var dt4 = new DateTime(2000, Convert.ToInt32(SUtb4.Text), 1);
                        int i = dt1.Day + 5;
                        DateTime first = new DateTime(dt4.Year, dt4.Month, 1);
                        if (dt4.Month==12)
                        {
                            last = new DateTime(dt4.Year, 1, 1).AddDays(-1);
                        }
                        else
                        {
                            last = new DateTime(dt4.Year, dt4.Month + 1, 1).AddDays(-1);
                        }
                        
                        if (i > last.Day)
                            i = i - last.Day;
                        string s1 = "";
                        string s2 = "";
                        string s3 = "";
                        string s4 = "";
                        string s5 = "";
                        string s6 = "";
                        int t = last.Day;
                        s1 = GetFiveNums(s1, 5, last.Day, i, out i);
                        t -= 5;
                        s2 = GetFiveNums(s2, 5, last.Day, i, out i);
                        t -= 5;
                        s3 = GetFiveNums(s3, 5, last.Day, i, out i);
                        t -= 5;
                        s4 = GetFiveNums(s4, 5, last.Day, i, out i);
                        t -= 5;
                        s5 = GetFiveNums(s5, 5, last.Day, i, out i);
                        t -= 5;
                        s6 = GetFiveNums(s6, t, last.Day, i, out i);
                        int YearValue = GetSum(Convert.ToInt32(SUtb3.Text));
                        var nr6cell1 = new NumericRow6(YearValue);
                        string con = GetConstMonth(SUtb4.Text);
                        var nr6cell2 = new NumericRow6(Convert.ToInt32(con));
                        var nr6cell3 = new NumericRow6(0);
                        nr6cell3.n1 = dt1.Day;
                        nr6cell3.n2 = dt1.Month;
                        nr6cell3.n3 = dt1.Year / 1000;
                        nr6cell3.n4 = dt1.Year / 100 % 10;
                        nr6cell3.n5 = dt1.Year / 10 % 10 % 10;
                        nr6cell3.n6 = dt1.Year % 10;
                        var nr6cell4 = GetLC6(dt1);
                        var nr6cell4M = GetLC6(dt3);
                        var nr6cell5 = AddNullsTo6(dt1.Year / 100 % 10 * dt1.Month * dt1.Day);
                        var nr6cell5M = AddNullsTo6(dt3.Year / 100 % 10 * dt3.Month * dt3.Day);
                        var nr6cell6 = GetLC6(dt2);
                        var nr6cell7Sum = new NumericRow6(0);
                        nr6cell7Sum.n1 = nr6cell1.n1 + nr6cell2.n1 + nr6cell3.n1 + nr6cell4.n1 + nr6cell5.n1 + nr6cell6.n1;
                        nr6cell7Sum.n2 = nr6cell1.n2 + nr6cell2.n2 + nr6cell3.n2 + nr6cell4.n2 + nr6cell5.n2 + nr6cell6.n2;
                        nr6cell7Sum.n3 = nr6cell1.n3 + nr6cell2.n3 + nr6cell3.n3 + nr6cell4.n3 + nr6cell5.n3 + nr6cell6.n3;
                        nr6cell7Sum.n4 = nr6cell1.n4 + nr6cell2.n4 + nr6cell3.n4 + nr6cell4.n4 + nr6cell5.n4 + nr6cell6.n4;
                        nr6cell7Sum.n5 = nr6cell1.n5 + nr6cell2.n5 + nr6cell3.n5 + nr6cell4.n5 + nr6cell5.n5 + nr6cell6.n5;
                        nr6cell7Sum.n6 = nr6cell1.n6 + nr6cell2.n6 + nr6cell3.n6 + nr6cell4.n6 + nr6cell5.n6 + nr6cell6.n6;

                        var nr6cell7SumM = new NumericRow6(0);
                        nr6cell7SumM.n1 = nr6cell1.n1 + nr6cell2.n1 + nr6cell3.n1 + nr6cell4M.n1 + nr6cell5M.n1;
                        nr6cell7SumM.n2 = nr6cell1.n2 + nr6cell2.n2 + nr6cell3.n2 + nr6cell4M.n2 + nr6cell5M.n2;
                        nr6cell7SumM.n3 = nr6cell1.n3 + nr6cell2.n3 + nr6cell3.n3 + nr6cell4M.n3 + nr6cell5M.n3;
                        nr6cell7SumM.n4 = nr6cell1.n4 + nr6cell2.n4 + nr6cell3.n4 + nr6cell4M.n4 + nr6cell5M.n4;
                        nr6cell7SumM.n5 = nr6cell1.n5 + nr6cell2.n5 + nr6cell3.n5 + nr6cell4M.n5 + nr6cell5M.n5;
                        nr6cell7SumM.n6 = nr6cell1.n6 + nr6cell2.n6 + nr6cell3.n6 + nr6cell4M.n6 + nr6cell5M.n6;
                        try
                        {
                            string pathEx = @"C:\Test\SUTest.xlsx";
                            string pathPdf = string.Format(@"C:\Test\{0}.pdf", SUtbF.Text);

                            for (int iv = 1; iv < Int32.MaxValue; iv++)
                            {
                                if (!IsExists(pathPdf))
                                {
                                    break;
                                }
                                pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", SUtbF.Text, iv.ToString());
                            }



                            Excel excel = new Excel(pathEx, 1);
                            excel.WriteToCell(1, 0, SUtbF.Text);

                            excel.WriteToCell(4, 0, s1);
                            excel.WriteToCell(5, 0, s2);
                            excel.WriteToCell(6, 0, s3);
                            excel.WriteToCell(7, 0, s4);
                            excel.WriteToCell(8, 0, s5);
                            excel.WriteToCell(9, 0, s6);

                            excel.WriteToCell(4, 1, nr6cell1.n1.ToString());
                            excel.WriteToCell(5, 1, nr6cell1.n2.ToString());
                            excel.WriteToCell(6, 1, nr6cell1.n3.ToString());
                            excel.WriteToCell(7, 1, nr6cell1.n4.ToString());
                            excel.WriteToCell(8, 1, nr6cell1.n5.ToString());
                            excel.WriteToCell(9, 1, nr6cell1.n6.ToString());

                            excel.WriteToCell(4, 2, nr6cell2.n1.ToString());
                            excel.WriteToCell(5, 2, nr6cell2.n2.ToString());
                            excel.WriteToCell(6, 2, nr6cell2.n3.ToString());
                            excel.WriteToCell(7, 2, nr6cell2.n4.ToString());
                            excel.WriteToCell(8, 2, nr6cell2.n5.ToString());
                            excel.WriteToCell(9, 2, nr6cell2.n6.ToString());

                            excel.WriteToCell(4, 3, nr6cell3.n1.ToString());
                            excel.WriteToCell(5, 3, nr6cell3.n2.ToString());
                            excel.WriteToCell(6, 3, nr6cell3.n3.ToString());
                            excel.WriteToCell(7, 3, nr6cell3.n4.ToString());
                            excel.WriteToCell(8, 3, nr6cell3.n5.ToString());
                            excel.WriteToCell(9, 3, nr6cell3.n6.ToString());

                            excel.WriteToCell(4, 4, nr6cell4.n1.ToString());
                            excel.WriteToCell(5, 4, nr6cell4.n2.ToString());
                            excel.WriteToCell(6, 4, nr6cell4.n3.ToString());
                            excel.WriteToCell(7, 4, nr6cell4.n4.ToString());
                            excel.WriteToCell(8, 4, nr6cell4.n5.ToString());
                            excel.WriteToCell(9, 4, nr6cell4.n6.ToString());

                            excel.WriteToCell(4, 5, nr6cell5.n1.ToString());
                            excel.WriteToCell(5, 5, nr6cell5.n2.ToString());
                            excel.WriteToCell(6, 5, nr6cell5.n3.ToString());
                            excel.WriteToCell(7, 5, nr6cell5.n4.ToString());
                            excel.WriteToCell(8, 5, nr6cell5.n5.ToString());
                            excel.WriteToCell(9, 5, nr6cell5.n6.ToString());

                            excel.WriteToCell(4, 6, nr6cell6.n1.ToString());
                            excel.WriteToCell(5, 6, nr6cell6.n2.ToString());
                            excel.WriteToCell(6, 6, nr6cell6.n3.ToString());
                            excel.WriteToCell(7, 6, nr6cell6.n4.ToString());
                            excel.WriteToCell(8, 6, nr6cell6.n5.ToString());
                            excel.WriteToCell(9, 6, nr6cell6.n6.ToString());

                            excel.WriteToCell(4, 7, TransSU(nr6cell7Sum.n1));
                            excel.WriteToCell(5, 7, TransSU(nr6cell7Sum.n2));
                            excel.WriteToCell(6, 7, TransSU(nr6cell7Sum.n3));
                            excel.WriteToCell(7, 7, TransSU(nr6cell7Sum.n4));
                            excel.WriteToCell(8, 7, TransSU(nr6cell7Sum.n5));
                            excel.WriteToCell(9, 7, TransSU(nr6cell7Sum.n6));

                            var del = 11;
                            for (int h = 0; h < 57; h++)
                            {
                                excel.Hide(del + h);
                            }
                            foreach (var nt in GetWithoutDublicate6(nr6cell7Sum))
                            {
                                excel.Unhide(del + nt);
                            }

                            excel.WriteToCell(69, 0, s1);
                            excel.WriteToCell(70, 0, s2);
                            excel.WriteToCell(71, 0, s3);
                            excel.WriteToCell(72, 0, s4);
                            excel.WriteToCell(73, 0, s5);
                            excel.WriteToCell(74, 0, s6);

                            excel.WriteToCell(69, 1, nr6cell1.n1.ToString());
                            excel.WriteToCell(70, 1, nr6cell1.n2.ToString());
                            excel.WriteToCell(71, 1, nr6cell1.n3.ToString());
                            excel.WriteToCell(72, 1, nr6cell1.n4.ToString());
                            excel.WriteToCell(73, 1, nr6cell1.n5.ToString());
                            excel.WriteToCell(74, 1, nr6cell1.n6.ToString());

                            excel.WriteToCell(69, 2, nr6cell2.n1.ToString());
                            excel.WriteToCell(70, 2, nr6cell2.n2.ToString());
                            excel.WriteToCell(71, 2, nr6cell2.n3.ToString());
                            excel.WriteToCell(72, 2, nr6cell2.n4.ToString());
                            excel.WriteToCell(73, 2, nr6cell2.n5.ToString());
                            excel.WriteToCell(74, 2, nr6cell2.n6.ToString());

                            excel.WriteToCell(69, 3, nr6cell3.n1.ToString());
                            excel.WriteToCell(70, 3, nr6cell3.n2.ToString());
                            excel.WriteToCell(71, 3, nr6cell3.n3.ToString());
                            excel.WriteToCell(72, 3, nr6cell3.n4.ToString());
                            excel.WriteToCell(73, 3, nr6cell3.n5.ToString());
                            excel.WriteToCell(74, 3, nr6cell3.n6.ToString());

                            excel.WriteToCell(69, 4, nr6cell4M.n1.ToString());
                            excel.WriteToCell(70, 4, nr6cell4M.n2.ToString());
                            excel.WriteToCell(71, 4, nr6cell4M.n3.ToString());
                            excel.WriteToCell(72, 4, nr6cell4M.n4.ToString());
                            excel.WriteToCell(73, 4, nr6cell4M.n5.ToString());
                            excel.WriteToCell(74, 4, nr6cell4M.n6.ToString());

                            excel.WriteToCell(69, 5, nr6cell5M.n1.ToString());
                            excel.WriteToCell(70, 5, nr6cell5M.n2.ToString());
                            excel.WriteToCell(71, 5, nr6cell5M.n3.ToString());
                            excel.WriteToCell(72, 5, nr6cell5M.n4.ToString());
                            excel.WriteToCell(73, 5, nr6cell5M.n5.ToString());
                            excel.WriteToCell(74, 5, nr6cell5M.n6.ToString());

                            excel.WriteToCell(69, 7, TransSU(nr6cell7SumM.n1));
                            excel.WriteToCell(70, 7, TransSU(nr6cell7SumM.n2));
                            excel.WriteToCell(71, 7, TransSU(nr6cell7SumM.n3));
                            excel.WriteToCell(72, 7, TransSU(nr6cell7SumM.n4));
                            excel.WriteToCell(73, 7, TransSU(nr6cell7SumM.n5));
                            excel.WriteToCell(74, 7, TransSU(nr6cell7SumM.n6));

                            del = 76;
                            for (int h = 0; h < 57; h++)
                            {
                                excel.Hide(del + h);
                            }
                            foreach (var nt in GetWithoutDublicate6(nr6cell7SumM))
                            {
                                excel.Unhide(del + nt);
                            }

                            //excel.HideCol(9);

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
                    MessageBox.Show("Год или номер месяца не является целым числом");
                }
            }
            else
            {
                MessageBox.Show("Значение номера месяца должно быть от 1 до 12");
            }

        }
        //Девятилетний цикл (LC)
        private void LCButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(LCtb1.Text, out dt1);
            if (IsDate1)
            {
                string s = GetSum(dt1.Day).ToString() + GetSum(dt1.Month).ToString();
                int i1 = GetFakeSum(Convert.ToInt32(s));
                int i2 = GetFakeSum(DateTime.Now.Year);
                int res = GetFakeSum(i1 + i2);
                var dic = GetDicForLC(res);

                try
                {
                    string pathEx = @"C:\Test\LCTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", LCtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", LCtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);

                    excel.WriteToCell(0, 2, LCtbF.Text);
                    excel.WriteToCell(1, 2, LCtb1.Text);
                    int del = 11;
                    for (int i = 1; i < 10; i++)
                    {
                        excel.Hide(del + i);
                    }

                    for (int i=0;i<9;i++)
                    {
                        excel.WriteToCell(9, i, "");
                    }

                    foreach (var t in dic)
                    {
                        excel.WriteToCell(9, t.Key - 1, t.Value.ToString());
                        excel.Unhide(del + t.Key);
                    }

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
        //Луна и солнце (LU)
        private void LUButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(LUtb1.Text, out dt1);
            int age = GetAge(dt1, DateTime.Now);
            if (IsDate1 || age<18)
            {
                
                var lc6 = GetLC6(dt1);
                var lc = Convert.ToInt32(lc6.n1.ToString() + lc6.n2.ToString() + lc6.n3.ToString() + lc6.n4.ToString() + lc6.n5.ToString() + lc6.n6.ToString());


                List<Lun> list = new List<Lun>();//18-years+5
                List<Lun> listh = new List<Lun>();//18
                List<int> luns = new List<int>();
                List<int> suns = new List<int>();
                List<int> sums = new List<int>();
                for (int it=18;it<age+6;it++)
                {
                    list.Add(new Lun(it, GetSun(it, lc), GetLuna(it, lc)));
                    if (it>=age)
                    {
                        listh.Add(new Lun(it, GetSun(it, lc), GetLuna(it, lc)));
                        luns.Add(GetLuna(it, lc));
                        suns.Add(GetSun(it, lc));
                        sums.Add(GetSun(it, lc) - GetLuna(it, lc));
                    }
                }
                luns.Distinct();
                suns.Distinct();
                sums.Distinct();

                //Выдающиеся года
                List<int> years = new List<int>();
                int y = dt1.Year;
                while (y<2023)
                {
                    var c = y.ToString().ToCharArray();
                    foreach (var ch in c)
                    {
                        y += (int)char.GetNumericValue(ch);
                        if (y<2023 && (int)char.GetNumericValue(ch)!=0)
                        {
                            years.Add(y);
                        }
                    }
                }

                try
                {
                    string pathEx = @"C:\Test\LUTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", LUtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", LUtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);

                    excel.WriteToCell(0, 2, LUtbF.Text);
                    excel.WriteToCell(1, 2, LUtb1.Text);

                    for (int il=6;il<69;il++)
                    {
                        excel.Hide(il);
                    }
                    
                    foreach (var l in listh)
                    {
                        excel.Unhide(l.Year - 12);
                    }
                    foreach (var l in list)
                    {
                        excel.WriteToCell(l.Year - 13, 1,l.Luna.ToString());
                        excel.WriteToCell(l.Year - 13, 2, l.Sun.ToString());
                        excel.WriteToCell(l.Year - 13, 3, TransfLun(l.Sum));
                    }

                    for (int i = 71; i < 90; i++)
                        excel.Hide(i);
                    foreach (var i in luns)
                        excel.Unhide(i+71);
                    for (int i = 92; i < 111; i++)
                        excel.Hide(i);
                    foreach (var i in suns)
                        excel.Unhide(i+92);
                    for (int i = 113; i < 150; i++)
                        excel.Hide(i);
                    foreach (var i in sums)
                        excel.Unhide(i + 131);
                    //Years
                    for (int il = 152; il < 226; il++)
                    {
                        excel.Hide(il);
                    }

                    foreach (var ya in years)
                    {
                        excel.Unhide(ya-1798);
                    }

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
                MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy или возраст клиента меньше 18");
            }
        }
        //Матричный цикл
        private void MCButton_Click(object sender, RoutedEventArgs e)
        {

            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(MCtb1.Text, out dt1);
            var dt2 = new DateTime(2020,2,29);
            dt1 = new DateTime(2020,dt1.Month, dt1.Day);
            DateTime dt3;
            if (dt2 > dt1)
                dt3 = new DateTime(2016, dt1.Month, dt1.Day );
            else
                dt3 = new DateTime(2015, dt1.Month,dt1.Day );
            if (IsDate1)
            {
                var Tdate1 = new DateTime(2016,2,29);
                var Tdate2 = Tdate1.AddDays(-52);

                DateTime mer1;
                DateTime mer;
                DateTime mer26;
                DateTime ven1;
                DateTime mar1;
                DateTime up1;
                DateTime sat1;
                DateTime ur1;
                DateTime nep1;
                DateTime ven26;
                DateTime mar26;
                DateTime up26;
                DateTime sat26;
                DateTime ur26;
                DateTime nep26;
                DateTime ven;
                DateTime mar;
                DateTime up;
                DateTime sat;
                DateTime ur;
                DateTime nep;


                bool notUpdate = true;
                if (dt3<Tdate1&&dt3>Tdate2&&notUpdate)
                {
                    mer26 = dt3.AddDays(26);
                    mer = mer26.AddDays(26);
                    ven1 = mer.AddDays(1);
                    notUpdate = false;
                }
                else
                {
                    mer26 = dt3.AddDays(25);
                    mer = mer26.AddDays(26);
                    ven1 = mer.AddDays(1);
                }
                if (ven1 < Tdate1 && ven1 > Tdate2 && notUpdate)
                {
                    ven26 = ven1.AddDays(26);
                    ven = ven26.AddDays(26);
                    mar1 = ven.AddDays(1);
                }
                else
                {
                    ven26 = ven1.AddDays(25);
                    ven = ven26.AddDays(26);
                    mar1 = ven.AddDays(1);
                }

                if (mar1 < Tdate1 && mar1 > Tdate2 && notUpdate)
                {
                    mar26 = mar1.AddDays(26);
                    mar = mar26.AddDays(26);
                    up1 = mar.AddDays(1);
                }
                else
                {
                    mar26 = mar1.AddDays(25);
                    mar = mar26.AddDays(26);
                    up1 = mar.AddDays(1);
                }

                if (up1 < Tdate1 && up1 > Tdate2 && notUpdate)
                {
                    up26 = up1.AddDays(26);
                    up = up26.AddDays(26);
                    sat1 = up.AddDays(1);
                }
                else
                {
                    up26 = up1.AddDays(25);
                    up = up26.AddDays(26);
                    sat1 = up.AddDays(1);
                }

                if (sat1 < Tdate1 && sat1 > Tdate2 && notUpdate)
                {
                    sat26 = sat1.AddDays(26);
                    sat = sat26.AddDays(26);
                    ur1 = sat.AddDays(1);
                }
                else
                {
                    sat26 = sat1.AddDays(25);
                    sat = sat26.AddDays(26);
                    ur1 = sat.AddDays(1);
                }

                if (ur1 < Tdate1 && ur1 > Tdate2 && notUpdate)
                {
                    ur26 = ur1.AddDays(26);
                    ur = ur26.AddDays(26);
                    nep1 = ur.AddDays(1);
                }
                else
                {
                    ur26 = ur1.AddDays(25);
                    ur = ur26.AddDays(26);
                    nep1 = ur.AddDays(1);
                }
                
                nep26 = nep1.AddDays(26);
                nep = nep26.AddDays(26);

                try
                {
                    string pathEx = @"C:\Test\MCTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", MCtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", MCtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);

                    excel.WriteToCell(0, 2, MCtbF.Text);
                    excel.WriteToCell(1, 2, MCtb1.Text);

                    excel.WriteToCell(3, 0, $"{dt1.ToString("dd/MM")}-{mer.ToString("dd/MM")} Меркурий; 26 день {mer26.ToString("dd/MM")}");
                    excel.WriteToCell(4, 0, $"{ven1.ToString("dd/MM")}-{ven.ToString("dd/MM")} Венера; 26 день {ven26.ToString("dd/MM")}");
                    excel.WriteToCell(5, 0, $"{mar1.ToString("dd/MM")}-{mar.ToString("dd/MM")} Марс; 26 день {mar26.ToString("dd/MM")}");
                    excel.WriteToCell(6, 0, $"{up1.ToString("dd/MM")}-{up.ToString("dd/MM")} Юпитер; 26 день {up26.ToString("dd/MM")}");
                    excel.WriteToCell(7, 0, $"{sat1.ToString("dd/MM")}-{sat.ToString("dd/MM")} Сатурн; 26 день {sat26.ToString("dd/MM")}");
                    excel.WriteToCell(8, 0, $"{ur1.ToString("dd/MM")}-{ur.ToString("dd/MM")} Уран; 26 день {ur26.ToString("dd/MM")}");
                    excel.WriteToCell(9, 0, $"{nep1.ToString("dd/MM")}-{nep.ToString("dd/MM")} Нептун; 26 день {nep26.ToString("dd/MM")}");

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
        //Карма
        private void KAButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            bool IsDate1 = DateTime.TryParse(KAtb1.Text, out dt1);
            if (IsDate1)
            {
                int it = GetFakeSum(dt1.Day+dt1.Day);

                int i1 = dt1.Day + 10 + 13;
                int i2 = GetFakeSum(dt1.Year);
                int i3 = i1 - i2;
                if (i3 > 22)
                    i3 = GetFakeSum(i3);

                try
                {
                    string pathEx = @"C:\Test\KATest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", KAtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", KAtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);

                    excel.WriteToCell(0, 2, KAtbF.Text);
                    excel.WriteToCell(1, 2, KAtb1.Text);

                    for (int i = 1; i < 10; i++)
                        excel.Hide(3 + i);

                    excel.Unhide(3 + it);

                    for (int i = 1; i < 23; i++)
                        excel.Hide(13+i);

                    excel.Unhide(13 + i3);

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
        //Если 0, то 50/50 для луны
        private string TransfLun(int i)
        {
            if (i == 0)
                return "50/50";
            else
                return i.ToString();
        }

        //Получить солнце
        private int GetSun(int age, int lc)
        {
            var ch = (lc / age).ToString().ToCharArray();
            char [] ch1 = { ch[2],ch[3]};
            int result = GetSum(Convert.ToInt32(new string(ch1)));
            return result;
        }
        //Получить луну
        private int GetLuna (int age,int lc)
        {
            var ch= (lc / age).ToString().ToCharArray();
            char[] ch1 = { ch[0], ch[1] };
            int result = GetSum(Convert.ToInt32(new string(ch1)));
            return result;
        }
        //Получить возраст
        private int GetAge (DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }
            
            
        //Для девятилетнего цикла создание словаря
        private Dictionary<int, int> GetDicForLC(int n)
        {
            var result = new Dictionary<int, int>();
            for (int i=0;i<5;i++)
            {
                int sum = n + i;
                if (sum > 9)
                    sum = n+i-9;
                result.Add(sum,DateTime.Now.Year+i);
            }
            return result;
        }
        //метод для комбинаций 
        private bool hideRowMatch(string sR, string sAll, int i)
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
        //Подчет для второстепенных качеств
        private string GetNumSecSkill(string s1,string s2,string s3)
        {
            int i = s1.Length + s2.Length + s3.Length;
            if (i == 0)
                return "нет";
            else
                return i.ToString();
        }
        //Выбор единственных значений и сортировка 4
        private IEnumerable<int> GetWithoutDublicate4(int i1,int i2,int i3,int i4)
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

        //Выбор единственных значений и сортировка 6
        private IEnumerable<int> GetWithoutDublicate6(NumericRow6 nr6)
        {
            List<int> list = new List<int>();
            list.Add(nr6.n1);
            list.Add(nr6.n2);
            list.Add(nr6.n3);
            list.Add(nr6.n4);
            list.Add(nr6.n5);
            list.Add(nr6.n6);
            IEnumerable<int> list1 = list.Distinct();
            list1 = list1.OrderBy(x => x);
            return list1;
        }
        //Выбор единственных значений и сортировка 12
        private IEnumerable<int> GetWithoutDublicate12(NumericRow12 nr12)
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
            IEnumerable <int> list1 = list.Distinct();
            list1 = list1.OrderBy(x=>x);
            return list1;
        }
        //для 56 судеб перевод итога
        public string TransSU(int i)
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
                    return "33/1";
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
        public NumericRow6 AddNullsTo6(int i)
        {
            var nr6 = new NumericRow6(0);
            while (i<1000000)
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
        public string GetConstMonth(string s)
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
        public string GetFiveNums(string s, int i,int ld,int t, out int td)
        {
            int n = 0;
            td = 0;
            while (n<i)
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
        //Метод высчитывания по сумме
        public int GetSum(int i)
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
        //Сопоставления для матрицы пифагора
        public List<string> GetMatch(Dictionary<int, string> d)
        {
            foreach (var t in d.Keys)
            {
                if (d[t] == "")
                    d[t] = $"(-{t})";
            }
            List<string> list = new List<string>();
            if (d[1] == "111" && d[4] == "4" && d[8] == "(-8)")
                list.Add("111+4+(-8)");
            if (d[1] == "111" && d[4] == "4" && d[8] == "8")
                list.Add("111+4+8");
            if (d[1] == "111" && d[4] == "44" && d[8] == "(-8)")
                list.Add("111+44+(-8)");
            if (d[1] == "111" && d[4] == "44" && d[8] == "8")
                list.Add("111+44+8");
            if (d[1] == "111" && d[4] == "444" && d[8] == "(-8)")
                list.Add("111+444+(-8)");
            if (d[1] == "111" && d[4] == "444" && d[8] == "8")
                list.Add("111+444+8");
            if (d[1] == "1" && d[4] == "4" && d[8] == "88")
                list.Add("1+4+88");
            if (d[1] == "1" && d[4] == "4" && d[8] == "888")
                list.Add("1+4+888");
            if (d[1] == "1" && d[4] == "44" && d[8] == "88")
                list.Add("1+44+88");
            if (d[1] == "1" && d[4] == "44" && d[8] == "888")
                list.Add("1+44+888");
            if (d[1] == "1" && d[4] == "444" && d[8] == "88")
                list.Add("1+444+88");
            if (d[1] == "1" && d[4] == "444" && d[8] == "888")
                list.Add("1+444+888");
            if (d[1] == "11" && d[4] == "4" && d[8] == "88")
                list.Add("11+4+88");
            if (d[1] == "11" && d[4] == "4" && d[8] == "888")
                list.Add("11+4+888");
            if (d[1] == "11" && d[4] == "44" && d[8] == "88")
                list.Add("11+44+88");
            if (d[1] == "11" && d[4] == "44" && d[8] == "888")
                list.Add("11+44+888");
            if (d[1] == "11" && d[4] == "444" && d[8] == "88")
                list.Add("11+444+88");
            if (d[1] == "11" && d[4] == "444" && d[8] == "888")
                list.Add("11+444+888");

            if (d[1] == "111" && d[4] == "4" && d[8] == "88")
                list.Add("111+4+88");
            if (d[1] == "111" && d[4] == "4" && d[8] == "888")
                list.Add("111+4+888");
            if (d[1] == "111" && d[4] == "44" && d[8] == "88")
                list.Add("111+44+88");
            if (d[1] == "111" && d[4] == "44" && d[8] == "888")
                list.Add("111+44+888");
            if (d[1] == "111" && d[4] == "444" && d[8] == "88")
                list.Add("111+444+88");
            if (d[1] == "111" && d[4] == "444" && d[8] == "888")
                list.Add("111+444+888");

            if (d[1] == "1111" && d[4] == "4" && d[8] == "88")
                list.Add("1111+4+88");
            if (d[1] == "1111" && d[4] == "4" && d[8] == "888")
                list.Add("1111+4+888");
            if (d[1] == "1111" && d[4] == "44" && d[8] == "88")
                list.Add("1111+44+88");
            if (d[1] == "1111" && d[4] == "44" && d[8] == "888")
                list.Add("1111+44+888");
            if (d[1] == "1111" && d[4] == "444" && d[8] == "88")
                list.Add("1111+444+88");
            if (d[1] == "1111" && d[4] == "444" && d[8] == "888")
                list.Add("1111+444+888");

            if (d[1] == "11111" && d[4] == "4" && d[8] == "88")
                list.Add("11111+4+88");
            if (d[1] == "11111" && d[4] == "4" && d[8] == "888")
                list.Add("11111+4+888");
            if (d[1] == "11111" && d[4] == "44" && d[8] == "88")
                list.Add("11111+44+88");
            if (d[1] == "11111" && d[4] == "44" && d[8] == "888")
                list.Add("11111+44+888");
            if (d[1] == "11111" && d[4] == "444" && d[8] == "88")
                list.Add("111111+444+88");
            if (d[1] == "11111" && d[4] == "444" && d[8] == "888")
                list.Add("11111+444+888");

            if (d[1] == "111111" && d[4] == "4" && d[8] == "88")
                list.Add("111111+4+88");
            if (d[1] == "111111" && d[4] == "4" && d[8] == "888")
                list.Add("111111+4+888");
            if (d[1] == "111111" && d[4] == "44" && d[8] == "88")
                list.Add("111111+44+88");
            if (d[1] == "111111" && d[4] == "44" && d[8] == "888")
                list.Add("111111+44+888");
            if (d[1] == "111111" && d[4] == "444" && d[8] == "88")
                list.Add("111111+444+88");
            if (d[1] == "111111" && d[4] == "444" && d[8] == "888")
                list.Add("111111+444+888");

            if (d[1] == "11" && d[2] == "22" && d[3] == "33")
                list.Add("11+22+33");
            if (d[1] == "11" && d[2] == "22" && d[3] == "333")
                list.Add("11+22+333");
            if (d[1] == "111" && d[2] == "22" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "2222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "2222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "2222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "2222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "22222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "22222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "22222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "22222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "222222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "11" && d[2] == "222222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "222222" && d[3] == "33")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");
            if (d[1] == "111" && d[2] == "222222" && d[3] == "333")
                list.Add($"{d[1]}+{d[2]}+{d[3]}");

            if (d[1] == "111" && d[2] == "22" && d[3]=="(-3)"&& d[4] == "4"&&d[8]=="(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "11111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "111111" && d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "8")
                list.Add($"{d[1]}+{d[2]}+{d[3]}+{d[4]}+{d[8]}");
            if (d[1] == "1" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "1" && d[8] == "8")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "11" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "11" && d[8] == "8")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "1111" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "1111" && d[8] == "8")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "111111" && d[8] == "(-8)")
                list.Add($"{d[1]}+{d[8]}");
            if (d[1] == "111111" && d[8] == "8")
                list.Add($"{d[1]}+{d[8]}");
            ////2 Энергия
            if (d[2] == "22" && d[4] == "44")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "22" && d[4] == "444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "22" && d[4] == "4444")
                list.Add($"{d[2]}+{d[4]}");
            if(d[2] == "222" && d[4] == "44")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "222" && d[4] == "444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "222" && d[4] == "4444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2222" && d[4] == "44")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2222" && d[4] == "444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2222" && d[4] == "4444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2" && d[4] == "4")
                list.Add($"{d[2]}+{d[4]}");

            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "4" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "4" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "44" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "44" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");

            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "22" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "222" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "99")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "444" && d[8] == "(-8)" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "(-3)" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");
            if (d[2] == "2222" && d[3] == "3" && d[4] == "444" && d[8] == "8" && d[9] == "999")
                list.Add($"{d[2]}+{d[3]}+{d[4]}+{d[8]}+{d[9]}");

            if (d[2] == "2" && d[4] == "44")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2" && d[4] == "444")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "22" && d[4] == "4")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2" && d[4] == "(-4)")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "22" && d[4] == "(-4)")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "222" && d[4] == "(-4)")
                list.Add($"{d[2]}+{d[4]}");
            if (d[2] == "2222" && d[4] == "(-4)")
                list.Add($"{d[2]}+{d[4]}");

            if (d[2] == "22" && d[8] == "88")
                list.Add($"{d[2]}+{d[8]}");
            if (d[2] == "22" && d[8] == "888")
                list.Add($"{d[2]}+{d[8]}");
            if (d[2] == "222" && d[8] == "88")
                list.Add($"{d[2]}+{d[8]}");
            if (d[2] == "222" && d[8] == "888")
                list.Add($"{d[2]}+{d[8]}");
            if (d[2] == "2222" && d[8] == "88")
                list.Add($"{d[2]}+{d[8]}");
            if (d[2] == "2222" && d[8] == "888")
                list.Add($"{d[2]}+{d[8]}");

            return list;
        }
        //Смена папа/мама
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (SuLF.Visibility == Visibility.Hidden)
            {
                SuLF.Visibility = Visibility.Visible;
                SUtF.Visibility = Visibility.Visible;
                SuLM.Visibility = Visibility.Hidden;
                SUtM.Visibility = Visibility.Hidden;
            }
            else
            {
                SuLF.Visibility = Visibility.Hidden;
                SUtF.Visibility = Visibility.Hidden;
                SuLM.Visibility = Visibility.Visible;
                SUtM.Visibility = Visibility.Visible;
            }
        }

        
    }
}
