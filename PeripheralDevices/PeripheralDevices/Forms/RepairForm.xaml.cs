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
    public partial class RepairForm : Window
    {
        DataContext db = new DataContext();
        public RepairForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(DateTb.Text,out dt))
            {
                throw new Exception($"Значение дата ремонта не является датой");
            }

            Repair r = new Repair()
            {
                Name = NameTb.Text,
                Employee = EmployeeTb.Text,
                Status = StatusTb.Text,
                RepairDate = dt
            };

            if (string.IsNullOrEmpty(this.Title))
                db.Repairs.Add(r);
            else
            {
                r.Id = Convert.ToInt32(this.Title);
                db.Repairs.Update(r);
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
