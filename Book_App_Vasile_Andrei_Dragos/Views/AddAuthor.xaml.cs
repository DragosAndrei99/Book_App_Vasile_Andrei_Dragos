using Book_App_Vasile_Andrei_Dragos.ViewModels;
using System;
using System.Windows.Controls;

namespace Book_App_Vasile_Andrei_Dragos.Views
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class AddAuthor : Page
    {
        public AddAuthor(string authorId)
        {
            InitializeComponent();
            this.DataContext = new UpdateAuthorViewModel(authorId);

        }


    }
}
