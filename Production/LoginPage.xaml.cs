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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "м" && PasBox.Password == "777")
            {
                UserRights.User_ID = 1;
                Manager.MainFrame.Navigate(new RouterPage());
            }
            else if (textBoxLogin.Text == "с" && PasBox.Password == "777")
            {
                UserRights.User_ID = 2;
                Manager.MainFrame.Navigate(new RouterPage());
            }
            else
            {
                MessageBox.Show("Невверный логин или пароль!!! Попробуйте ввести их ещё раз!");
            }
            //Manager.MainFrame.Navigate(new RouterPage(2));
        }
    }
}
