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
    public partial class EmployeeForm : Window
    {
        DataContext db = new DataContext();
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            int i;
            if (!Int32.TryParse(PhoneTb.Text, out i))
            {
                throw new Exception($"Значение номера телефона не является целым числом");
            }

            Employee em = new Employee()
            {
                FirstName = FirstNameTb.Text,
                SecondName = LastNameTb.Text,
                FatherName = FatherNameTb.Text,
                Rank=RankTb.Text,
                Position=PositionTb.Text,
                Phone= i,
                Room=CabinetTb.Text
            };

            if (string.IsNullOrEmpty(this.Title))
                db.Employees.Add(em);
            else
            {
                em.Id = Convert.ToInt32(this.Title);
                db.Employees.Update(em);
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
