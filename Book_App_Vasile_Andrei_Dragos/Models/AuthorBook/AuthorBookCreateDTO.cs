
namespace Book_App_Vasile_Andrei_Dragos.Models.AuthorBook
{
    public class AuthorBookCreateDTO
    {
        public AuthorBookCreateDTO(int authorId, int bookId, int numberInList)
        {
            this.AuthorId = authorId;
            this.BookId = bookId;
            this.NumberInList = numberInList;
        }

        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int NumberInList { get; set; }
    }
}
