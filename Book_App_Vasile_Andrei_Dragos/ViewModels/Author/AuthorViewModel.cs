﻿using System;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.Author;
using Book_App_Vasile_Andrei_Dragos.Utils;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Author
{
    public class AuthorViewModel: ObservableObject
    {
        private AuthorDAO _authorDAO;
        private int _authorId;
        private string _authorFirstName;
        private string _authorLastName;
        private Nullable<DateTime> _authorBirthDate;

        public RelayCommandWithoutParams UpdateAuthorDetailsCommand { get; private set; }

        public RelayCommandWithoutParams DeleteAuthorCommand { get; private set; }
        public AuthorViewModel(string authorId) 
        {
            _authorDAO = new AuthorDAO();
            if(authorId != null)
            {
                _authorId = Int32.Parse(authorId);
                this.GetAuthorDetails();

            }
            UpdateAuthorDetailsCommand = new RelayCommandWithoutParams(UpdateAuthorDetails);
            DeleteAuthorCommand = new RelayCommandWithoutParams(DeleteAuthor);
        }

        public string AuthorFirstName
        {
            get
            { return _authorFirstName; }
            set
            {
                _authorFirstName = value;
                OnPropertyChanged("AuthorFirstName");
            }
        }

        public string AuthorLastName
        {
            get
            { return _authorLastName; }
            set
            {
                _authorLastName = value;
                OnPropertyChanged("AuthorLastName");
            }
        }

        public Nullable<DateTime> AuthorBirthDate
        {
            get
            { return _authorBirthDate; }
            set
            {
                _authorBirthDate = value;
                OnPropertyChanged("AuthorBirthDate");
            }
        }

        private void GetAuthorDetails()
        {
            AuthorDTO author = _authorDAO.GetAuthorById(_authorId);
            AuthorFirstName = author.FirstName;
            AuthorLastName = author.LastName;
            AuthorBirthDate = author.BirthDate;
        }


        private void CreateAuthor()
        {
            AuthorCreateDTO authorToAdd = new AuthorCreateDTO(_authorFirstName, _authorLastName, _authorBirthDate);
            _authorDAO.CreateAuthor(authorToAdd);
        }

        private void UpdateAuthor()
        {
            AuthorDTO authorToAdd = new AuthorDTO(_authorId, _authorFirstName, _authorLastName, _authorBirthDate);
            _authorDAO.UpdateAuthor(authorToAdd);
        }
        private void UpdateAuthorDetails()
        {

            if(_authorId > 0)
            {
                this.UpdateAuthor();
            } else
            {
                this.CreateAuthor();
            }
        }

        private void DeleteAuthor()
        {
           _authorDAO.DeleteAuthor(_authorId);
        }
    }
}
