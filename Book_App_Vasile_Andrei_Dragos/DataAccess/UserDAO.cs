using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Models.User;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class UserDAO
    {
        private const string QueryAllUsersProcedureText = "spUserSelectAllActive";
        public UserDAO() { }

        public ObservableCollection<UserDTO> GetAllUsers()
        {
            ObservableCollection<UserDTO> userList = new ObservableCollection<UserDTO>();
            List<Dictionary<string, string>> listOfUsers = DatabaseAccess.ExecuteQueryAllCommand(QueryAllUsersProcedureText);
            foreach (Dictionary<string, string> entry in listOfUsers)
            {
                int userId = Int32.Parse(entry["UserId"]);
                string firstName = entry["FirstName"];
                string lastName = entry["LastName"];
                string email = entry["Email"];
                string phone = entry["Phone"];

                UserDTO user = new UserDTO(userId, firstName, lastName, email, phone);
                userList.Add(user);
            }

            return userList;
        }
    }
}
