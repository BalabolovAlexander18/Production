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

                Production_of_productsEntities2.GetContext().Материалы.Add(tempProduct);
                Production_of_productsEntities2.GetContext().SaveChanges();
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

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            labHeading.Margin = new Thickness(0, 0, 0, 0);
            var Page = e.Content as Page;
            if (Page != null)
            {
                if (Page is LoginPage)
                {
                    labHeading.Content = "Авторизация";
                }
                else if (Page is RouterPage)
                {
                    labHeading.Content = "Навигация";
                }
                else if (Page is MaterialPage)
                {
                    labHeading.Content = "Материалы";
                }
                else if (Page is SuppliersPage)
                {
                    labHeading.Content = "Поставщики";
                }
                else if (Page is HistoryMaterialsPage)
                {
                    labHeading.Margin = new Thickness(80, 0, 200, 0);
                    labHeading.Content = "История изменения материалов";
                }
                else if (Page is AddEditMaterialPage)
                {
                    if (UserRights.HeadingPage == "AddM")
                    {
                        labHeading.Content = "Добавление материала";
                    }
                    else if (UserRights.HeadingPage == "EditM")
                    {
                        labHeading.Margin = new Thickness(80, 0, 200, 0);
                        labHeading.Content = "Редактирование материала";
                    }     
                }
                else if (Page is AddEditSuppliersPage)
                {
                    if (UserRights.HeadingPage == "AddS")
                    {
                        labHeading.Content = "Добавление поставщика";
                    }
                    else if (UserRights.HeadingPage == "EditS")
                    {
                        labHeading.Margin = new Thickness(80, 0, 200, 0);
                        labHeading.Content = "Редактирование поставщика";
                    }
                }
                else if (Page is ExportPage)
                {
                    labHeading.Content = "Импорт данных";
                }
            }
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