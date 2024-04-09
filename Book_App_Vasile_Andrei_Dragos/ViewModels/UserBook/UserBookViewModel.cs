using System;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Models.User;
using Book_App_Vasile_Andrei_Dragos.Models.UserBook;
using Book_App_Vasile_Andrei_Dragos.Utils;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.UserBook
{
    public class UserBookViewModel : ObservableObject
    {
        private int _userBookId;
        private UserBookDAO _userBookDAO;
        private BookDAO _bookDAO;
        private UserDAO _userDAO;
        private string _bookTitle;
        private string _userFullName;
        private DateTime _startDate;
        private Nullable<DateTime> _returnDate;
        private int _userId;
        private int _bookId;

        private ObservableCollection<string> _bookTitleList = new ObservableCollection<string>();
        private ObservableCollection<string> _userFullNameList = new ObservableCollection<string>();

        public RelayCommandWithoutParams ModifyUserBookCommand { get; private set; }
        public UserBookViewModel(string userBookId)
        {
            _userBookDAO = new UserBookDAO();
            _bookDAO = new BookDAO();
            _userDAO = new UserDAO();
            if (userBookId != null)
            {
                _userBookId = Int32.Parse(userBookId);
                this.GetUserBookDetails();
            }else
            {
                this.LoadAllBooks();
            }
            this.LoadAllUsers();
            ModifyUserBookCommand = new RelayCommandWithoutParams(ModifyUserBook);
        }

        public string Title
        {
            get { return _bookTitle; }
            set
            {
                _bookTitle = value;
                OnPropertyChanged("Title");
            }
        }

        public string UserFullName
        {
            get { return _userFullName; }
            set
            {
                _userFullName = value;
                OnPropertyChanged("UserFullName");
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public Nullable<DateTime> ReturnDate
        {
            get { return _returnDate; }
            set
            {
                _returnDate = value;
                OnPropertyChanged("ReturnDate");
            }
        }


        public ObservableCollection<string> BookTitleList
        {
            get { return _bookTitleList; }
            set
            {
                _bookTitleList = value;
                OnPropertyChanged("BookTitleList");
            }
        }


        public ObservableCollection<string> UserFullNameList
        {
            get { return _userFullNameList; }
            set
            {
                _userFullNameList = value;
                OnPropertyChanged("UserFullNameList");
            }
        }

        private void GetUserBookDetails()
        {
            UserBookDTO userBook = _userBookDAO.GetUserBookById(_userBookId);
            this.Title = userBook.Title;
            this.UserFullName = $"{userBook.FirstName} {userBook.LastName}";
            this.StartDate = userBook.StartDate;
            this.ReturnDate = userBook.ReturnDate;
            _userId = userBook.UserId;
            _bookId = userBook.BookId;
        }

        private void LoadAllBooks()
        {
            ObservableCollection<BookDTO> allBooks = _bookDAO.GetAllActiveInStockBooks();
            foreach (BookDTO book in allBooks)
            {
                this.BookTitleList.Add(book.Title);
            }
        }
        private void LoadAllUsers()
        {
            ObservableCollection<UserDTO> allUsers = _userDAO.GetAllUsers();
            foreach (UserDTO user in allUsers) 
            {
                this.UserFullNameList.Add($"{user.FirstName} {user.LastName}");
            }
        }

        private void ModifyUserBook()
        {
            if (_userBookId > 0)
            {
                this.UpdateUserBook();
            }
            else
            {
                this.CreateUserBook();
            }
        }

        private void CreateUserBook()
        {
            string[] names = _userFullName.Split(' ');
            UserBookCreateDTO userBookToAdd = new UserBookCreateDTO(names[0], names[1], _bookTitle, _startDate, _returnDate);
            int bookId = _userBookDAO.CreateUserBook(userBookToAdd);
            if(_startDate < DateTime.Now && (_returnDate == null ||_returnDate < DateTime.Now))
            {
                _bookDAO.DecreaseBookStock(bookId);
            }
        }

        private void UpdateUserBook() 
        {
            string[] names = _userFullName.Split(' ');
            
            UserBookUpdateDTO userBookToUpdate = new UserBookUpdateDTO(_userBookId, _bookId, names[0], names[1], _startDate, _returnDate);
            int bookId = _userBookDAO.UpdateUserBook(userBookToUpdate);
            if(_returnDate != null && _returnDate <= DateTime.Now)
            {
                _bookDAO.IncreaseBookStock(bookId);
            } else
            {
                _bookDAO.DecreaseBookStock(bookId);
            }
        }
    }
}
