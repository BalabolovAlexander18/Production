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
    /// Логика взаимодействия для MaterialPage.xaml
    /// </summary>
    public partial class MaterialPage : Page
    {
        public int WhoIsIt;
        public MaterialPage(int who)
        {
            WhoIsIt = who;
            InitializeComponent();
            LViewTours.ItemsSource = Production_of_productsEntities1.GetContext().Материалы.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMaterialPage(WhoIsIt, (sender as Button).DataContext as Материалы));
            LViewTours.ItemsSource = Production_of_productsEntities1.GetContext().Материалы.ToList();
        }
    }
}
