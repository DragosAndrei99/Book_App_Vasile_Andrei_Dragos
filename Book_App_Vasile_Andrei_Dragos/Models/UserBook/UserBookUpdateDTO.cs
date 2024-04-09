using System;


namespace Book_App_Vasile_Andrei_Dragos.Models.UserBook
{
    public class UserBookUpdateDTO
    {
        public UserBookUpdateDTO(int id, int bookId, string firstName, string lastName, DateTime startDate, Nullable<DateTime> returnDate)
        {
            this.Id = id;
            this.BookId = bookId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
        }
        public int Id { get; }
        public int BookId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
