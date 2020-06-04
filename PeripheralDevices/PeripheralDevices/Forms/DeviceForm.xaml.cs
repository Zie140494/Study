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
    public partial class DeviceForm : Window
    {
        DataContext db = new DataContext();
        int tabIndex = -1;
        public DeviceForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            int i;
            Employee em;
            Repair r;
            Transfer t;
            
            if (String.IsNullOrWhiteSpace(EmployeeTb.Text))
                em = null;
            else
            {
                if (!Int32.TryParse(EmployeeTb.Text, out i))
                {
                    MessageBox.Show("Номер системного блока должен быть целым числом");
                    return;
                }
                else
                {
                    em = db.Employees.FirstOrDefault(_ => _.Id == i);
                    if (em == null)
                    {
                        MessageBox.Show($"Сотрудник с номером {i} не существует");
                        return;
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(RepairTb.Text))
                r = null;
            else
            {
                if (!Int32.TryParse(RepairTb.Text, out i))
                {
                    MessageBox.Show("Номер монитора должен быть целым числом");
                    return;
                }
                else
                {
                    r = db.Repairs.FirstOrDefault(_ => _.Id == i);
                    if (r == null)
                    {
                        MessageBox.Show($"Ремонт с номером {i} не существует");
                        return;
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(TransferTb.Text))
                t = null;
            else
            {
                if (!Int32.TryParse(TransferTb.Text, out i))
                {
                    MessageBox.Show("Номер телефон должен быть целым числом");
                    return;
                }
                else
                {
                    t = db.Transfers.FirstOrDefault(_ => _.Id == i);
                    if (t == null)
                    {
                        MessageBox.Show($"Телефон с номером {i} не существует");
                        return;
                    }
                }
            }


            Device d = new Device()
            {
                Type = TypeTb.Text,
                Model = ModelTb.Text,
                Employee = em,
                Repair = r,
                Transfer = t
            };

            if (string.IsNullOrEmpty(this.Title))
                db.Devices.Add(d);
            else
            {
                d.Id = Convert.ToInt32(this.Title);
                db.Devices.Update(d);
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
