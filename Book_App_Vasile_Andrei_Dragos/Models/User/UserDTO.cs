

namespace Book_App_Vasile_Andrei_Dragos.Models.User
{
    public class UserDTO
    {
        public UserDTO(int userId, string firstName, string lastName, string email, string phone)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
        }
        public int UserId {get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
