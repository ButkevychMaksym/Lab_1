using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using YourNamespace.Models;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private Library _library = new Library(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            string yearText = YearTextBox.Text;
            string isbn = ISBNTextBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(yearText) || string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(yearText, out int year))
            {
                MessageBox.Show("Year must be a valid number.");
                return;
            }

            var book = new Book(title, author, year, isbn);
            _library.AddBook(book);

            TitleTextBox.Clear();
            AuthorTextBox.Clear();
            YearTextBox.Clear();
            ISBNTextBox.Clear();

            MessageBox.Show("Book added successfully.");
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            string isbn = ISBNTextBox.Text;

            if (string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Please enter ISBN.");
                return;
            }

            bool removed = _library.RemoveBook(isbn);
            if (removed)
            {
                MessageBox.Show("Book removed successfully.");
            }
            else
            {
                MessageBox.Show("Book not found.");
            }

            TitleTextBox.Clear();
            AuthorTextBox.Clear();
            YearTextBox.Clear();
            ISBNTextBox.Clear();
        }

        private void SearchByAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            string author = AuthorTextBox.Text;

            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Please enter author.");
                return;
            }

            var books = _library.SearchByAuthor(author);
            BooksListBox.ItemsSource = books;
        }

        private void SearchByTitleButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter title.");
                return;
            }

            var books = _library.SearchByTitle(title);
            BooksListBox.ItemsSource = books;
        }

        private void ListAllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            var books = _library.GetAllBooks();
            BooksListBox.ItemsSource = books;
        }
    }
}
