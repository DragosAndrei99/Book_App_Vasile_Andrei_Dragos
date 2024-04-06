using Book_App_Vasile_Andrei_Dragos.Models.Author;
using Book_App_Vasile_Andrei_Dragos.Utils.Database;
using Book_App_Vasile_Andrei_Dragos.Utils;

using System;
using System.Collections.Generic;

namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Author
{
    public class AuthorViewModel: ObservableObject
    {
        private string _authorToUpdateId;
        private string _authorToUpdateFirstName;
        private string _authorToUpdateLastName;
        private Nullable<DateTime> _authorToUpdateBirthDate;

        public RelayCommandWithoutParams UpdateAuthorDetailsCommand { get; private set; }

        public RelayCommandWithoutParams DeleteAuthorCommand { get; private set; }
        public AuthorViewModel(string authorId) 
        {
            _authorToUpdateId = authorId;
            if(_authorToUpdateId != null)
            {
                this.GetAuthorDetails();

            }
            UpdateAuthorDetailsCommand = new RelayCommandWithoutParams(UpdateAuthorDetails);
            DeleteAuthorCommand = new RelayCommandWithoutParams(DeleteAuthor);
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

        public Nullable<DateTime> AuthorBirthDate
        {
            get
            { return _authorToUpdateBirthDate; }
            set
            {
                _authorToUpdateBirthDate = value;
                OnPropertyChanged("AuthorBirthDate");
            }
        }

        private void GetAuthorDetails()
        {
            Dictionary<string, string> authorEntry = DbUtils.ExecuteQueryCommandById(DbUtils.QueryAuthorByIdProcedureText, Int32.Parse(_authorToUpdateId), "AuthorId");
            GetAuthorDTO author = new GetAuthorDTO(authorEntry);
            AuthorFirstName = author.FirstName;
            AuthorLastName = author.LastName;
            AuthorBirthDate = author.BirthDate;
        }

        private void UpdateAuthorDetails()
        {

            if(_authorToUpdateId != null)
            {
                UpdateAuthorDTO authorToUpdate = new UpdateAuthorDTO(Int32.Parse(_authorToUpdateId), _authorToUpdateFirstName, _authorToUpdateLastName, _authorToUpdateBirthDate);
                DbUtils.ExecuteCommand(DbUtils.UpdateAuthorProcedureText, authorToUpdate);
            } else
            {
                AddAuthorDTO authorToAdd = new AddAuthorDTO(_authorToUpdateFirstName, _authorToUpdateLastName, _authorToUpdateBirthDate);
                DbUtils.ExecuteCommand(DbUtils.AddAuthorProcedureText, authorToAdd);
            }
        }

        private void DeleteAuthor()
        {

            DeleteAuthorDTO authorToDelete = new DeleteAuthorDTO(Int32.Parse(_authorToUpdateId), false);
            DbUtils.ExecuteCommand(DbUtils.DeleteAuthorProcedureText, authorToDelete);
        }
    }
}
