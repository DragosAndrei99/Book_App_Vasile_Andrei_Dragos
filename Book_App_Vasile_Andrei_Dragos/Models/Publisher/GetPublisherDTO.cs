
using System.Collections.Generic;
using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.Publisher
{
    public class GetPublisherDTO
    {
        public GetPublisherDTO(Dictionary<string, string> listOfFields)
        {
            this.PublisherId = Int32.Parse(listOfFields["PublisherId"]);
            this.Name = listOfFields["Name"];
            this.Adress = listOfFields["Adress"];
            this.Active = Boolean.Parse(listOfFields["Active"]);
        }
        public int PublisherId { get; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public bool Active { get; set; }
    }
}
