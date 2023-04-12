using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace pract18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Accounting_of_medicinesEntities db = ModelExtention.GetContent();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Medicines.Load();
            DataGrid.ItemsSource = db.Medicines.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Medicine row = (Medicine)DataGrid.Items[indexRow];
                Data.Name = row.Name_of_the_medicine;
                EditRecord editRecord = new EditRecord();
                editRecord.ShowDialog();
                DataGrid.Items.Refresh();
                DataGrid.Focus();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Medicine row = (Medicine)DataGrid.Items[indexRow];
                Data.Name = row.Name_of_the_medicine;
                ViewRecord viewRecord = new ViewRecord();
                viewRecord.ShowDialog();
                DataGrid.Focus();
            }
        }

        private void Remove_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int indexRow = DataGrid.SelectedIndex;
                    if (indexRow != -1)
                    {
                        Medicine row = (Medicine)DataGrid.Items[indexRow];
                        db.Medicines.Remove(row);
                        db.SaveChanges();
                        DataGrid.Focus();
                    }
                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        List<Medicine> med;
        private void Filtered_Click(object sender, RoutedEventArgs e)
        {
            med = db.Medicines.ToList();

            var nameFilter = from med in db.Medicines
                             where med.Name_of_the_medicine.Contains(txtFilter.Text)
                             select med;

            DataGrid.ItemsSource = nameFilter.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void del_click(object sender, RoutedEventArgs e) 
        {
            del d = new del();
            d.ShowDialog();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGrid.Items.Refresh();
        }
    }
}
