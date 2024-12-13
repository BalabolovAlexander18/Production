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
    /// Логика взаимодействия для AddEditSuppliersPage.xaml
    /// </summary>
    public partial class AddEditSuppliersPage : Page
    {
        private Поставщики _currentSupplier = new Поставщики();
        public AddEditSuppliersPage(Поставщики selectedSupplier)
        {
            InitializeComponent();

            if (selectedSupplier != null)
                _currentSupplier = selectedSupplier;

            DataContext = _currentSupplier;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSupplier.НаименПоставщ))
                errors.Append("Укажите наименование поставщика");
            if (string.IsNullOrWhiteSpace(_currentSupplier.Тип))
                errors.Append("Укажите тип");
            if (_currentSupplier.ИНН == null)
                errors.Append("Укажите ИНН");
            if (_currentSupplier.РейтингКачества < 1)
                errors.Append("Укажите рейтинг");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            _currentSupplier.ДатаНачалаРаб = DateTime.Now;

            if (_currentSupplier.id == 0)
                Production_of_productsEntities1.GetContext().Поставщики.Add(_currentSupplier);

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
