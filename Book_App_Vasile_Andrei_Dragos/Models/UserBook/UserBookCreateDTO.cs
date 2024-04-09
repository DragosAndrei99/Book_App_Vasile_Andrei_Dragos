using System;


namespace Book_App_Vasile_Andrei_Dragos.Models.UserBook
{
    public class UserBookCreateDTO
    {
        public UserBookCreateDTO(string firstName, string lastName,  string title, DateTime startDate, Nullable<DateTime> returnDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Title = title;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}

