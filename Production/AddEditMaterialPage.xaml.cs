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
        public int WhoIsIt;
        private Материалы _currentMaterial = new Материалы();
        public AddEditMaterialPage(int Who, Материалы selectedMaterial)
        {
            WhoIsIt = Who;
            InitializeComponent();
            if (selectedMaterial != null)
                _currentMaterial = selectedMaterial;

            DataContext = _currentMaterial;
            if (WhoIsIt == 2)
            {
                tebType.IsEnabled = false;
                tebName.IsEnabled = false;
                tebMinCol.IsEnabled = false;
                tebSuppliers.IsEnabled = false;
            }
            
            //comboBox.ItemsSource = Production_of_productsEntities1.GetContext().Поставщики.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentMaterial.Тип))
                errors.AppendLine("Укажите тип материала");
            if (string.IsNullOrWhiteSpace(_currentMaterial.Наименование))
                errors.AppendLine("Введите название");

            if (errors.Length > 0)
                MessageBox.Show(errors.ToString());

            if (_currentMaterial.id == 0)
                Production_of_productsEntities1.GetContext().Материалы.Add(_currentMaterial);

            try
            {
                Production_of_productsEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
