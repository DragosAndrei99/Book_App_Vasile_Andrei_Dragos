using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.AuthorBook;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class ListBooksViewModel : ObservableObject
    {
        private BookDAO _bookDAO;
        private AuthorBookDAO _authorBookDAO;
        private ObservableCollection<BookWithAuthors> _bookList = null;

        public ObservableCollection<BookWithAuthors> BookList
        {
            get { return _bookList; }
            set
            {
                _bookList = value;
                OnPropertyChanged("BookList");

            }
        }
        public ListBooksViewModel()
        {
            this.BookList = new ObservableCollection<BookWithAuthors>();
            _bookDAO = new BookDAO();
            _authorBookDAO = new AuthorBookDAO();
            this.LoadBooks();
        }


        private void LoadBooks()
        {
            ObservableCollection<BookDTO> bookList = _bookDAO.GetAllActiveBooks();
            foreach (BookDTO book in bookList)
            {
                List<string> authorsFullName = new List<string>();
                ObservableCollection<AuthorBookDTO> authors = _authorBookDAO.GetAllAuthorsForBook(book.BookId);
                foreach(AuthorBookDTO authorBook in authors)
                {
                    authorsFullName.Add($"{authorBook.AuthorFirstName} {authorBook.AuthorLastName}");
                }
                BookWithAuthors bookWithAuthors = new BookWithAuthors(book.BookId, book.BookTypeName, book.PublisherName, book.PublishYear, book.Title, book.Stock, string.Join(", ", authorsFullName));
                this.BookList.Add(bookWithAuthors);
            }
        }

    }
}
