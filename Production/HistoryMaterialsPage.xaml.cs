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
    /// Логика взаимодействия для HistoryMaterialsPage.xaml
    /// </summary>
    public partial class HistoryMaterialsPage : Page
    {
        public HistoryMaterialsPage()
        {
            InitializeComponent();
            livHistoryMaterial.ItemsSource = Production_of_productsEntities2.GetContext().ИсторияИзмКолМатер.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentMaterials = Production_of_productsEntities2.GetContext().ИсторияИзмКолМатер.ToList();
            currentMaterials = currentMaterials.Where(p => p.СписокМатериалов.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            livHistoryMaterial.ItemsSource = currentMaterials;
        }
    }
}
