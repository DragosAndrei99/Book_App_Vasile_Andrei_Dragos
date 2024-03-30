using Book_App_Vasile_Andrei_Dragos.Models;
using Book_App_Vasile_Andrei_Dragos.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;


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
/*        public string AuthorFirstName 
        { 
            get
            { return _author.FirstName; }
            set
            {
                _author.FirstName = value;
                OnPropertyChanged("AuthorFirstName");
            }
        }*/

        public RelayCommand<int> UpdateAuthorCommand { get; private set; }
        public AuthorViewModel() {

            this.AuthorList = new ObservableCollection<Author>();
            this.LoadAuthors();
            UpdateAuthorCommand = new RelayCommand<int>(UpdateAuthor) ;
        }
        

        private void LoadAuthors()
        {
            this.AuthorList = DbUtils.QueryAuthors("spAuthorsSelectAll");
        }

        private void UpdateAuthor(int authorId)
        {
            Author authorToUpdate = this.AuthorList.Where(author => author.AuthorId == authorId).First();
            // navigate to add author frame with completed details
        }

    }
}
