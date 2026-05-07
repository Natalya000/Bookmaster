using Azure;
using Bookmaster.AppData;
using Bookmaster.Models;
using Bookmaster.View.Windows;
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

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        //определяем контекст данных
        private readonly Bookmaster36Context _context;
        // инациализируем список для хранения элементов типа Book
        private List<Customer> _customers = new List<Customer>();
        public ManageCustomersPage()
        {
            InitializeComponent();
            // инициализируем контекст данных
            _context = new Bookmaster36Context();

            // в список _books присваиваем записи из таблиц BookAuthor
            _customers = _context.Customers.ToList();
            CustomerIDLv.ItemsSource = _customers;
        }

        private void SearchCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            string customerID = CustomerIDTb.Text;
            string customerName = CustomerNameTb.Text;

            if (string.IsNullOrWhiteSpace(customerID) &&
                string.IsNullOrWhiteSpace(customerName))
            {
                CustomerIDLv.ItemsSource = _customers;
                return;
            }

            var filteredCustomers = _customers.Where(customer => customer.Id.ToLower().Contains(customerID) &&
                                                     customer.Name.ToLower().Contains(customerName));

            CustomerIDLv.ItemsSource = filteredCustomers;
        }

        private void EditCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer? selectedCustomer = CustomerIDLv.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow(selectedCustomer);
                addEditCustomerWindow.ShowDialog();
                if(addEditCustomerWindow.ShowDialog() == true)
                {
                    CustomerIDLv.ItemsSource = _customers = App.GetContext().Customers.ToList();
                }
            }
            else
            {
                FeedbackService.Error("Вы не выбрали читателя!");
            }
                
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            if (addEditCustomerWindow.ShowDialog() == true)
            {
                CustomerIDLv.ItemsSource = _customers = App.GetContext().Customers.ToList();
            }
            
        }

        private void CustomerIDLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
