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
    public partial class UserForm : Window
    {
        DataContext db = new DataContext();
        public UserForm()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            int i;
            SysBlock s;
            Monitor m;
            Phone ph;
            Printer pr;

            if (String.IsNullOrWhiteSpace(sysBlockTb.Text))
                s = null;
            else
            {
                if (!Int32.TryParse(sysBlockTb.Text, out i))
                {
                    MessageBox.Show("Номер системного блока должен быть целым числом");
                    return;
                }
                else
                {
                    s = db.SysBlocks.FirstOrDefault(_=>_.Id==i);
                    if (s==null)
                    {
                        MessageBox.Show($"Системный блок с номером {i} не существует");
                        return;
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(monitorTb.Text))
                m = null;
            else
            {
                if (!Int32.TryParse(monitorTb.Text, out i))
                {
                    MessageBox.Show("Номер монитора должен быть целым числом");
                    return;
                }
                else
                {
                    m = db.Monitors.FirstOrDefault(_ => _.Id == i);
                    if (m == null)
                    {
                        MessageBox.Show($"Монитор с номером {i} не существует");
                        return;
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(phoneTb.Text))
                ph = null;
            else
            {
                if (!Int32.TryParse(phoneTb.Text, out i))
                {
                    MessageBox.Show("Номер телефон должен быть целым числом");
                    return;
                }
                else
                {
                    ph = db.Phones.FirstOrDefault(_ => _.Id == i);
                    if (ph == null)
                    {
                        MessageBox.Show($"Телефон с номером {i} не существует");
                        return;
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(phoneTb.Text))
                pr = null;
            else
            {
                if (!Int32.TryParse(printerTb.Text, out i))
                {
                    MessageBox.Show("Номер принтера должен быть целым числом");
                    return;
                }
                else
                {
                    pr = db.Printers.FirstOrDefault(_ => _.Id == i);
                    if (pr == null)
                    {
                        MessageBox.Show($"Принтер с номером {i} не существует");
                        return;
                    }
                }
            }

            
            User u = new User()
            {
                Name = NameTb.Text,
                Position = PositionTb.Text,
                SysBlock = s,
                Monitor = m,
                Phone = ph,
                Printer = pr
            };

            if (string.IsNullOrEmpty(this.Title))
                db.Users.Add(u);
            else
            {
                u.Id = Convert.ToInt32(this.Title);
                db.Users.Update(u);
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
