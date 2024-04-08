
namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class AuthorDeleteDTO
    {
        public AuthorDeleteDTO(int authorId, bool active)
        {
            this.AuthorId = authorId;
            this.Active = active;
        }

        public int AuthorId { get; }

        public bool Active { get; set; }
    }
}
