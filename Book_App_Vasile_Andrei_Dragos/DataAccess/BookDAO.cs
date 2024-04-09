using Book_App_Vasile_Andrei_Dragos.Models.Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class BookDAO
    {
        private const string QueryAllActiveBooksProcedureText = "spBookSelectAllActive";
        private const string QueryAllActiveAndInStockBooksProcedureText = "spBookSelectAllActiveAndInStock";        
        private const string QueryBookByIdProcedureText = "spBookSelect";
        private const string AddBookProcedureText = "spBookInsert";
        private const string UpdateBookProcedureText = "spBookUpdate";
        private const string DeleteBookProcedureText = "spBookDelete";
        private const string IncreaseStockProcedureText = "spBookIncreaseStock";
        private const string DecreaseStockProcedureText = "spBookDecreaseStock";

        public BookDAO() { }

        public ObservableCollection<BookDTO> GetAllActiveInStockBooks()
        {
            return this.GetAllBooks(QueryAllActiveAndInStockBooksProcedureText);
        }

        public ObservableCollection<BookDTO> GetAllActiveBooks()
        {
            return this.GetAllBooks(QueryAllActiveBooksProcedureText);
        }

        public ObservableCollection<BookDTO> GetAllBooks(string procedureText)
        {
            ObservableCollection<BookDTO> bookList = new ObservableCollection<BookDTO>();
            List<Dictionary<string, string>> listOfBooks = DatabaseAccess.ExecuteQueryAllCommand(procedureText);
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
        public BookDTO GetBookById(int bookId) 
        {
            Dictionary<string, string> bookEntry = DatabaseAccess.ExecuteCommandById(QueryBookByIdProcedureText, bookId, "BookId").FirstOrDefault();
            string bookTypeName = bookEntry["BookTypeName"];
            string publisherName = bookEntry["PublisherName"];
            int publishYear = Int32.Parse(bookEntry["PublishYear"]);
            string title = bookEntry["Title"];
            int stock = Int32.Parse(bookEntry["Stock"]);

            BookDTO book = new BookDTO(bookId, bookTypeName, publisherName, publishYear, title, stock);

            return book;
        }

        public int CreateBook(BookCreateDTO bookToAdd)
        {
            return DatabaseAccess.ExecuteCommand(AddBookProcedureText, bookToAdd);

        }

        public void UpdateBook(BookDTO bookToUpdate)
        {
            DatabaseAccess.ExecuteCommand(UpdateBookProcedureText, bookToUpdate);

        }

        public void IncreaseBookStock(int bookId)
        {
            DatabaseAccess.ExecuteCommandById(IncreaseStockProcedureText, bookId, "BookId");
        }

        public void DecreaseBookStock(int bookId)
        {
            DatabaseAccess.ExecuteCommandById(DecreaseStockProcedureText, bookId, "BookId");
        }


        public void DeleteBook(int bookId) 
        {
            BookDeleteDTO bookToDelete = new BookDeleteDTO(bookId, false);
            DatabaseAccess.ExecuteCommand(DeleteBookProcedureText, bookToDelete);
        }
    }
}
