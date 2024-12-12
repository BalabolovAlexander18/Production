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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage());
            Manager.MainFrame = MainFrame;
            //ImportTours();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\oleg-\OneDrive\Рабочий стол\Разработка ПМ\УП.01.01\2 Задание\Сессия 1\Материалы.txt");
            var images = Directory.GetFiles(@"C:\Users\oleg-\OneDrive\Рабочий стол\Разработка ПМ\УП.01.01\2 Задание\Сессия 1\Материалы");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempProduct = new Материалы
                {
                    Наименование = Convert.ToString(data[0]),
                    Тип = Convert.ToString(data[1]),
                    Цена = int.Parse(data[3]),
                    КолНаСкладе = int.Parse(data[4]),
                    МинКол = int.Parse(data[5]),
                    КолвУпаковке = int.Parse(data[6]),
                    ЕдинИзмер = Convert.ToString(data[7])
                };
                string NameFoto = data[2];
                try
                {
                    tempProduct.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(NameFoto)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Production_of_productsEntities1.GetContext().Материалы.Add(tempProduct);
                Production_of_productsEntities1.GetContext().SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack) 
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;
        }
    }
}

/*
private static Production_of_productsEntities _context;

        public Production_of_productsEntities()
            : base("name=Production_of_productsEntities")
        {
        }
        public static Production_of_productsEntities GetContext()
        {
            if (_context == null)
                _context = new Production_of_productsEntities();
            return _context;
        }
*/