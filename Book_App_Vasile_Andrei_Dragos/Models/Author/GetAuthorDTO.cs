using System;
using System.Collections.Generic;

namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class GetAuthorDTO
    {
        public GetAuthorDTO(Dictionary<string, string> listOfFields)
        {
            this.AuthorId = Int32.Parse(listOfFields["AuthorId"]);
            this.FirstName = listOfFields["FirstName"];
            this.LastName = listOfFields["LastName"];
            if (listOfFields.TryGetValue("BirthDate", out string birthDateEntry))
            {
                if (DateTime.TryParse(birthDateEntry, out DateTime birthDate))
                {
                    this.BirthDate = birthDate;
                }

            }
            this.Active = Boolean.Parse(listOfFields["Active"]);
        }
        public int AuthorId { get; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }

        public bool Active { get; set; }


    }
}
