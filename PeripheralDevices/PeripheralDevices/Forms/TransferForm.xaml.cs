using Microsoft.EntityFrameworkCore;
using PeripheralDevices.Enums;
using PeripheralDevices.Models;
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

namespace PeripheralDevices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransferForm : Window
    {
        DataContext db = new DataContext();
        public TransferForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(DateTb.Text, out dt))
            {
                throw new Exception($"Значение дата передачи не является датой");
            }

            int i;
            if (!Int32.TryParse(CabinetTb.Text, out i))
            {
                throw new Exception($"Значение номер комнаты не является целым числом");
            }


            Transfer t = new Transfer()
            {
                RoomNumber= i,
                Where=WhereTb.Text,
                TransferDate=dt
            };

            if (string.IsNullOrEmpty(this.Title))
                db.Transfers.Add(t);
            else
            {
                t.Id = Convert.ToInt32(this.Title);
                db.Transfers.Update(t);
            }

            db.SaveChanges();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
