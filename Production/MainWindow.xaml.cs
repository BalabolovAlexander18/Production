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
            //var currentTours = Production_of_productsEntities1.GetContext().Материалы.ToList();
            LViewTours.ItemsSource = Production_of_productsEntities1.GetContext().Материалы.ToList();
            //Manager.MainFrame.Navigate(new MaterialPage());
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

/*
 <TextBlock Text="{Binding Тип}" VerticalAlignment="Center" TextAlignment="Center" Width="390" 
                           TextWrapping="Wrap" HorizontalAlignment="Center" Margin="5 5" FontSize="26" Grid.Row="0"></TextBlock>
                        <TextBlock Text="{Binding Наименование}" Grid.Row="2" Margin="5 5 5 15" HorizontalAlignment="Center" FontSize="26" FontWeight="Bold"></TextBlock>
                        <TextBlock Text="{Binding МинКол}" Grid.Row="3" FontSize="14" HorizontalAlignment="Right"></TextBlock>
                        <TextBlock Text="{Binding Поставщики}" Grid.Row="3" FontSize="14" HorizontalAlignment="Left"></TextBlock>
 
 */