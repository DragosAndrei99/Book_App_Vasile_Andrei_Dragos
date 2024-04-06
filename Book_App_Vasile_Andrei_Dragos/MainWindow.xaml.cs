using Book_App_Vasile_Andrei_Dragos.Views.Author;
using Book_App_Vasile_Andrei_Dragos.Views.Book;
using System;
using System.Windows;


namespace Book_App_Vasile_Andrei_Dragos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddAuthorSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Author(null));
        }

        private void ListAuthorsSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Uri("Views/Author/ListAuthors.xaml", UriKind.RelativeOrAbsolute));
        }

        public void AddBookSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Book(null));
        }

        private void ListBooksSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Uri("Views/Book/ListBooks.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
