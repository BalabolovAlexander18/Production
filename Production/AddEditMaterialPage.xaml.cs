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
        public int? ТекущееКолНаСкладе;
        private Материалы _currentMaterial = new Материалы();
        public AddEditMaterialPage(Материалы selectedMaterial)
        {
            InitializeComponent();
            if (selectedMaterial != null)
            {
                _currentMaterial = selectedMaterial;
                ТекущееКолНаСкладе = _currentMaterial.КолНаСкладе;
            }
            else
            {
                ТекущееКолНаСкладе = -1;
            }


            DataContext = _currentMaterial;
            if (UserRights.User_ID == 2)
            {
                tebType.IsEnabled = false;
                tebName.IsEnabled = false;
                tebMinCol.IsEnabled = false;
                tebSuppliers.IsEnabled = false;
            }
            
            //comboBox.ItemsSource = Production_of_productsEntities2.GetContext().Поставщики.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentMaterial.Тип))
                errors.AppendLine("Укажите тип материала");
            if (string.IsNullOrWhiteSpace(_currentMaterial.Наименование))
                errors.AppendLine("Введите название");

            if (int.TryParse(tebMinCol.Text, out int m))
            {
                if (m < 0)
                    errors.AppendLine("Минимальным количеством должно быть положительное число");
            }
            else { errors.AppendLine("Не правильно введено минимальное количество"); }
            
            if (int.TryParse(tebRemains.Text, out int n))
            {
                if (n < 0)
                    errors.AppendLine("Остатком может быть только натуральное положительное число");
            }
            else errors.AppendLine("Не правильно введён остаток");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }  

            if (_currentMaterial.id == 0)
                Production_of_productsEntities2.GetContext().Материалы.Add(_currentMaterial);

            try
            {
                Production_of_productsEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }

            if (ТекущееКолНаСкладе != _currentMaterial.КолНаСкладе && ТекущееКолНаСкладе != -1)
            {
                var TempHistoryMaterial = new ИсторияИзмКолМатер
                {
                    Дата = DateTime.Now,
                    id_материала = _currentMaterial.id,
                    НовоеКол = _currentMaterial.КолНаСкладе
                };
                Production_of_productsEntities2.GetContext().ИсторияИзмКолМатер.Add(TempHistoryMaterial);
                Production_of_productsEntities2.GetContext().SaveChanges();
            }
        }
    }
}
