using System.Collections.Generic;
using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.BookType
{
    public class GetBookTypeDTO
    {
        public GetBookTypeDTO(Dictionary<string, string> listOfFields)
        {
            this.BookTypeId = Int32.Parse(listOfFields["BookTypeId"]);
            this.Name = listOfFields["Name"];
            this.Active = Boolean.Parse(listOfFields["Active"]);
        }
        public int BookTypeId { get;}
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
