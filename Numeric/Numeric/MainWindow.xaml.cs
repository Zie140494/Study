using System;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt1;
            DateTime dt2;
            bool IsDate1 = DateTime.TryParse(tb1.Text,out dt1);
            bool IsDate2 = DateTime.TryParse(tb2.Text, out dt2);
            tb1.Text = "25.4.2018";
            tb2.Text = "25.4.2018";

            if (IsDate1 && IsDate2)
            {
                var nr1 = GetRow(dt1);
                var nr2 = GetRow(dt2);
                var nr3 = new NumericRow() { n1 = 2, n2 = 2, n3 = 2, n4 = 2, n5 = 2, n6 = 2, n7 = 2, n8 = 2 };
                var sumNr = SumNum(nr1, nr2, nr3);
            }
            else
            {
                MessageBox.Show("Значение не является датой, введите в формате dd.mm.yyyy");
            }
        }
        public NumericRow GetRow(DateTime dt)
        {
            var nr = new NumericRow();
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
        public NumericRow SumNum(NumericRow nr1,NumericRow nr2,NumericRow nr3)
        {
            NumericRow nr = new NumericRow();
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
        public int GetFakeSum(int i)
        {
            string s;
            while (i >= 10)
                {
                s= i.ToString();
                char[] c = s.ToCharArray();
                //Сделать цикл для псевдосуммы
                };
            return res;
        }
    }
}
