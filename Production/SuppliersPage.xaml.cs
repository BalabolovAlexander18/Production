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

namespace Production
{
    /// <summary>
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        public SuppliersPage()
        {
            InitializeComponent();
            livSuppliers.ItemsSource = Production_of_productsEntities1.GetContext().Поставщики.ToList();
            UpdateSuppliers();
        }

        private void UpdateSuppliers()
        {
            var currentSuppliers = Production_of_productsEntities1.GetContext().Поставщики.ToList();
            currentSuppliers = currentSuppliers.Where(p => p.ВсеМатериалы.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (checkRating.IsChecked == true)
            {
                currentSuppliers = currentSuppliers.OrderBy(p => p.РейтингКачества).ToList();
            }
            livSuppliers.ItemsSource = currentSuppliers;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSuppliers();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSuppliers();
        }
    }
}
