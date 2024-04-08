using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Utils;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.DataAccess;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class ListBooksViewModel : ObservableObject
    {
        private BookDAO _bookDAO;
        private ObservableCollection<BookDTO> _bookList = null;

        public ObservableCollection<BookDTO> BookList
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
            this.BookList = new ObservableCollection<BookDTO>();
            _bookDAO = new BookDAO();
            this.LoadBooks();
        }


        private void LoadBooks()
        {
            this.BookList = _bookDAO.GetAllBooks();
        }

    }
}
