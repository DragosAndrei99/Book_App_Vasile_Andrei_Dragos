
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Models.Publisher;
using Book_App_Vasile_Andrei_Dragos.Models.BookType;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.AuthorBook;
using Book_App_Vasile_Andrei_Dragos.Models.Author;

namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class BookViewModel: ObservableObject
    {
        private BookDAO _bookDAO;
        private BookTypeDAO _bookTypeDAO;
        private PublisherDAO _publisherDAO;
        private AuthorDAO _authorDAO;
        private AuthorBookDAO _authorBookDAO;
        private BookDTO _bindedBook;
        private int _bookId;
        private string _bookTypeName;
        private string _publisherName;
        private string _title;
        private int _publishYear;
        private int _stock;

        private ObservableCollection<AuthorDTO> _allAuthorsList = new ObservableCollection<AuthorDTO> ();
        private ObservableCollection<AuthorBookDTO> _authorBookList = new ObservableCollection<AuthorBookDTO> ();
        private List<AuthorBookUpdateDTO> _checkedAuthorBookList = new List<AuthorBookUpdateDTO>();

        private ObservableCollection<string> _publisherList = new ObservableCollection<string>();
        private ObservableCollection<string> _bookTypeList = new ObservableCollection<string>();
        private ObservableCollection<AuthorComboBox> _authorComboBoxList = new ObservableCollection<AuthorComboBox>();
        private ObservableCollection<string> _authorBookFullNameList = new ObservableCollection<string>();


        public RelayCommandWithoutParams ModifyBookCommand { get; private set; }

        public RelayCommandWithoutParams DeleteBookCommand { get; private set; }
        public RelayCommand<int> CheckUncheckAuthorCommand { get; private set; }

        public BookViewModel(string bookId)
        {
            _bookDAO = new BookDAO();
            _bookTypeDAO = new BookTypeDAO();
            _publisherDAO = new PublisherDAO();
            _authorDAO = new AuthorDAO();
            _authorBookDAO = new AuthorBookDAO();
            if (bookId != null)
            {
                _bookId = Int32.Parse(bookId);
                this.GetBookDetails();
            }
            this.LoadBookTypes();
            this.LoadPublishers();
            this.GetAllAuthors();
            ModifyBookCommand = new RelayCommandWithoutParams(ModifyBook);
            DeleteBookCommand = new RelayCommandWithoutParams(DeleteBook);
            CheckUncheckAuthorCommand = new RelayCommand<int>(CheckUncheckAuthorBox);
        }

        public BookDTO Book
        {
            get
            { return _bindedBook; }
            set
            {
                _bindedBook = value;
                OnPropertyChanged("Book");
            }
        }
        public string BookTitle
        {
            get
            { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("BookTitle");
            }
        }

        public string BookTypeName
        {
            get
            { return _bookTypeName; }
            set
            {
                _bookTypeName = value;
                OnPropertyChanged("BookTypeName");
            }
        }

        public string PublisherName
        {
            get
            { return _publisherName; }
            set
            {
                _publisherName = value;
                OnPropertyChanged("PublisherName");
            }
        }

        public int PublishYear
        {
            get
            { return _publishYear; }
            set
            {
                _publishYear = value;
                OnPropertyChanged("PublishYear");
            }
        }

        public int Stock
        {
            get
            { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged("Stock");
            }
        }

        public ObservableCollection<string> PublisherNameList
        {
            get { return _publisherList; }
            set
            {
                _publisherList = value;
                OnPropertyChanged("PublisherNameList");

            }
        }

        public ObservableCollection<string> BookTypeNameList
        {
            get { return _bookTypeList; }
            set
            {
                _bookTypeList = value;
                OnPropertyChanged("BookTypeNameList");

            }
        }
        public ObservableCollection<AuthorComboBox> AuthorList
        {
            get { return _authorComboBoxList; }
            set
            {
                _authorComboBoxList = value;
                OnPropertyChanged("AuthorList");

            }
        }

        public ObservableCollection<string> CheckedAuthorsList
        {
            get { return _authorBookFullNameList; }
            set
            {
                _authorBookFullNameList = value;
                OnPropertyChanged("CheckedAuthorsList");

            }
        }

        private void GetBookDetails()
        {
            BookDTO book = _bookDAO.GetBookById(_bookId);
            BookTitle = book.Title;
            BookTypeName = book.BookTypeName;
            PublisherName = book.PublisherName;
            PublishYear = book.PublishYear;
            Stock = book.Stock;
            this.GetAuthorsForBook();
        }

        private void GetAllAuthors()
        {
            _allAuthorsList = _authorDAO.GetAllAuthors();
            foreach (AuthorDTO author in _allAuthorsList)
            {
                bool isChecked = false;
                if (_authorBookList.Any(item => item.AuthorId == author.AuthorId))
                {
                    isChecked = true;
                }
                AuthorComboBox authorEntry = new AuthorComboBox(author.AuthorId, $"{author.FirstName} {author.LastName}", isChecked);
                this.AuthorList.Add(authorEntry);
            }
        }

        private void GetAuthorsForBook()
        {
            _authorBookList = _authorBookDAO.GetAllAuthorsForBook(_bookId);
          
            foreach (AuthorBookDTO authorBook in _authorBookList)
            {
                _checkedAuthorBookList.Add(new AuthorBookUpdateDTO(authorBook.AuthorId, authorBook.NumberInList ));
                this.CheckedAuthorsList.Add($"{authorBook.AuthorFirstName} {authorBook.AuthorLastName}");
            }
        }

        private void CheckUncheckAuthorBox(int authorId)
        {
            AuthorDTO checkedAuthor = _allAuthorsList.First(item => item.AuthorId == authorId);
            int checkedAuthorId = checkedAuthor.AuthorId;
            string authorFullName = $"{checkedAuthor.FirstName} {checkedAuthor.LastName}";
            if(!_checkedAuthorBookList.Any(item => item.AuthorId == checkedAuthorId))
            {
                _checkedAuthorBookList.Add(new AuthorBookUpdateDTO(checkedAuthorId, _checkedAuthorBookList.Count > 0 ? _checkedAuthorBookList.LastOrDefault().NumberInList + 1 : 1));
                this.CheckedAuthorsList.Add(authorFullName);
            }
            else
            {
                _checkedAuthorBookList.RemoveAll(item => item.AuthorId == checkedAuthorId);
                this.CheckedAuthorsList.Remove(authorFullName);
            }
        

        }

        private void LoadPublishers()
        {
            ObservableCollection<PublisherDTO> listOfPublishers = _publisherDAO.GetAllPublishers();
            foreach (PublisherDTO entry in listOfPublishers)
            {
                this.PublisherNameList.Add(entry.Name);
            }

        }

        private void LoadBookTypes()
        {
            ObservableCollection<BookTypeDTO> listOfBookTypes = _bookTypeDAO.GetAllBookTypes();
            foreach (BookTypeDTO entry in listOfBookTypes)
            {
                this.BookTypeNameList.Add(entry.Name);
            }
        }

        private void CreateBook()
        {

            BookCreateDTO bookToAdd = new BookCreateDTO( _bookTypeName, _publisherName, _publishYear, _title, _stock);
            int bookId = _bookDAO.CreateBook(bookToAdd);
            this.CleanupAuthorBook(bookId);

            _checkedAuthorBookList = _checkedAuthorBookList.OrderBy(item => item.NumberInList).ToList();

            foreach (AuthorBookUpdateDTO authorBook in _checkedAuthorBookList)
            {
                AuthorBookCreateDTO authorBookCreate = new AuthorBookCreateDTO(authorBook.AuthorId, bookId, authorBook.NumberInList);
                _authorBookDAO.CreateAuthorBook(authorBookCreate);
            }
        }

        private void UpdateBook()
        {

            BookDTO bookToUpdate = new BookDTO(_bookId, _bookTypeName, _publisherName, _publishYear,_title, _stock);
            _bookDAO.UpdateBook(bookToUpdate);

            this.CleanupAuthorBook(_bookId);

            foreach (AuthorBookUpdateDTO authorBook in _checkedAuthorBookList)
            {
                AuthorBookCreateDTO authorBookCreate = new AuthorBookCreateDTO(authorBook.AuthorId, _bookId, authorBook.NumberInList);
                _authorBookDAO.CreateAuthorBook(authorBookCreate);
            }
        }
        private void CleanupAuthorBook(int bookId)
        {
            
            _authorBookDAO.DeleteAuthorBookByBookId(bookId);
           
        }

        private void ModifyBook()
        {

            if (_bookId > 0)
            {
                this.UpdateBook();
            }
            else
            {
                this.CreateBook();
            }
        }

        private void DeleteBook()
        {
            _bookDAO.DeleteBook(_bookId);
            _authorBookDAO.DeleteAuthorBookByBookId(_bookId);
        }

    }
}
