using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class AuthorCreateDTO
    {
        public AuthorCreateDTO(string firstName, string lastName, Nullable<DateTime> birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }

    }
}
