using Book_App_Vasile_Andrei_Dragos.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Book_App_Vasile_Andrei_Dragos.Views
{
    /// <summary>
    /// Interaction logic for ListAuthors.xaml
    /// </summary>
    public partial class ListAuthors : Page
    {
        public ListAuthors()
        {
            InitializeComponent();
            this.DataContext = new AuthorViewModel();
        }

        public void NavigateToUpdateAuthor(object sender, RoutedEventArgs e)
        {
            string selectedAuthorId = ((Button)sender).Tag.ToString();
            this.NavigationService.Navigate(new AddAuthor(selectedAuthorId));
        }
    }
}
