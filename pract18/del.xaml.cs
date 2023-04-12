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
using System.Windows.Shapes;

namespace pract18
{
    /// <summary>
    /// Логика взаимодействия для del.xaml
    /// </summary>
    public partial class del : Window
    {
        Accounting_of_medicinesEntities db = new Accounting_of_medicinesEntities();
        public del()
        {
            InitializeComponent();
            GB1.Visibility= Visibility.Hidden;
            GB2.Visibility= Visibility.Hidden;
        }



        private void G1(object sender, RoutedEventArgs e)
        {
           if (CB1.IsChecked == true) { GB1.IsEnabled = true; GB1.Visibility = Visibility.Visible; }
            else { GB1.IsEnabled = false; GB1.Visibility = Visibility.Hidden; }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (T1.Text.Length > 0)
                    {
                        db.Database.ExecuteSqlCommand($"DELETE FROM Medicines WHERE [Factory name]='{T1.Text}'");
                        MessageBox.Show("Запись успешно удалена");
                        this.Close();
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

       

        private void G2(object sender, RoutedEventArgs e)
        {
            if (CB2.IsChecked == true) { GB2.IsEnabled = true; GB2.Visibility = Visibility.Visible; }
            else { GB2.IsEnabled = false; GB2.Visibility = Visibility.Hidden; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (T2.Text.Length > 0)
                    {
                        db.Database.ExecuteSqlCommand($"DELETE FROM Medicines WHERE [Number of units]='{T2.Text}'");
                        MessageBox.Show("Запись успешно удалена");
                        this.Close();
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
    }
}
