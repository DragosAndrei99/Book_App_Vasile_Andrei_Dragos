using Book_App_Vasile_Andrei_Dragos.Models;
using Book_App_Vasile_Andrei_Dragos.Utils;
using System;

namespace Book_App_Vasile_Andrei_Dragos.ViewModels
{
    public class UpdateAuthorViewModel: ObservableObject
    {
        private string _authorToUpdateId;
        private string _authorToUpdateFirstName;
        private string _authorToUpdateLastName;
        private DateTime _authorToUpdateBirthDate;

        public RelayCommand<string> UpdateAuthorDetailsCommand { get; private set; }
        public UpdateAuthorViewModel(string authorId) 
        {
            AuthorId = authorId;
            if(authorId !=null)
            {
                this.GetAuthorDetails(AuthorId);

            }
            UpdateAuthorDetailsCommand = new RelayCommand<string>(UpdateAuthorDetails);
        }

        public string AuthorId
        {
            get
            { return _authorToUpdateId; }
            set
            {
                _authorToUpdateId = value;
                OnPropertyChanged("AuthorId");
            }
        }

        public string AuthorFirstName
        {
            get
            { return _authorToUpdateFirstName; }
            set
            {
                _authorToUpdateFirstName = value;
                OnPropertyChanged("AuthorFirstName");
            }
        }

        public string AuthorLastName
        {
            get
            { return _authorToUpdateLastName; }
            set
            {
                _authorToUpdateLastName = value;
                OnPropertyChanged("AuthorLastName");
            }
        }

        public DateTime AuthorBirthDate
        {
            get
            { return _authorToUpdateBirthDate; }
            set
            {
                _authorToUpdateBirthDate = value;
                OnPropertyChanged("AuthorBirthDate");
            }
        }

        private void GetAuthorDetails(string authorId)
        {
            Author author = DbUtils.ExecuteCommand("spAuthorsSelectAuthor", Int32.Parse(authorId));
            AuthorFirstName = author.FirstName;
            AuthorLastName = author.LastName;
            AuthorBirthDate = author.BirthDate;
        }

        private void UpdateAuthorDetails(string authorId)
        {

            if(authorId != null)
            {
                // update
            } else
            {
                DbUtils.AddAuthor(AuthorFirstName, AuthorLastName, AuthorBirthDate);
            }
        }

        private void DeleteAuthor(string authorId)
        {
            // set active to 0
        }
    }
}
