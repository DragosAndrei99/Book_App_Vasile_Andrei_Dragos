using Book_App_Vasile_Andrei_Dragos.ViewModels.Author;
using System.Windows;
using System.Windows.Controls;


namespace Book_App_Vasile_Andrei_Dragos.Views.Author
{
    public partial class ListAuthors : Page
    {
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
    }
}
