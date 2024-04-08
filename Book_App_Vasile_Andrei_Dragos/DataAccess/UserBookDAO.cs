using Book_App_Vasile_Andrei_Dragos.Models.Author;
using Book_App_Vasile_Andrei_Dragos.Models.UserBook;
using Book_App_Vasile_Andrei_Dragos.Views.Author;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class UserBookDAO
    {
        private const string QueryAllActiveUserBooksProcedureText = "spUserBookSelectAll";
        public UserBookDAO() { }

        public ObservableCollection<UserBookDTO> GetAllUserBooks()
        {
            ObservableCollection<UserBookDTO> userBookList = new ObservableCollection<UserBookDTO>();
            List<Dictionary<string, string>> listOfUserBooks = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActiveUserBooksProcedureText);
            foreach (Dictionary<string, string> entry in listOfUserBooks)
            {
                int id = Int32.Parse(entry["Id"]);
                string userFullName = $"{entry["UserFirstName"]} {entry["UserLastName"]}";
                string bookTitle = entry["BookTitle"];
                DateTime startDate = DateTime.Parse(entry["StartDate"]);
                if (entry.TryGetValue("ReturnDate", out string returnDateEntry))
                {
                    DateTime.TryParse(returnDateEntry, out DateTime returnDate);
                    userBookList.Add(new UserBookDTO(id, userFullName, bookTitle, startDate, returnDate));
                }
                else
                {
                    userBookList.Add(new UserBookDTO(id, userFullName, bookTitle, startDate, null));
                }
            }

            return userBookList;
        }

    }
}
