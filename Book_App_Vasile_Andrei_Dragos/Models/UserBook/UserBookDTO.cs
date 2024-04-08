
using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.UserBook
{
    public class UserBookDTO
    {
        public UserBookDTO(int id, string userFullName, string bookTitle, DateTime startDate, Nullable<DateTime> returnDate)
        {
            this.Id = id;
            this.UserFullName = userFullName;
            this.BookTitle = bookTitle;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
        }
        public int Id { get; }
        public string UserFullName { get; set; }
        public string BookTitle { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
