using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class AuthorDTO
    {
        public AuthorDTO(int authorId, string firstName, string lastName, Nullable<DateTime> birthDate)
        {
            this.AuthorId = authorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }
        public int AuthorId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }

    }
}
