using Book_App_Vasile_Andrei_Dragos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void AddAuthorSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Uri("Views/AddAuthor.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ListAuthorsSubMenuClick(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new Uri("Views/ListAuthors.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
