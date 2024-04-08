
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class BookDeleteDTO
    {
        public BookDeleteDTO(int bookId, bool active)
        {
            this.BookId = bookId;
            this.Active = active;
        }

        public int BookId { get; }

        public bool Active { get; set; }
    }
}
