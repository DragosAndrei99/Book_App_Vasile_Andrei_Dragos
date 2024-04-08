
namespace Book_App_Vasile_Andrei_Dragos.Models.BookType
{
    public class BookTypeDTO
    {
        public BookTypeDTO(int bookTypeId, string name)
        {
            this.BookTypeId = bookTypeId;
            this.Name = name;
        }
        public int BookTypeId { get;}
        public string Name { get; set; }
    }
}
