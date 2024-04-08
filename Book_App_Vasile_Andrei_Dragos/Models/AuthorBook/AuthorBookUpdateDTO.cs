
namespace Book_App_Vasile_Andrei_Dragos.Models.AuthorBook
{
    public class AuthorBookUpdateDTO
    {
        public AuthorBookUpdateDTO(int authorId, int numberInList)
        {
            this.AuthorId = authorId;
            this.NumberInList = numberInList;
        }

        public int AuthorId { get; set; }
        public int NumberInList { get; set; }
    }
}
