using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.Models.Author;
using Book_App_Vasile_Andrei_Dragos.ViewModels.Author;


namespace Book_App_Vasile_Andrei_Dragos.Views.Author
{
    public partial class ListAuthors : Page
    {
        private IEnumerable<AuthorDTO> _authorsList = new List<AuthorDTO>();
        public ListAuthors()
        {
            InitializeComponent();
            this.DataContext = new ListAuthorsViewModel();
        }

        public void NavigateToUpdateAuthor(object sender, RoutedEventArgs e)
        {
            string selectedAuthorId = ((Button)sender).Tag.ToString();
            this.NavigationService.Navigate(new Author(selectedAuthorId));
        }

        private void HandleKeyUpSearch(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_authorsList.Count() == 0)
            {
                _authorsList = ((IEnumerable<AuthorDTO>)listAuthorsDataGrid.ItemsSource).ToList();
            }
            listAuthorsDataGrid.ItemsSource = _authorsList.Where(author => author.LastName.ToLower().Contains(searchLastNameTextBox.Text.ToLower()));
        }
    }
}
