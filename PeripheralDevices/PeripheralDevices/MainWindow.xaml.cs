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
    public partial class MainWindow : Window, IDisposable
    {
        DataContext db = new DataContext();
        int tabIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex != TabIndex)
                Refresh();
            TabIndex = tabControl.SelectedIndex;
        }

        private void Refresh()
        {
            db = new DataContext();
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.Device:
                    deviceGrid.ItemsSource = db.Devices
                                            .Include(nameof(Employee))
                                            .Include(nameof(Repair))
                                            .Include(nameof(Transfer))
                                            .ToList();
                    break;
                case (int)TabEnum.Employee:
                    var t = db.Employees.ToList();
                    employeeGrid.ItemsSource = db.Employees.ToList();
                    break;
                case (int)TabEnum.Transfer:
                    transferGrid.ItemsSource = db.Transfers.ToList();
                    break;
                case (int)TabEnum.Repair:
                    repairGrid.ItemsSource = db.Repairs.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.Device:
                    db.Devices.Remove((Device)deviceGrid.SelectedItem);
                    db.SaveChanges();
                    deviceGrid.ItemsSource = db.Devices
                                            .Include(nameof(Employee))
                                            .Include(nameof(Repair))
                                            .Include(nameof(Transfer))
                                            .ToList();
                    break;
                case (int)TabEnum.Employee:
                    db.Employees.Remove((Employee)employeeGrid.SelectedItem);
                    db.SaveChanges();
                    employeeGrid.ItemsSource = db.Employees.ToList();
                    break;
                case (int)TabEnum.Repair:
                    db.Repairs.Remove((Repair)repairGrid.SelectedItem);
                    db.SaveChanges();
                    repairGrid.ItemsSource = db.Repairs.ToList();
                    break;
                case (int)TabEnum.Transfer:
                    db.Transfers.Remove((Transfer)transferGrid.SelectedItem);
                    db.SaveChanges();
                    transferGrid.ItemsSource = db.Transfers.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.Device:
                    DeviceForm df = new DeviceForm();
                    df.Closed += (sender, args) => { Refresh(); };
                    df.Show();
                    deviceGrid.ItemsSource = db.Devices.ToList();
                    break;
                case (int)TabEnum.Employee:
                    EmployeeForm ef = new EmployeeForm();
                    ef.Closed += (sender, args) => { Refresh(); };
                    ef.Show();
                    employeeGrid.ItemsSource = db.Employees.ToList();
                    break;
                case (int)TabEnum.Repair:
                    RepairForm rf = new RepairForm();
                    rf.Closed += (sender, args) => { Refresh(); };
                    rf.Show();
                    repairGrid.ItemsSource = db.Repairs.ToList();
                    break;
                case (int)TabEnum.Transfer:
                    TransferForm pf = new TransferForm();
                    pf.Closed += (sender, args) => { Refresh(); };
                    pf.Show();
                    transferGrid.ItemsSource = db.Transfers.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.Device:
                    DeviceForm df = new DeviceForm();

                    df.Closed += (sender, args) => { Refresh(); };
                    Device d = (Device)deviceGrid.SelectedItem;
                    if (d == null)
                        return;
                    df.Title = d.Id.ToString();
                    df.TypeTb.Text = d.Type;
                    df.ModelTb.Text = d.Model;
                    df.EmployeeTb.Text = d.Employee == null ? "" : d.Employee.Id.ToString();
                    df.TransferTb.Text = d.Transfer == null ? "" : d.Transfer.Id.ToString();
                    df.RepairTb.Text = d.Repair == null ? "" : d.Repair.Id.ToString();
                    df.Show();
                    break;
                case (int)TabEnum.Employee:
                    EmployeeForm ef = new EmployeeForm();
                    ef.Closed += (sender, args) => { Refresh(); };
                    Employee em = (Employee)employeeGrid.SelectedItem;
                    if (em == null)
                        return;
                    ef.Title = em.Id.ToString();
                    ef.FirstNameTb.Text = em.FatherName;
                    ef.LastNameTb.Text = em.SecondName;
                    ef.FatherNameTb.Text = em.FatherName;
                    ef.RankTb.Text = em.Rank;
                    ef.PositionTb.Text = em.Position;
                    ef.PhoneTb.Text = em.Phone.ToString();
                    ef.CabinetTb.Text = em.Room;
                    ef.Show();
                    break;
                case (int)TabEnum.Repair:
                    RepairForm rf = new RepairForm();
                    rf.Closed += (sender, args) => { Refresh(); };
                    Repair r = (Repair)repairGrid.SelectedItem;
                    if (r == null)
                        return;
                    rf.Title = r.Id.ToString();
                    rf.NameTb.Text = r.Name;
                    rf.EmployeeTb.Text = r.Employee;
                    rf.StatusTb.Text = r.Status;
                    rf.DateTb.Text = r.RepairDate.ToString();
                    rf.Show();
                    break;
                case (int)TabEnum.Transfer:
                    TransferForm tf = new TransferForm();
                    tf.Closed += (sender, args) => { Refresh(); };
                    Transfer t = (Transfer)transferGrid.SelectedItem;
                    if (t == null)
                        return;
                    tf.Title = t.Id.ToString();
                    tf.CabinetTb.Text = t.RoomNumber.ToString();
                    tf.WhereTb.Text = t.Where;
                    tf.DateTb.Text = t.TransferDate.ToShortDateString();
                    tf.Show();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
