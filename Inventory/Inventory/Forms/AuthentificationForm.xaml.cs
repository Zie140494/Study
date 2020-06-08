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
    public partial class AuthentificationForm : Window
    {
        DataContext db = new DataContext();
        public AuthentificationForm()
        {
            InitializeComponent();
        }


        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text == "Admin")
            {
                if (PassTb.Text == "12345")
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Неправильный пароль");
            }
            else
                MessageBox.Show("Такого пользователя не существует");
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
