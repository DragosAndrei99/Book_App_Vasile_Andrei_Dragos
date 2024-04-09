using System;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.ViewModels.UserBook;


namespace Book_App_Vasile_Andrei_Dragos.Views.UserBook
{

    public partial class UserBook : Page
    {
        public UserBook(string userBookId)
        {
            InitializeComponent();
            this.DataContext = new UserBookViewModel(userBookId);
            if (userBookId != null)
            {
                Button modifyButton = (Button)FindName("modifyButton");
                modifyButton.Content = "Modifica";
                staticBookTitleTextBlock.Visibility = System.Windows.Visibility.Visible;
                dynamicBookTitleComboBox.Visibility = System.Windows.Visibility.Collapsed;

            }
            else
            {
                staticBookTitleTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                dynamicBookTitleComboBox.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void HandleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/UserBook/ListUserBooks.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
