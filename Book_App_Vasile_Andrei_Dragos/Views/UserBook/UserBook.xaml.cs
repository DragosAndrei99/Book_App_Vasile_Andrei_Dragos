using Book_App_Vasile_Andrei_Dragos.ViewModels.UserBook;
using System;
using System.Windows.Controls;


namespace Book_App_Vasile_Andrei_Dragos.Views.UserBook
{

    public partial class UserBook : Page
    {
        public UserBook(string userBookId)
        {
            InitializeComponent();
            this.DataContext = new UserBookViewModel(userBookId);
        }

        private void HandleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/UserBook/ListUserBooks.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
