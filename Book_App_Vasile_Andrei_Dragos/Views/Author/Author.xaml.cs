using System;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.ViewModels.Author;

namespace Book_App_Vasile_Andrei_Dragos.Views.Author
{
    public partial class Author : Page
    {
        public Author(string authorId)
        {
            InitializeComponent();
            this.DataContext = new AuthorViewModel(authorId);
            if (authorId != null)
            {
                Button modifyButton = (Button)FindName("modifyButton");
                modifyButton.Content = "Modifica";
            }
        }

        private void HandleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/Author/ListAuthors.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
