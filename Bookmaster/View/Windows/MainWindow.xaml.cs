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
using System.Windows.Shapes;
using Bookmaster.View.Pages;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            // Вход в систему
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                LibraryMi.Visibility = Visibility.Visible;
                LoginMi.Visibility = Visibility.Collapsed;
                LogoutMi.Visibility = Visibility.Visible;
            }
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {
            //Выход из системы
            LibraryMi.Visibility = Visibility.Collapsed;
            LoginMi.Visibility = Visibility.Visible;
            LogoutMi.Visibility = Visibility.Collapsed;
        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void ManageCastomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());

        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());

        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());

        }
    }
}
