using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class UpdateAuthorDTO
    {
        public UpdateAuthorDTO(int authorId, string firstName, string lastName, Nullable<DateTime> birthDate)
        {
            AuthorId = authorId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public int AuthorId { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }
    }
}
