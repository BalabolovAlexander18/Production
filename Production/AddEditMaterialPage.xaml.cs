using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        byte[] image_bytes;
        public int? ТекущееКолНаСкладе;
        private Материалы _currentMaterial = new Материалы();
        CurrentMaterial currentMaterial2 = new CurrentMaterial();
        //private Материалы _currentMaterial2;
        private struct CurrentMaterial
        {
            public string Тип;
            public string Наименование;
            public string МинКол;
            public string КолНаСкладе;
            public string НаименованияПоставщиков;
            public byte[] Изображение;
        }

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

            
            currentMaterial2.Тип = _currentMaterial.Тип;
            currentMaterial2.Наименование = _currentMaterial.Наименование;
            currentMaterial2.МинКол = Convert.ToString(_currentMaterial.МинКол);
            currentMaterial2.КолНаСкладе = Convert.ToString(_currentMaterial.КолНаСкладе);
            currentMaterial2.НаименованияПоставщиков = Convert.ToString(_currentMaterial.НаименованияПоставщиков);
            currentMaterial2.Изображение = _currentMaterial.Изображение;

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

            if (currentMaterial2.Тип == _currentMaterial.Тип && currentMaterial2.Наименование == _currentMaterial.Наименование &&
                currentMaterial2.МинКол == Convert.ToString(_currentMaterial.МинКол) && currentMaterial2.КолНаСкладе == Convert.ToString(_currentMaterial.КолНаСкладе) &&
                currentMaterial2.НаименованияПоставщиков == Convert.ToString(_currentMaterial.НаименованияПоставщиков) && currentMaterial2.Изображение == _currentMaterial.Изображение)
            {
                if (MessageBox.Show("Данные не были изменены", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    Manager.MainFrame.GoBack();
                }
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

        private void btnDownloadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            try
            {
                image_bytes = File.ReadAllBytes(openFileDialog.FileName);
                _currentMaterial.Изображение = image_bytes;
                if (image_bytes != null)
                {
                    using (var stream = new MemoryStream(image_bytes))
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad; // Параметр кэширования
                        bitmap.EndInit();
                        bitmap.Freeze(); // Делаем BitmapImage потоко-независимым

                        imMaterial.Source = bitmap; // Устанавливаем Source для imMaterial
                    }
                }
            }
            catch 
            {
                if (_currentMaterial.Изображение == null)
                {
                    MessageBox.Show("Выберите картинку!", "Рекомендация", MessageBoxButton.OK, MessageBoxImage.Warning);
                } 
            }
        }
    }
}
