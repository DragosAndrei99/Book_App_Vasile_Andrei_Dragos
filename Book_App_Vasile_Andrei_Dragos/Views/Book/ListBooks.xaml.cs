using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.ViewModels.Book;


namespace Book_App_Vasile_Andrei_Dragos.Views.Book
{

    public partial class ListBooks : Page
    {
        private IEnumerable<BookWithAuthors> _bookWithAuthorsList = new List<BookWithAuthors>();   
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

        private void HandleKeyUpSearch(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(_bookWithAuthorsList.Count() == 0)
            {
                _bookWithAuthorsList = ((IEnumerable<BookWithAuthors>)listBooksDataGrid.ItemsSource).ToList();
            }
            listBooksDataGrid.ItemsSource = _bookWithAuthorsList.Where(book => book.Title.ToLower().Contains(searchTitleTextBox.Text.ToLower()) && book.Authors.ToLower().Contains(searchAuthorsTextBox.Text.ToLower()));
        }
    }   
}
