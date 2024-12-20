﻿using System;
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
        private CurrentSupplier currentSupplier2;
        private struct CurrentSupplier
        {
            public string НаименПоставщ;
            public string Тип;
            public long? ИНН;
            public int? РейтингКачества;
        }
        public AddEditSuppliersPage(Поставщики selectedSupplier)
        {
            InitializeComponent();

            if (selectedSupplier != null)
                _currentSupplier = selectedSupplier;

            DataContext = _currentSupplier;
            currentSupplier2.НаименПоставщ = _currentSupplier.НаименПоставщ;
            currentSupplier2.Тип = _currentSupplier.Тип;
            currentSupplier2.ИНН = _currentSupplier.ИНН;
            currentSupplier2.РейтингКачества = _currentSupplier.РейтингКачества;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSupplier.НаименПоставщ))
                errors.AppendLine("Укажите наименование поставщика");
            if (string.IsNullOrWhiteSpace(_currentSupplier.Тип))
                errors.AppendLine("Укажите тип");
            if (!long.TryParse(tebINN.Text, out long n))
                errors.AppendLine("Не верно указан ИНН");
            if (int.TryParse(tebRating.Text, out int m))
            {
                if (m < 0)
                    errors.AppendLine("Рейтинг должен быть положительным натуральным числом");
            }
            else errors.AppendLine("Не верно указан рейтинг");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentSupplier2.НаименПоставщ == _currentSupplier.НаименПоставщ && currentSupplier2.Тип == _currentSupplier.Тип &&
                currentSupplier2.ИНН == _currentSupplier.ИНН && currentSupplier2.РейтингКачества == _currentSupplier.РейтингКачества)
            {
                if (MessageBox.Show("Данные не были изменены", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    Manager.MainFrame.GoBack();
                }
                return;
            }

            _currentSupplier.ДатаНачалаРаб = DateTime.Now;

            if (_currentSupplier.id == 0)
                Production_of_productsEntities2.GetContext().Поставщики.Add(_currentSupplier);

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
        }
    }
}
