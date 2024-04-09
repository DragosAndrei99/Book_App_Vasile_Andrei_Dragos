using System.Windows;
using System.Windows.Controls;
using Book_App_Vasile_Andrei_Dragos.ViewModels.UserBook;


namespace Book_App_Vasile_Andrei_Dragos.Views.UserBook
{

    public partial class ListUserBook: Page
    {
        public ListUserBook()
        {
            InitializeComponent();
            this.DataContext = new ListUserBookViewModel();
        }

        public void NavigateToUpdateUserBook(object sender, RoutedEventArgs e)
        {
            string selectedUserBookId = ((Button)sender).Tag.ToString();
            this.NavigationService.Navigate(new UserBook(selectedUserBookId));
        }
    }
}
