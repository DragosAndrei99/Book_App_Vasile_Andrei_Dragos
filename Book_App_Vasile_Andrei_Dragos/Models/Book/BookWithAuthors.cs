
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class BookWithAuthors
    {
        public BookWithAuthors(int bookId, string bookTypeName, string publisherName, int publishYear, string title, int stock, string authors)
        {
            this.BookId = bookId;
            this.Title = title;
            this.BookTypeName = bookTypeName;
            this.PublisherName = publisherName;
            this.PublishYear = publishYear;
            this.Stock = stock;
            this.Authors = authors;
        }

        public int BookId { get; }
        public string Title { get; set; }
        public string BookTypeName { get; set; }
        public string PublisherName { get; set; }

        public int PublishYear { get; set; }

        public int Stock { get; set; }
        
        public string Authors { get; set;}
    }
}
