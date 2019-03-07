using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                    var nr1 = Calculation.Calc.GetRow(dt1);
                    var nr2 = Calculation.Calc.GetRow(dt2);
                    var nr3 = new NumericRow(Calculation.Calc.GetFakeSum(res));
                    var sumNr = Calculation.Calc.SumNum(nr1, nr2, nr3);
                    var Nr12 = new NumericRow12(0);
                    Nr12.n1 = Calculation.Calc.GetFakeSum(sumNr.n1);
                    Nr12.n2 = Calculation.Calc.GetFakeSum(sumNr.n2);
                    Nr12.n3 = Calculation.Calc.GetFakeSum(sumNr.n3);
                    Nr12.n4 = Calculation.Calc.GetFakeSum(sumNr.n4);
                    Nr12.n5 = Calculation.Calc.GetFakeSum(sumNr.n5);
                    Nr12.n6 = Calculation.Calc.GetFakeSum(sumNr.n6);
                    Nr12.n7 = Calculation.Calc.GetFakeSum(sumNr.n7);
                    Nr12.n8 = Calculation.Calc.GetFakeSum(sumNr.n8);
                    Nr12.n9 = Calculation.Calc.GetFakeSum(sumNr.n1);
                    Nr12.n10 = Calculation.Calc.GetFakeSum(sumNr.n2);
                    Nr12.n11 = Calculation.Calc.GetFakeSum(sumNr.n3);
                    Nr12.n12 = Calculation.Calc.GetFakeSum(sumNr.n4);
                    try
                    {
                        string pathEx = @"C:\Test\Test.xlsx";
                        string pathPdf = string.Format(@"C:\Test\{0}.pdf", KZtbF.Text);

                        for (int i = 1; i < Int32.MaxValue; i++)
                        {
                            if (!Calculation.Calc.IsExists(pathPdf))
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
                        foreach (var nt in Calculation.Calc.GetWithoutDublicate12(Nr12))
                        {
                            excel.Unhide(del + nt);
                        }

                        excel.Save();
                        excel.Close();
                        Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                    var t = Calculation.Calc.GetLC6(dt1);
                    var t2 = Calculation.Calc.GetLC6(dt1);
                    var t3 = Calculation.Calc.GetLC6(dt1);
                    int iY = Ftb3.Text.Length - Ftb2.Text.Length;
                    if (iY < 0)
                        iY = 0;
                    var tY = new NumericRow6(Calculation.Calc.GetFakeSum(Convert.ToInt32(Ftb4.Text)));
                    var tSum = Calculation.Calc.SumNum6(t, t2);
                    tSum = Calculation.Calc.SumNum6(tSum, t3);
                    tSum = Calculation.Calc.SumNum6(tSum, tY);
                    var nr12 = new NumericRow12(0);
                    nr12.n1 = Calculation.Calc.GetFakeSum(tSum.n1);
                    nr12.n2 = Calculation.Calc.GetFakeSum(tSum.n2);
                    nr12.n3 = Calculation.Calc.GetFakeSum(tSum.n3);
                    nr12.n4 = Calculation.Calc.GetFakeSum(tSum.n4);
                    nr12.n5 = Calculation.Calc.GetFakeSum(tSum.n5);
                    nr12.n6 = Calculation.Calc.GetFakeSum(tSum.n6);
                    nr12.n7 = iY;
                    nr12.n8 = Calculation.Calc.GetFakeSum(tSum.n1);
                    nr12.n9 = Calculation.Calc.GetFakeSum(tSum.n2);
                    nr12.n10 = Calculation.Calc.GetFakeSum(tSum.n3);
                    nr12.n11 = Calculation.Calc.GetFakeSum(tSum.n4);
                    nr12.n12 = Calculation.Calc.GetFakeSum(tSum.n5);
                    try
                    {
                        string pathEx = @"C:\Test\FTest.xlsx";
                        string pathPdf = string.Format(@"C:\Test\{0}.pdf", FtbF.Text);

                        for (int i = 1; i < Int32.MaxValue; i++)
                        {
                            if (!Calculation.Calc.IsExists(pathPdf))
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
                        foreach (var nt in Calculation.Calc.GetWithoutDublicate12(nr12))
                        {
                            excel.Unhide(del + nt);
                        }

                        excel.Save();
                        excel.Close();
                        Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                var nr12 = Calculation.Calc.SYMethod(dt1);

                try
                {
                    string pathEx = @"C:\Test\SYTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", SYtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdf))
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
                    foreach (var nt in Calculation.Calc.GetWithoutDublicate12(nr12))
                    {
                        excel.Unhide(del + nt);
                    }

                    excel.Save();
                    excel.Close();
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                var nr8 = Calculation.Calc.GetRow(dt1);
                string s = nr8.n1.ToString() + nr8.n2.ToString() + nr8.n3.ToString() + nr8.n4.ToString() + nr8.n5.ToString() + nr8.n6.ToString() + nr8.n7.ToString() + nr8.n8.ToString();
                int numOfFate = 0;
                switch (Calculation.Calc.GetSum(Convert.ToInt32(s)))
                {
                    case 11:
                        numOfFate = 11;
                        break;
                    case 22:
                        numOfFate = 22;
                        break;
                    case 33:
                        numOfFate = 33;
                        break;
                    default:
                        numOfFate = Calculation.Calc.GetFakeSum(Convert.ToInt32(s));
                        break;
                }

                int LC = Calculation.Calc.GetLC(dt1);
                int firstNum = nr8.n1 + nr8.n2 + nr8.n3 + nr8.n4 + nr8.n5 + nr8.n6 + nr8.n7 + nr8.n8;
                int secondNum = Calculation.Calc.GetFakeSum(firstNum);
                int cnt;
                if (nr8.n1 != 0)
                    cnt = 2 * nr8.n1;
                else
                    cnt = 2 * nr8.n2;
                int thirdNum = firstNum - cnt;
                int fourthNum = Calculation.Calc.GetFakeSum(thirdNum);
                int addingNum;
                if (dt1.Year > 1999)
                {
                    addingNum = dt1.Year - dt1.Day - dt1.Month - firstNum - secondNum - thirdNum - fourthNum;
                }
                else
                    addingNum = 0;

                var d = Calculation.Calc.GetSequenceForm(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum);
                var d2 = Calculation.Calc.GetSequencecalc(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum);
                

                try
                {
                    #region excel
                    string pathEx = @"C:\Test\MPTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdf))
                        {
                            break;
                        }
                        pathPdf = string.Format(@"C:\Test\{0}{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excel = new Excel(pathEx, 1);
                    #endregion

                    #region excelCom
                    string pathExCom = @"C:\Test\MPTestCom.xlsx";
                    string pathPdfCom = string.Format(@"C:\Test\{0}_Com_.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdfCom))
                        {
                            break;
                        }
                        pathPdfCom = string.Format(@"C:\Test\{0}_Com_{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excelCom = new Excel(pathExCom, 1);
                    #endregion

                    #region excelProf1
                    string pathExProf1 = @"C:\Test\MPTestProf1.xlsx";
                    string pathPdfProf1 = string.Format(@"C:\Test\{0}_Prof1_.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdfProf1))
                        {
                            break;
                        }
                        pathPdfProf1 = string.Format(@"C:\Test\{0}_Prof1_{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excelProf1 = new Excel(pathExProf1, 1);
                    #endregion
                    #region excelProf2
                    string pathExProf2 = @"C:\Test\MPTestProf2.xlsx";
                    string pathPdfProf2 = string.Format(@"C:\Test\{0}_Prof2_.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdfProf2))
                        {
                            break;
                        }
                        pathPdfProf2 = string.Format(@"C:\Test\{0}_Prof2_{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excelProf2 = new Excel(pathExProf2, 1);
                    #endregion

                    #region excelSoch
                    string pathExSoch = @"C:\Test\MPTestSoch.xlsx";
                    string pathPdfSoch = string.Format(@"C:\Test\{0}_Soch_.pdf", MPtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdfSoch))
                        {
                            break;
                        }
                        pathPdfSoch = string.Format(@"C:\Test\{0}_Soch_{1}.pdf", MPtbF.Text, i.ToString());
                    }

                    Excel excelSoch = new Excel(pathExSoch, 1);
                    #endregion

                    excel.WriteToCell(0, 1, MPtbF.Text);
                    excel.WriteToCell(1, 1, MPtb1.Text);
                    excel.WriteToCell(2, 1, numOfFate.ToString());
                    excel.WriteToCell(2, 3, LC.ToString());

                    excel.WriteToCell(3, 2, $"{firstNum.ToString()}.{secondNum.ToString()}");
                    excel.WriteToCell(4, 2, $"{thirdNum.ToString()}.{fourthNum.ToString()}");

                    excel.WriteToCell(6, 0, d[1] != "" ? d[1] : "нет");
                    excel.WriteToCell(8, 0, d[2] != "" ? d[2] : "нет");
                    excel.WriteToCell(10, 0, d[3] != "" ? d[3] : "нет");
                    excel.WriteToCell(6, 1, d[4] != "" ? d[4] : "нет");
                    excel.WriteToCell(8, 1, d[5] != "" ? d[5] : "нет");
                    excel.WriteToCell(10, 1, d[6] != "" ? d[6] : "нет");
                    excel.WriteToCell(6, 2, d[7] != "" ? d[7] : "нет");
                    excel.WriteToCell(8, 2, d[8] != "" ? d[8] : "нет");
                    excel.WriteToCell(10, 2, d[9] != "" ? d[9] : "нет");

                    string SecSkill1 = Calculation.Calc.GetNumSecSkill(d2[3], d2[5], d2[7]);
                    string SecSkill2 = Calculation.Calc.GetNumSecSkill(d2[1], d2[4], d2[7]);
                    string SecSkill3 = Calculation.Calc.GetNumSecSkill(d2[2], d2[5], d2[8]);
                    string SecSkill4 = Calculation.Calc.GetNumSecSkill(d2[3], d2[6], d2[9]);
                    string SecSkill5 = Calculation.Calc.GetNumSecSkill(d2[1], d2[2], d2[3]);
                    string SecSkill6 = Calculation.Calc.GetNumSecSkill(d2[4], d2[5], d2[6]);
                    string SecSkill7 = Calculation.Calc.GetNumSecSkill(d2[7], d2[8], d2[9]);
                    string SecSkill8 = Calculation.Calc.GetNumSecSkill(d2[1], d2[5], d2[9]);
                    
                    excel.WriteToCell(3, 4, addingNum.ToString());

                    excel.WriteToCell(4, 3, SecSkill1);
                    excel.WriteToCell(6, 3, SecSkill2);
                    excel.WriteToCell(8, 3, SecSkill3);
                    excel.WriteToCell(10, 3, SecSkill4);
                    excel.WriteToCell(12, 0, SecSkill5);
                    excel.WriteToCell(12, 1, SecSkill6);
                    excel.WriteToCell(12, 2, SecSkill7);
                    excel.WriteToCell(12, 3, SecSkill8);

                    SecSkill1 = Calculation.Calc.ZeroToString(SecSkill1);
                    SecSkill2 = Calculation.Calc.ZeroToString(SecSkill2);
                    SecSkill3 = Calculation.Calc.ZeroToString(SecSkill3);
                    SecSkill4 = Calculation.Calc.ZeroToString(SecSkill4);
                    SecSkill5 = Calculation.Calc.ZeroToString(SecSkill5);
                    SecSkill6 = Calculation.Calc.ZeroToString(SecSkill6);
                    SecSkill7 = Calculation.Calc.ZeroToString(SecSkill7);
                    SecSkill8 = Calculation.Calc.ZeroToString(SecSkill8);

                    string all = $"{d2[1]}/{d2[2]}/{d2[3]}/{d2[4]}/{d2[5]}/{d2[6]}/{d2[7]}/{d2[8]}/{d2[9]}/Те{SecSkill1}/Це{SecSkill2}/Се{SecSkill3}/Ст{SecSkill4}/Са{SecSkill5}/Бы{SecSkill6}/Та{SecSkill7}/Ду{SecSkill8}/ЧС{numOfFate}";
                    excel.WriteToCell(2, 4, all);

                    excel.Unhide(14);
                    excel.Unhide(27);
                    excel.Unhide(66);
                    excel.Unhide(77);
                    excel.Unhide(84);
                    excel.Unhide(95);
                    excel.Unhide(101);
                    excel.Unhide(107);
                    excel.Unhide(113);
                    excel.Unhide(118);
                    excel.Unhide(126);
                    excel.Unhide(137);
                    excel.Unhide(148);
                    excel.Unhide(159);
                    excel.Unhide(170);
                    excel.Unhide(181);
                    excel.Unhide(192);
                    excel.Unhide(203);
                    excel.Unhide(214);
                    excel.Unhide(225);

                    if (dt1.Year > 1999)
                    {
                        excel.Unhide(234);
                    }

                    for (int i = 15; i < 27; i++)
                    {
                        excel.Hide(i);
                    }
                    switch (numOfFate)
                    {
                        case 11:
                            excel.Unhide(24);
                            break;
                        case 22:
                            excel.Unhide(25);
                            break;
                        case 33:
                            excel.Unhide(26);
                            break;
                        default:
                            excel.Unhide(14 + numOfFate);
                            break;
                    }


                    string fs = $"{firstNum}.{secondNum}";
                    string tf = $"{thirdNum}.{fourthNum}";

                    for (int i = 28; i < 66; i++)
                    {
                        var cel = excel.ReadCell(i - 1, 4);
                        if (cel == fs || cel == tf)
                            excel.Unhide(i);
                        else
                            excel.Hide(i);
                    }

                    for (int i = 67; i < 77; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(67 + d[1].Length);

                    for (int i = 78; i < 84; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(78 + d[3].Length);

                    for (int i = 85; i < 95; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(85 + d[2].Length);

                    for (int i = 96; i < 101; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(96 + d[4].Length);

                    for (int i = 102; i < 107; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(102 + d[5].Length);

                    for (int i = 108; i < 113; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(108 + d[6].Length);

                    for (int i = 114; i < 118; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(114 + d[7].Length);

                    for (int i = 119; i < 126; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(119 + d[8].Length);

                    for (int i = 127; i < 137; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(127 + d[9].Length);

                    for (int i = 138; i < 148; i++)
                    {
                        excel.Hide(i);
                    }
                    var tfd = SecSkill1;
                    excel.Unhide(138 + Convert.ToInt32(SecSkill1));

                    for (int i = 149; i < 159; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(149 + Convert.ToInt32(SecSkill2));

                    for (int i = 160; i < 170; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(160 + Convert.ToInt32(SecSkill3));

                    for (int i = 171; i < 181; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(171 + Convert.ToInt32(SecSkill6));

                    for (int i = 182; i < 192; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(182 + Convert.ToInt32(SecSkill4));

                    for (int i = 193; i < 203; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(193 + Convert.ToInt32(SecSkill5));

                    for (int i = 204; i < 214; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(204 + Convert.ToInt32(SecSkill7));

                    for (int i = 215; i < 225; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(215 + Convert.ToInt32(SecSkill8));

                    for (int i = 226; i < 235; i++)
                    {
                        excel.Hide(i);
                    }
                    excel.Unhide(225 + Calculation.Calc.GetFakeSum(dt1.Day));

                    Task[] tasks1 = new Task[4]
                    {
                         new Task(() => MatrixCalc(excelCom,all,2500,true,false)),
                         new Task(() => MatrixCalc(excelProf1,all,2602,true,false)),
                         new Task(() => MatrixCalc(excelProf2,all,2700,false,false)),
                         new Task(() => MatrixCalc(excelSoch,all,2000,true,dt1.Year<1999))
                    };
                    foreach (var t in tasks1)
                        t.Start();
                    Task.WaitAll(tasks1);


                    

                    excel.HideCol(5);

                    excel.Save();
                    excel.Close();
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
                    Calculation.Calc.ExportWorkbookToPdf(pathExCom, pathPdfCom);
                    Calculation.Calc.ExportWorkbookToPdf(pathExProf1, pathPdfProf1);
                    Calculation.Calc.ExportWorkbookToPdf(pathExProf2, pathPdfProf2);
                    Calculation.Calc.ExportWorkbookToPdf(pathExSoch, pathPdfSoch);
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
                        s1 = Calculation.Calc.GetFiveNums(s1, 5, last.Day, i, out i);
                        t -= 5;
                        s2 = Calculation.Calc.GetFiveNums(s2, 5, last.Day, i, out i);
                        t -= 5;
                        s3 = Calculation.Calc.GetFiveNums(s3, 5, last.Day, i, out i);
                        t -= 5;
                        s4 = Calculation.Calc.GetFiveNums(s4, 5, last.Day, i, out i);
                        t -= 5;
                        s5 = Calculation.Calc.GetFiveNums(s5, 5, last.Day, i, out i);
                        t -= 5;
                        s6 = Calculation.Calc.GetFiveNums(s6, t, last.Day, i, out i);
                        int YearValue = Calculation.Calc.GetSum(Convert.ToInt32(SUtb3.Text));
                        var nr6cell1 = new NumericRow6(YearValue);
                        string con = Calculation.Calc.GetConstMonth(SUtb4.Text);
                        var nr6cell2 = new NumericRow6(Convert.ToInt32(con));
                        var nr6cell3 = new NumericRow6(0);
                        nr6cell3.n1 = dt1.Day;
                        nr6cell3.n2 = dt1.Month;
                        nr6cell3.n3 = dt1.Year / 1000;
                        nr6cell3.n4 = dt1.Year / 100 % 10;
                        nr6cell3.n5 = dt1.Year / 10 % 10 % 10;
                        nr6cell3.n6 = dt1.Year % 10;
                        var nr6cell4 = Calculation.Calc.GetLC6(dt1);
                        var nr6cell4M = Calculation.Calc.GetLC6(dt3);
                        var nr6cell5 = Calculation.Calc.AddNullsTo6(dt1.Year / 100 % 10 * dt1.Month * dt1.Day);
                        var nr6cell5M = Calculation.Calc.AddNullsTo6(dt3.Year / 100 % 10 * dt3.Month * dt3.Day);
                        var nr6cell6 = Calculation.Calc.GetLC6(dt2);
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
                                if (!Calculation.Calc.IsExists(pathPdf))
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

                            excel.WriteToCell(4, 7, Calculation.Calc.TransSU(nr6cell7Sum.n1));
                            excel.WriteToCell(5, 7, Calculation.Calc.TransSU(nr6cell7Sum.n2));
                            excel.WriteToCell(6, 7, Calculation.Calc.TransSU(nr6cell7Sum.n3));
                            excel.WriteToCell(7, 7, Calculation.Calc.TransSU(nr6cell7Sum.n4));
                            excel.WriteToCell(8, 7, Calculation.Calc.TransSU(nr6cell7Sum.n5));
                            excel.WriteToCell(9, 7, Calculation.Calc.TransSU(nr6cell7Sum.n6));

                            var del = 11;
                            for (int h = 0; h < 57; h++)
                            {
                                excel.Hide(del + h);
                            }
                            foreach (var nt in Calculation.Calc.GetWithoutDublicate6(nr6cell7Sum))
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

                            excel.WriteToCell(69, 7, Calculation.Calc.TransSU(nr6cell7SumM.n1));
                            excel.WriteToCell(70, 7, Calculation.Calc.TransSU(nr6cell7SumM.n2));
                            excel.WriteToCell(71, 7, Calculation.Calc.TransSU(nr6cell7SumM.n3));
                            excel.WriteToCell(72, 7, Calculation.Calc.TransSU(nr6cell7SumM.n4));
                            excel.WriteToCell(73, 7, Calculation.Calc.TransSU(nr6cell7SumM.n5));
                            excel.WriteToCell(74, 7, Calculation.Calc.TransSU(nr6cell7SumM.n6));

                            del = 76;
                            for (int h = 0; h < 57; h++)
                            {
                                excel.Hide(del + h);
                            }
                            foreach (var nt in Calculation.Calc.GetWithoutDublicate6(nr6cell7SumM))
                            {
                                excel.Unhide(del + nt);
                            }

                            //excel.HideCol(9);

                            excel.Save();
                            excel.Close();
                            Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                string s = Calculation.Calc.GetSum(dt1.Day).ToString() + Calculation.Calc.GetSum(dt1.Month).ToString();
                int i1 = Calculation.Calc.GetFakeSum(Convert.ToInt32(s));
                int i2 = Calculation.Calc.GetFakeSum(DateTime.Now.Year);
                int res = Calculation.Calc.GetFakeSum(i1 + i2);
                var dic = Calculation.Calc.GetDicForLC(res);

                try
                {
                    string pathEx = @"C:\Test\LCTest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", LCtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdf))
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
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
            int age = Calculation.Calc.GetAge(dt1, DateTime.Now);
            if (IsDate1 || age<18)
            {
                var lc6 = Calculation.Calc.GetLC6(dt1);
                var lc = Convert.ToInt32(lc6.n1.ToString() + lc6.n2.ToString() + lc6.n3.ToString() + lc6.n4.ToString() + lc6.n5.ToString() + lc6.n6.ToString());


                List<Lun> list = new List<Lun>();//18-years+5
                List<Lun> listh = new List<Lun>();//18
                List<int> luns = new List<int>();
                List<int> suns = new List<int>();
                List<int> sums = new List<int>();
                for (int it=18;it<age+6;it++)
                {
                    list.Add(new Lun(it, Calculation.Calc.GetSun(it, lc), Calculation.Calc.GetLuna(it, lc)));
                    if (it>=age)
                    {
                        listh.Add(new Lun(it, Calculation.Calc.GetSun(it, lc), Calculation.Calc.GetLuna(it, lc)));
                        luns.Add(Calculation.Calc.GetLuna(it, lc));
                        suns.Add(Calculation.Calc.GetSun(it, lc));
                        sums.Add(Calculation.Calc.GetSun(it, lc) - Calculation.Calc.GetLuna(it, lc));
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
                        if (!Calculation.Calc.IsExists(pathPdf))
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
                        if (l.Luna>l.Sun)
                        {
                            excel.WriteToCell(l.Year - 13, 1, l.Luna.ToString());
                            excel.WriteToCell(l.Year - 13, 2, "");
                        }
                            
                        else
                        {
                            excel.WriteToCell(l.Year - 13, 2, l.Sun.ToString());
                            excel.WriteToCell(l.Year - 13, 1, "");
                        }
                            
                        excel.WriteToCell(l.Year - 13, 3, Calculation.Calc.TransfLun(l.Sum));
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
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                        if (!Calculation.Calc.IsExists(pathPdf))
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
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
                int it = Calculation.Calc.GetFakeSum(dt1.Day+dt1.Day);

                int i1 = dt1.Day + 10 + 13;
                int i2 = Calculation.Calc.GetFakeSum(dt1.Year);
                int i3 = i1 - i2;
                if (i3 > 22)
                    i3 = Calculation.Calc.GetFakeSum(i3);

                try
                {
                    string pathEx = @"C:\Test\KATest.xlsx";
                    string pathPdf = string.Format(@"C:\Test\{0}.pdf", KAtbF.Text);

                    for (int i = 1; i < Int32.MaxValue; i++)
                    {
                        if (!Calculation.Calc.IsExists(pathPdf))
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
                    Calculation.Calc.ExportWorkbookToPdf(pathEx, pathPdf);
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
        private void MatrixCalc(Excel excel, string all, int max, bool isFirstDesc, bool isKids)
        {
            if (!isKids)
            {
                int t=1;
                if (isFirstDesc)
                {
                    excel.Unhide(1);
                    t = 2;
                }
                for (int i = t; i < max + 1; i++)
                {
                    var cel = excel.ReadCell(i - 1, 4);

                    if (Calculation.Calc.hideRowMatch(cel, all, i))
                        excel.Unhide(i);
                    else
                        excel.Hide(i);
                }
                excel.HideCol(5);
            }
            excel.Save();
            excel.Close();
        }
    }
}
