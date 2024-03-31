using Book_App_Vasile_Andrei_Dragos.Models;
using Book_App_Vasile_Andrei_Dragos.Utils;
using System.Collections.ObjectModel;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels
{
    public class AuthorViewModel: ObservableObject
    {
        private ObservableCollection<Author> _authorList = null;

        public ObservableCollection<Author> AuthorList
        {
            get { return _authorList; }
            set
            {
                _authorList = value;
                OnPropertyChanged("AuthorList");

            }
        }
        public AuthorViewModel() {
            this.AuthorList = new ObservableCollection<Author>();
            this.LoadAuthors();
        }
        

        private void LoadAuthors()
        {
            this.AuthorList = DbUtils.QueryAuthors("spAuthorsSelectAll");
        }

    }
}
