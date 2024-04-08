using Book_App_Vasile_Andrei_Dragos.Models.Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class BookDAO
    {
        private const string QueryAllActiveBooksProcedureText = "spBookSelectAllActive";
        private const string QueryBookByIdProcedureText = "spBookSelect";
        private const string AddBookProcedureText = "spBookInsert";
        private const string UpdateBookProcedureText = "spBookUpdate";
        private const string DeleteBookProcedureText = "spBookDelete";

        public BookDAO() { }

        public ObservableCollection<BookDTO> GetAllBooks()
        {
            ObservableCollection<BookDTO> bookList = new ObservableCollection<BookDTO>();
            List<Dictionary<string, string>> listOfBooks = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActiveBooksProcedureText);
            foreach (Dictionary<string, string> entry in listOfBooks)
            {
                int bookId = Int32.Parse(entry["BookId"]);
                string bookTypeName = entry["BookTypeName"];
                string publisherName = entry["PublisherName"];
                int publishYear = Int32.Parse(entry["PublishYear"]);
                string title = entry["Title"];
                int stock = Int32.Parse(entry["Stock"]);
                bookList.Add(new BookDTO(bookId, bookTypeName, publisherName, publishYear, title, stock));
            }

            return bookList;
        }
        public BookDTO GetBookById(string bookId) 
        {
            Dictionary<string, string> bookEntry = DatabaseAccess.ExecuteQueryCommandById(QueryBookByIdProcedureText, Int32.Parse(bookId), "BookId");
            string bookTypeName = bookEntry["BookTypeName"];
            string publisherName = bookEntry["PublisherName"];
            int publishYear = Int32.Parse(bookEntry["PublishYear"]);
            string title = bookEntry["Title"];
            int stock = Int32.Parse(bookEntry["Stock"]);

            BookDTO book = new BookDTO(Int32.Parse(bookId), bookTypeName, publisherName, publishYear, title, stock);

            return book;
        }

        public void CreateBook(BookCreateDTO bookToAdd)
        {
            DatabaseAccess.ExecuteCommand(AddBookProcedureText, bookToAdd);

        }

        public void UpdateBook(BookDTO bookToUpdate)
        {
            DatabaseAccess.ExecuteCommand(UpdateBookProcedureText, bookToUpdate);

        }

        public void DeleteBook(string bookId) 
        {
            BookDeleteDTO bookToDelete = new BookDeleteDTO(Int32.Parse(bookId), false);
            DatabaseAccess.ExecuteCommand(DeleteBookProcedureText, bookToDelete);
        }
    }
}
