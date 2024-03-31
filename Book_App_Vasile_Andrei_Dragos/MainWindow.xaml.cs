using Book_App_Vasile_Andrei_Dragos.Views;
using System;
using System.Windows;


namespace Book_App_Vasile_Andrei_Dragos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddAuthorSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new AddAuthor(null));
        }

        private void ListAuthorsSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Uri("Views/ListAuthors.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
