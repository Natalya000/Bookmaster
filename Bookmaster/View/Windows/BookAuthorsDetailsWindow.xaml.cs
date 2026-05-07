using Bookmaster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для BookAuthorsDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailsWindow : Window
    {
        public BookAuthorsDetailsWindow(ICollection<BookAuthor> bookAuthors)
        {
            InitializeComponent();

            AuthorsCmb.ItemsSource = bookAuthors;
            AuthorsCmb.SelectedIndex = 0;
            AuthorsCmb.DisplayMemberPath = "Author.Name";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (AuthorsCmb.SelectedItem is BookAuthor bookAuthor)
            {
                DataContext = bookAuthor;

                Title = $"Авторы книги \"{bookAuthor.Book.Title}\"";
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
