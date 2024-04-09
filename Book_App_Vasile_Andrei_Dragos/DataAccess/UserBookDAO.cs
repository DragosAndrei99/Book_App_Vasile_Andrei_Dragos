using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Book_App_Vasile_Andrei_Dragos.Models.UserBook;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class UserBookDAO
    {
        private const string QueryAllActiveUserBooksProcedureText = "spUserBookSelectAll";
        private const string AddUserBookProcedureText = "spUserBookInsert";
        private const string UpdateUserBookProcedureText = "spUserBookUpdate";
        private const string QueryUserBookByIdProcedureText = "spUserBookSelect";
        public UserBookDAO() { }

        public ObservableCollection<UserBookDTO> GetAllUserBooks()
        {
            ObservableCollection<UserBookDTO> userBookList = new ObservableCollection<UserBookDTO>();
            List<Dictionary<string, string>> listOfUserBooks = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActiveUserBooksProcedureText);
            foreach (Dictionary<string, string> entry in listOfUserBooks)
            {
                int id = Int32.Parse(entry["Id"]);
                string firstName = entry["UserFirstName"];
                string lastName = entry["UserLastName"];
                string bookTitle = entry["BookTitle"];
                DateTime startDate = DateTime.Parse(entry["StartDate"]);
                if (entry.TryGetValue("ReturnDate", out string returnDateEntry))
                {
                    DateTime.TryParse(returnDateEntry, out DateTime returnDate);
                    userBookList.Add(new UserBookDTO(id, firstName,lastName, bookTitle, startDate, returnDate));
                }
                else
                {
                    userBookList.Add(new UserBookDTO(id, firstName,lastName, bookTitle, startDate, null));
                }
            }

            return userBookList;
        }

        public UserBookDTO GetUserBookById(int userBookId)
        {
            Dictionary<string, string> userBookEntry = DatabaseAccess.ExecuteCommandById(QueryUserBookByIdProcedureText, userBookId, "Id").FirstOrDefault();
            int id = Int32.Parse(userBookEntry["Id"]);
            string firstName = userBookEntry["UserFirstName"];
            string lastName = userBookEntry["UserLastName"];
            string bookTitle = userBookEntry["BookTitle"];
            DateTime startDate = DateTime.Parse(userBookEntry["StartDate"]);
            if (userBookEntry.TryGetValue("ReturnDate", out string returnDateEntry))
            {
                DateTime.TryParse(returnDateEntry, out DateTime returnDate);
                return new UserBookDTO(id, firstName, lastName, bookTitle, startDate, returnDate);
            }
            else
            {
                return new UserBookDTO(id, firstName, lastName, bookTitle, startDate, null);
            }
        }

        public int CreateUserBook(UserBookCreateDTO userBook)
        {
            return DatabaseAccess.ExecuteCommand(AddUserBookProcedureText, userBook);
        }

        public int UpdateUserBook(UserBookDTO userBookToUpdate)
        {
            return DatabaseAccess.ExecuteCommand(UpdateUserBookProcedureText, userBookToUpdate);

        }
    }
}
