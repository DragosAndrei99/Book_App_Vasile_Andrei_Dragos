using Book_App_Vasile_Andrei_Dragos.Models;
using Book_App_Vasile_Andrei_Dragos.ViewModels;
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
    }
}
