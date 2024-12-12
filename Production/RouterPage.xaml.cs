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
    /// Логика взаимодействия для RouterPage.xaml
    /// </summary>
    public partial class RouterPage : Page
    {
        public int WhoIsIt;
        public RouterPage(int who)
        {
            InitializeComponent();
            WhoIsIt = who;
            if (WhoIsIt == 1)
                btnMaterials.IsEnabled = true;
            //if (WhoIsIt == 2) 
                //btnMaterials.IsEnabled = false;

        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialPage(WhoIsIt));
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SuppliersPage());
        }
    }
}
