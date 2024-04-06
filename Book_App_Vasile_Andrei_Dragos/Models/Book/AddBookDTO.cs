
namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class AddBookDTO
    {
        public AddBookDTO(string title, int publishYear, int stock)
        {
            Title = title;
            PublishYear = publishYear;
            Stock = stock;
        }

        public string Title { get; set; }

        public int PublishYear { get; set; }

        public int Stock{ get; set; }

    }
}
