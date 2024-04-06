using System;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.ViewModels.Book;

namespace Book_App_Vasile_Andrei_Dragos.Views.Book
{
    public partial class Book : Page
    {
        public Book(string bookId)
        {
            InitializeComponent();
            this.DataContext = new BookViewModel(bookId);
        }

        private void HandleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/Book/ListBooks.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
