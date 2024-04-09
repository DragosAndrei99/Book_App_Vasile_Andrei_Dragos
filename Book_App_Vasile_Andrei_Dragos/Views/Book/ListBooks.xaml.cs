using System.Windows;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.ViewModels.Book;


namespace Book_App_Vasile_Andrei_Dragos.Views.Book
{

    public partial class ListBooks : Page
    {
        public ListBooks()
        {
            InitializeComponent();
            this.DataContext = new ListBooksViewModel();
        }

        public void NavigateToUpdateBook(object sender, RoutedEventArgs e)
        {
            string selectedBookId = ((Button)sender).Tag.ToString();
            this.NavigationService.Navigate(new Book(selectedBookId));
        }
    }
}
