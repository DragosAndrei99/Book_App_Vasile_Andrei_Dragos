
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class BookCreateDTO
    {
        public BookCreateDTO(string bookTypeName, string publisherName, int publishYear, string title, int stock)
        {
            this.Title = title;
            this.BookTypeName = bookTypeName;
            this.PublisherName = publisherName;
            this.PublishYear = publishYear;
            this.Stock = stock;
        }

        public string Title { get; set; }
        public string BookTypeName { get; set; }
        public string PublisherName { get; set; }

        public int PublishYear { get; set; }

        public int Stock{ get; set; }

    }
}
