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
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        public SuppliersPage()
        {
            InitializeComponent();
            livSuppliers.ItemsSource = Production_of_productsEntities2.GetContext().Поставщики.ToList();
            UpdateSuppliers();
        }

        private void UpdateSuppliers()
        {
            var currentSuppliers = Production_of_productsEntities2.GetContext().Поставщики.ToList();
            currentSuppliers = currentSuppliers.Where(p => p.ВсеМатериалы.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (checkRating.IsChecked == true)
            {
                currentSuppliers = currentSuppliers.OrderBy(p => p.РейтингКачества).ToList();
            }
            livSuppliers.ItemsSource = currentSuppliers;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSuppliers();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSuppliers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Создать страницу для внесения и редактирования Производилей
            UserRights.HeadingPage = "AddS";
            Manager.MainFrame.Navigate(new AddEditSuppliersPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Реализовать удаление Производилей
            var suppliersRemoving = livSuppliers.SelectedItems.Cast<Поставщики>().ToList();
            if (suppliersRemoving.Count() == 0)
            {
                return;
            }
            if (MessageBox.Show($"Вы точно хотите удалить следующие {suppliersRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Production_of_productsEntities2.GetContext().Поставщики.RemoveRange(suppliersRemoving);
                    Production_of_productsEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    livSuppliers.ItemsSource = Production_of_productsEntities2.GetContext().Поставщики.ToList();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserRights.HeadingPage = "EditS";
            Manager.MainFrame.Navigate(new AddEditSuppliersPage((sender as Button).DataContext as Поставщики));
        }

        private void UpdateSuppliers(object sender, RoutedEventArgs e)
        {
            UpdateSuppliers();
        }
    }
}
/*
  public string ВсеМатериалы => string.Join(", ", Материалы.Select(p => p.Наименование).Where(n => !string.IsNullOrEmpty(n)).DefaultIfEmpty("Не Указано"));
 */