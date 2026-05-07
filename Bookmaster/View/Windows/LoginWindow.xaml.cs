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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            CredentlaIsServise.Load(LoginTb, PasswordPb, RememberDataCb);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            CredentlaIsServise.Administrator = App.GetContext().Administrators.FirstOrDefault(a => a.Username == LoginTb.Text && a.Password == PasswordPb.Password);

            if (CredentlaIsServise.HasAdministrator)
            {
                if (RememberDataCb.IsChecked == true)
                {
                    CredentlaIsServise.Save(LoginTb.Text, PasswordPb.Password);
                }
                else
                {
                    CredentlaIsServise.Clear();
                }
                FeedbackService.Information("Пользователь успешно авторизовался.");

                DialogResult = true;
            }
            else
            {
                FeedbackService.Error("Пользователь не найден. Проверьте учётные данные.");
            }
        }
    }
}
