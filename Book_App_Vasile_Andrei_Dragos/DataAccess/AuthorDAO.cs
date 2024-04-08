
using Book_App_Vasile_Andrei_Dragos.Models.Author;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class AuthorDAO
    {
        private const string QueryAllActiveAuthorsProcedureText = "spAuthorSelectAllActive";
        private const string QueryAuthorByIdProcedureText = "spAuthorsSelectAuthor";
        private const string AddAuthorProcedureText = "spAuthorInsert";
        private const string UpdateAuthorProcedureText = "spAuthorUpdate";
        private const string DeleteAuthorProcedureText = "spAuthorDelete";

        public AuthorDAO() { }

        public ObservableCollection<AuthorDTO> GetAllAuthors()
        {
            ObservableCollection<AuthorDTO> authorList = new ObservableCollection<AuthorDTO>();
            List<Dictionary<string, string>> listOfAuthors = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActiveAuthorsProcedureText);
            foreach (Dictionary<string, string> entry in listOfAuthors)
            {
                int authorId = Int32.Parse(entry["AuthorId"]);
                string firstName = entry["FirstName"];
                string lastName = entry["LastName"];
                if (entry.TryGetValue("BirthDate", out string birthDateEntry))
                {
                    DateTime.TryParse(birthDateEntry, out DateTime birthDate);
                    authorList.Add(new AuthorDTO(authorId, firstName, lastName, birthDate));
                } else
                {
                    authorList.Add(new AuthorDTO(authorId, firstName, lastName, null));
                }

            }

            return authorList;
        }
        public AuthorDTO GetAuthorById(int authorId)
        {
            Dictionary<string, string> authorEntry = DatabaseAccess.ExecuteCommandById(QueryAuthorByIdProcedureText, authorId, "AuthorId").FirstOrDefault();

            string firstName = authorEntry["FirstName"];
            string lastName = authorEntry["LastName"];
            AuthorDTO author;
            if (authorEntry.TryGetValue("BirthDate", out string birthDateEntry))
            {
                DateTime.TryParse(birthDateEntry, out DateTime birthDate);
                author = new AuthorDTO(authorId, firstName, lastName, birthDate);
            }
            else
            {
                author = new AuthorDTO(authorId, firstName, lastName, null);
            }

            return author;
        }

        public void CreateAuthor(AuthorCreateDTO authorToAdd)
        {
            DatabaseAccess.ExecuteCommand(AddAuthorProcedureText, authorToAdd);

        }

        public void UpdateAuthor(AuthorDTO authorToUpdate)
        {
            DatabaseAccess.ExecuteCommand(UpdateAuthorProcedureText, authorToUpdate);

        }

        public void DeleteAuthor(int authorId)
        {
            AuthorDeleteDTO authorToDelete = new AuthorDeleteDTO(authorId, false);
            DatabaseAccess.ExecuteCommand(DeleteAuthorProcedureText, authorToDelete);
        }
    }
}
