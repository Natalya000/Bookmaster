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
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        //определяем контекст данных
        private readonly Bookmaster36Context _context;
        // инациализируем список для хранения элементов типа Book
        private List<Book> _books = new List<Book>();
        public BrowseCatalogPage()
        {
            InitializeComponent();
            // инициализируем контекст данных
            _context = new Bookmaster36Context();

            // в список _books присваиваем записи из таблиц BookAuthor
            _books = _context.Books.ToList();
            BookAuthorLv.ItemsSource = _books;
        }

        private void SearchBookBtn_Click(object sender, RoutedEventArgs e)
        {
            string bookTitle = BookTitleTb.Text;
            string authorName = AuthorNameTb.Text;
            string bookGenre = BookGenreTb.Text;

            if (string.IsNullOrWhiteSpace(bookTitle) &&
                string.IsNullOrWhiteSpace(authorName) &&
                string.IsNullOrWhiteSpace(bookGenre))
            {
                BookAuthorLv.ItemsSource = _books;
                return;
            }

            var filteredBooks = _books.Where(book => book.Title.ToLower().Contains(bookTitle) &&
                                                     book.Authors.ToLower().Contains(authorName) &&
                                                     book.Subjects.ToLower().Contains(bookGenre));

            BookAuthorLv.ItemsSource = filteredBooks;
        }

        private void BookAuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            if (BookAuthorLv.SelectedItem is Book selectedBook)
            {
                BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow(selectedBook.BookAuthors);
                bookAuthorsDetailsWindow.ShowDialog();
            }
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookAuthorLv.SelectedItem is Book selectedBook)
            {
                DataContext = selectedBook;

            }
        }
    }
}
