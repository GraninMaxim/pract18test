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
    /// Логика взаимодействия для ViewRecord.xaml
    /// </summary>
    public partial class ViewRecord : Window
    {
        public ViewRecord()
        {
            InitializeComponent();
        }

        Accounting_of_medicinesEntities db = ModelExtention.GetContent();
        Medicine record1 = new Medicine();

        private void ViewWindow_Loaded(object sender, RoutedEventArgs e)
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

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
