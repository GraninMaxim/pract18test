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
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
        }

        Accounting_of_medicinesEntities db = ModelExtention.GetContent();
        Medicine record1;

        private void EditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            record1 = db.Medicines.Find(Data.Name);
            name.Text = record1.Name_of_the_medicine;
            cost.Text = record1.Cost.ToString();
            number.Text = record1.Number_of_units.ToString();
            productDate.Text = record1.Product_date.ToString();
            exspirationDate.Text = record1.Expiration_date.ToString();
            factoryName.Text = record1.Factory_name;
            factoryAddress.Text = record1.Factory_address;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (name.Text.Length == 0) errors.AppendLine("Введите название лекарства");
            if (factoryName.Text.Length == 0) errors.AppendLine("Введите название фабрики");
            if (productDate.Text.Length != 0 && exspirationDate.Text.Length != 0)
            {
                System.DateTime prodDate = Convert.ToDateTime(productDate.Text);
                System.DateTime exspirDate = Convert.ToDateTime(exspirationDate.Text);
                if (exspirDate < prodDate) errors.AppendLine("Дата производства не может быть больше срока годности." +
                    "Введите корректныую информацию!");
            }
            record1.Name_of_the_medicine = name.Text;
            record1.Cost = Convert.ToDecimal(cost.Text);
            record1.Number_of_units = Convert.ToInt32(number.Text);
            record1.Product_date = Convert.ToDateTime(productDate.Text);
            record1.Expiration_date = Convert.ToDateTime(exspirationDate.Text);
            record1.Factory_name = factoryName.Text;
            record1.Factory_address = factoryAddress.Text;
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Данные введены неверно!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Изменения сохранены!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
