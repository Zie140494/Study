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
    public partial class MainWindow : Window,IDisposable
    {
        DataContext db = new DataContext();
        int tabIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex!=TabIndex)
                Refresh();
            TabIndex = tabControl.SelectedIndex;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.User:
                    db.Users.Remove((User)userGrid.SelectedItem);
                    db.SaveChanges();
                    userGrid.ItemsSource = db.Users
                                            .Include(nameof(SysBlock))
                                            .Include(nameof(Monitor))
                                            .Include(nameof(Printer))
                                            .Include(nameof(Phone))
                                            .ToList();
                    break;
                case (int)TabEnum.SysBlock:
                    db.SysBlocks.Remove((SysBlock)sysBlockGrid.SelectedItem);
                    db.SaveChanges();
                    sysBlockGrid.ItemsSource = db.SysBlocks.ToList();
                    break;
                case (int)TabEnum.Monitor:
                    db.Monitors.Remove((Monitor)monitorGrid.SelectedItem);
                    db.SaveChanges();
                    monitorGrid.ItemsSource = db.Monitors.ToList();
                    break;
                case (int)TabEnum.Printer:
                    db.Printers.Remove((Printer)printerGrid.SelectedItem);
                    db.SaveChanges();
                    printerGrid.ItemsSource = db.Printers.ToList();
                    break;
                case (int)TabEnum.Phone:
                    db.Phones.Remove((Phone)phoneGrid.SelectedItem);
                    db.SaveChanges();
                    phoneGrid.ItemsSource = db.Phones.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.User:
                    UserForm uf = new UserForm();
                    uf.Closed += (sender, args) => { Refresh(); }; 
                    uf.Show();
                    break;
                case (int)TabEnum.SysBlock:
                    SysBlockForm sf = new SysBlockForm();
                    sf.Closed += (sender, args) => { Refresh(); };
                    sf.Show();
                    sysBlockGrid.ItemsSource = db.SysBlocks.ToList();
                    break;
                case (int)TabEnum.Monitor:
                    MonitorForm mf = new MonitorForm();
                    mf.Closed += (sender, args) => { Refresh(); };
                    mf.Show();
                    monitorGrid.ItemsSource = db.Monitors.ToList();
                    break;
                case (int)TabEnum.Printer:
                    PrinterForm pf = new PrinterForm();
                    pf.Closed += (sender, args) => { Refresh(); };
                    pf.Show();
                    printerGrid.ItemsSource = db.Printers.ToList();
                    break;
                case (int)TabEnum.Phone:
                    PhoneForm ph = new PhoneForm();
                    ph.Closed += (sender, args) => { Refresh(); };
                    ph.Show();
                    phoneGrid.ItemsSource = db.Phones.ToList();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)TabEnum.User:
                    UserForm uf = new UserForm();
                    
                    uf.Closed += (sender, args) => { Refresh(); };
                    User u = (User)userGrid.SelectedItem;
                    if (u == null)
                        return;
                    uf.Title = u.Id.ToString();
                    uf.NameTb.Text = u.Name;
                    uf.PositionTb.Text = u.Position;
                    uf.sysBlockTb.Text = u.SysBlock == null ? "" : u.SysBlock.Id.ToString();
                    uf.monitorTb.Text = u.Monitor == null ? "" : u.Monitor.Id.ToString();
                    uf.phoneTb.Text = u.Phone == null ? "" : u.Phone.Id.ToString();
                    uf.printerTb.Text = u.Printer == null ? "" : u.Printer.Id.ToString();
                    uf.Show();
                    break;
                case (int)TabEnum.SysBlock:
                    SysBlockForm sf = new SysBlockForm();
                    sf.Closed += (sender, args) => { Refresh(); };
                    SysBlock s = (SysBlock)sysBlockGrid.SelectedItem;
                    if (s == null)
                        return;
                    sf.Title = s.Id.ToString();
                    sf.DateTb.Text = s.DateOfPurchase.ToString();
                    sf.ModelTb.Text = s.Model;
                    sf.ProviderTb.Text = s.Provider;
                    sf.SerialTb.Text = s.SerialNumber;
                    sf.TypeTb.Text = s.TypeDevice;
                    sf.StatusTb.IsChecked = s.Status;
                    sf.CPUTb.Text = s.CPU;
                    sf.FrequencyTb.Text = s.Frequency;
                    sf.RAMTb.Text = s.RAM;
                    sf.HDDTb.Text = s.HDD;
                    sf.Show();
                    break;
                case (int)TabEnum.Monitor:
                    MonitorForm mf = new MonitorForm();
                    mf.Closed += (sender, args) => { Refresh(); };
                    Monitor m = (Monitor)monitorGrid.SelectedItem;
                    if (m == null)
                        return;
                    mf.Title = m.Id.ToString();
                    mf.DateTb.Text = m.DateOfPurchase.ToString();
                    mf.ModelTb.Text = m.Model;
                    mf.ProviderTb.Text = m.Provider;
                    mf.SerialTb.Text = m.SerialNumber;
                    mf.TypeTb.Text = m.TypeDevice;
                    mf.StatusTb.IsChecked = m.Status;
                    mf.DiagonalTb.Text = m.Diagonal;
                    mf.Show();
                    break;
                case (int)TabEnum.Printer:
                    PrinterForm pf = new PrinterForm();
                    pf.Closed += (sender, args) => { Refresh(); };
                    Printer p = (Printer)printerGrid.SelectedItem;
                    if (p == null)
                        return;
                    pf.Title = p.Id.ToString();
                    pf.DateTb.Text = p.DateOfPurchase.ToString();
                    pf.ModelTb.Text = p.Model;
                    pf.ProviderTb.Text = p.Provider;
                    pf.SerialTb.Text = p.SerialNumber;
                    pf.TypeTb.Text = p.TypeDevice;
                    pf.StatusTb.IsChecked = p.Status;
                    pf.Show();
                    break;
                case (int)TabEnum.Phone:
                    PhoneForm phf = new PhoneForm();
                    phf.Closed += (sender, args) => { Refresh(); };
                    Phone ph = (Phone)phoneGrid.SelectedItem;
                    if (ph == null)
                        return;
                    phf.Title = ph.Id.ToString();
                    phf.DateTb.Text = ph.DateOfPurchase.ToString();
                    phf.ModelTb.Text = ph.Model;
                    phf.ProviderTb.Text = ph.Provider;
                    phf.SerialTb.Text = ph.SerialNumber;
                    phf.TypeTb.Text = ph.TypeDevice;
                    phf.StatusTb.IsChecked = ph.Status;
                    phf.Show();
                    break;
                default:
                    throw new Exception("Такой вкладки не сущесвует");
            }
        }

        private void Refresh()
        {
            db = new DataContext();
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

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
