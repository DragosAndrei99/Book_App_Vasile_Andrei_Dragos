
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using Book_App_Vasile_Andrei_Dragos.Models.AuthorBook;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class AuthorBookDAO
    {
        private const string QueryAllAuthorsForBookProcedureText = "spAuthorBookSelectAuthorForBook";
        private const string AddAuthorBookProcedureText = "spAuthorBookInsert";
        private const string DeleteAuthorBookProcedureText = "spAuthorBookDelete";


        public AuthorBookDAO() { }

        public ObservableCollection<AuthorBookDTO> GetAllAuthorsForBook(int bookId)
        {
            ObservableCollection<AuthorBookDTO> authorBookList = new ObservableCollection<AuthorBookDTO>();
            List<Dictionary<string, string>> listOfAuthorsForBook = DatabaseAccess.ExecuteCommandById(QueryAllAuthorsForBookProcedureText, bookId, "BookId");
            foreach (Dictionary<string, string> entry in listOfAuthorsForBook)
            {
                string authorId = entry["AuthorId"];
                string authorFirstName = entry["FirstName"];
                string authorLastName = entry["LastName"];
                string numberInList = entry["NumberInList"];
                AuthorBookDTO authorBook = new AuthorBookDTO(Int32.Parse(authorId), authorFirstName, authorLastName, Int32.Parse(numberInList));
                authorBookList.Add(authorBook);
            }

            return authorBookList;
        }

        public void CreateAuthorBook(AuthorBookCreateDTO authorBookToAdd)
        {
            DatabaseAccess.ExecuteCommand(AddAuthorBookProcedureText, authorBookToAdd);
        }

        public void DeleteAuthorBookByBookId(int bookId)
        {
            DatabaseAccess.ExecuteCommandById(DeleteAuthorBookProcedureText, bookId, "BookId");
        }

    }
}
