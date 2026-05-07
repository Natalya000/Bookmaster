using Bookmaster.AppData;
using Bookmaster.Models;
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

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        List<City> _cities = App.GetContext().Cities.ToList();
        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();
            Title = "Редактирование читателя";
            AddBtn.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Visible;

            CityCmb.ItemsSource = _cities;
        }
        public AddEditCustomerWindow()
        {
            InitializeComponent();
            Title = "Добавление читателя";
            AddBtn.Visibility= Visibility.Visible;
            SaveBtn.Visibility= Visibility.Collapsed;

            CityCmb.ItemsSource = _cities;

            IDTb.Text = GenerateId();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTb.Text) ||
                string.IsNullOrWhiteSpace(AdressTb.Text) ||
                string.IsNullOrWhiteSpace(EmailTb.Text) ||
                string.IsNullOrWhiteSpace(PhoneTb.Text) ||
                string.IsNullOrWhiteSpace(ZipTb.Text))
            {
                FeedbackService.Error("Заполните все поля!");
            }
            else
            {
                try
                {
                    Customer newCastomer = new Customer()
                    {
                        Id = IDTb.Text,
                        Name = NameTb.Text,
                        Address = AdressTb.Text,
                        CityId = (int)CityCmb.SelectedValue,
                        Phone = PhoneTb.Text,
                        Email = EmailTb.Text,
                        Zip = ZipTb.Text,
                    };
                    App.GetContext().Customers.Add(newCastomer);

                    App.GetContext().SaveChanges();

                    FeedbackService.Information("Читатель успешно добавлен!");

                    DialogResult = true;
                }
                catch (Exception exception)
                {
                    FeedbackService.Error(exception);
                }
            }
        }
        private string GenerateId()
        {
            int lastId = Convert.ToInt32(App.GetContext().Customers.Max(c => c.Id).Substring(1));

            ++lastId;

            return $"C{lastId}";
        }
    }
}
