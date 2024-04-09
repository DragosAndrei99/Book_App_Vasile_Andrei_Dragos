﻿
using System;

namespace Book_App_Vasile_Andrei_Dragos.Models.UserBook
{
    public class UserBookDTO
    {
        public UserBookDTO(int id, string firstName, string lastName, string bookTitle, DateTime startDate, Nullable<DateTime> returnDate)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Title = bookTitle;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
        }
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
