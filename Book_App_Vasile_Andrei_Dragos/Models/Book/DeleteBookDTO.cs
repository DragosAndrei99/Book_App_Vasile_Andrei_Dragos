
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class DeleteBookDTO
    {
        public DeleteBookDTO(int bookId, bool active)
        {
            BookId = bookId;
            Active = active;
        }

        public int BookId { get; }

        public bool Active { get; set; }
    }
}
