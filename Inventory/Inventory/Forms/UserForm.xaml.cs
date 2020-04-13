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
            string message = "";
            

            User u = new User()
            {
               Name = NameTb.Text,
               Position = PositionTb.Text,
               SysBlock = db.SysBlocks.First(_=>_.Id == (int)sysBlockTb.Text),
               Monitor = monitorTb.Text,
               Phone = phoneTb.Text,
               Printer = printerTb.Text
            };

            db.Users.Add(u);
            db.SaveChanges();
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
