
namespace Book_App_Vasile_Andrei_Dragos.Models.AuthorBook
{
    public class AuthorBookDTO
    {
        public AuthorBookDTO(int authorId, string authorFirstName, string authorLastName, int numberInList )
        {
            this.AuthorId = authorId;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
            this.NumberInList = numberInList;
        }
        public int AuthorId { get; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int NumberInList { get; set; }
    }
}
