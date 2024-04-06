using Book_App_Vasile_Andrei_Dragos.ViewModels.Author;
using System;
using System.Windows.Controls;

namespace Book_App_Vasile_Andrei_Dragos.Views.Author
{
    public partial class Author : Page
    {
        public Author(string authorId)
        {
            InitializeComponent();
            this.DataContext = new AuthorViewModel(authorId);
        }

        private void HandleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/Author/ListAuthors.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
