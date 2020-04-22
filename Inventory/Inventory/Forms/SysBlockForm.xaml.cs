using Inventory.Enums;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SysBlockForm : Window
    {
        DataContext db = new DataContext();
        public SysBlockForm()
        {
            InitializeComponent();
        }


        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var dt = new DateTime();
            if (DateTime.TryParse(DateTb.Text, out dt))
            {
                SysBlock s = new SysBlock()
                {
                    Model = ModelTb.Text,
                    DateOfPurchase = dt,
                    Provider = ProviderTb.Text,
                    SerialNumber = SerialTb.Text,
                    Status = (bool)StatusTb.IsChecked,
                    TypeDevice = TypeTb.Text,
                    CPU = CPUTb.Text,
                    Frequency = FrequencyTb.Text,
                    RAM = RAMTb.Text,
                    HDD = HDDTb.Text
                };

                if (string.IsNullOrEmpty(this.Title))
                    db.SysBlocks.Add(s);
                else
                {
                    s.Id = Convert.ToInt32(this.Title);
                    db.SysBlocks.Update(s);
                }
                
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле Дата покупки не является датой");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
