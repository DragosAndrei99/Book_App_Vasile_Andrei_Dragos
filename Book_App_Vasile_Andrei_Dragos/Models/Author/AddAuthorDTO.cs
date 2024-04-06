using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class AddAuthorDTO
    {
        public AddAuthorDTO(string firstName, string lastName, Nullable<DateTime> birthDate)
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
