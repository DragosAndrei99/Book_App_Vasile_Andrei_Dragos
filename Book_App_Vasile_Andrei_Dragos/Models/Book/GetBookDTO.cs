using System;
using System.Collections.Generic;

namespace Book_App_Vasile_Andrei_Dragos.Models.Book
{
    public class GetBookDTO
    {
        public GetBookDTO(Dictionary<string, string> listOfFields)
        {
            this.BookId = Int32.Parse(listOfFields["BookId"]);
            this.BookTypeName = listOfFields["BookTypeName"];
            this.PublisherName = listOfFields["PublisherName"];
            this.PublishYear = Int32.Parse(listOfFields["PublishYear"]);
            this.Title = listOfFields["Title"];
            this.Stock = Int32.Parse(listOfFields["Stock"]);
        }

        public int BookId { get; }
        public string BookTypeName { get; set; }
        public string PublisherName { get; set; }
        public int BookTypeId { get; } 
        public int PublisherId { get; }
        public string Title { get; set; }
        public int PublishYear { get; set; }

        public int Stock { get; set; }

    }
}
