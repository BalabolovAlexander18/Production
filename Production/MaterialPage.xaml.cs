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
    /// Логика взаимодействия для MaterialPage.xaml
    /// </summary>
    public partial class MaterialPage : Page
    {
        public MaterialPage()
        {
            InitializeComponent();
            LViewMaterial.ItemsSource = Production_of_productsEntities2.GetContext().Материалы.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMaterialPage((sender as Button).DataContext as Материалы));
            LViewMaterial.ItemsSource = Production_of_productsEntities2.GetContext().Материалы.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditMaterialPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var materialRemoving = LViewMaterial.SelectedItems.Cast<Материалы>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {materialRemoving.Count()} элементов", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var material in materialRemoving)
                    {
                        var itemsToRemove = Production_of_productsEntities2.GetContext().ИсторияИзмКолМатер.Where(p => p.id_материала == material.id).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            Production_of_productsEntities2.GetContext().ИсторияИзмКолМатер.Remove(item);
                        }
                    }

                    Production_of_productsEntities2.GetContext().Материалы.RemoveRange(materialRemoving);
                    Production_of_productsEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LViewMaterial.ItemsSource = Production_of_productsEntities2.GetContext().Материалы.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LViewMaterial.ItemsSource = Production_of_productsEntities2.GetContext().Материалы.ToList();
        }
    }
}

/*
 public string НаименованияПоставщиков => string.Join(", ", Поставщики.Select(p => p.НаименПоставщ).Where(n => !string.IsNullOrEmpty(n)).DefaultIfEmpty("Не указано"));
        public string МинКолИЕдинИзмер => $"{МинКол.ToString()} {ЕдинИзмер}";
        public string КолНаСкладеИЕдинИзмер => $"{КолНаСкладе.ToString()} {ЕдинИзмер}";
 */