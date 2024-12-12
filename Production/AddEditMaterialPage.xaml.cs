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
    /// Логика взаимодействия для AddEditMaterialPage.xaml
    /// </summary>
    public partial class AddEditMaterialPage : Page
    {
        private Материалы _currentMaterial = new Материалы();
        public AddEditMaterialPage(Материалы selectedMaterial)
        {
            InitializeComponent();
            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;

            DataContext = _currentMaterial;
            //comboBox.ItemsSource = Production_of_productsEntities1.GetContext().Поставщики.ToList();
        }
    }
}
