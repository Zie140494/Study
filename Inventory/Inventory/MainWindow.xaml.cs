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
    public partial class MainWindow : Window
    {
        DataContext db = new DataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.User:
                    userGrid.ItemsSource = db.Users
                                            .Include(nameof(SysBlock))
                                            .Include(nameof(Monitor))
                                            .Include(nameof(Printer))
                                            .Include(nameof(Phone))
                                            .ToList();
                    break;
                case (int)TabEnum.SysBlock:
                    sysBlockGrid.ItemsSource = db.SysBlocks.ToList();
                    break;
                case (int)TabEnum.Monitor:
                    monitorGrid.ItemsSource = db.Monitors.ToList();
                    break;
                case (int)TabEnum.Printer:
                    printerGrid.ItemsSource = db.Printers.ToList();
                    break;
                case (int)TabEnum.Phone:
                    phoneGrid.ItemsSource = db.Phones.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }
    }
}
