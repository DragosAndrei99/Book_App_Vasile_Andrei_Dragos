
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class BookStockDTO
    {
        public BookStockDTO(int bookId, int stock) 
        {
            this.BookId = bookId;
            this.Stock = stock;
        }   

        public int BookId { get; set; }
        public int Stock { get; set; }


    }
}
