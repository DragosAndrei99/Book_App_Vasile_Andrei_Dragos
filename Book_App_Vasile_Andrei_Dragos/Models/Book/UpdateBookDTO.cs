
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class UpdateBookDTO
    {
        public UpdateBookDTO(int bookId, string title, int publishYear, int stock)
        {
            BookId = bookId;
            Title = title;
            PublishYear = publishYear;
            Stock = stock;
        }

        public int BookId { get; }

        public string Title { get; set; }

        public int PublishYear { get; set; }

        public int Stock{ get; set; }
    }
}
