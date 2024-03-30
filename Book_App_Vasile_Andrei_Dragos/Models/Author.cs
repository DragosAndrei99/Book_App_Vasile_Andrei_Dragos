using System;

namespace Book_App_Vasile_Andrei_Dragos.Models
{
    public class Author
    {
        public Author(int authorId, string firstName, string lastName, DateTime birthDate, bool active) {
            this.AuthorId = authorId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Active = active;
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; }


    }
}
