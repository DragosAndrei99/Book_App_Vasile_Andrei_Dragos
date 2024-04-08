
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Models.Publisher;
using Book_App_Vasile_Andrei_Dragos.Models.BookType;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.DataAccess;

namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class BookViewModel: ObservableObject
    {
        private BookDAO _bookDAO;
        private BookTypeDAO _bookTypeDAO;
        private PublisherDAO _publisherDAO;
        private BookDTO _bindedBook;
        private string _bookId;
        private string _bookTypeName;
        private string _publisherName;
        private string _title;
        private int _publishYear;
        private int _stock;
        private ObservableCollection<string> _publisherList = new ObservableCollection<string>();
        private ObservableCollection<string> _bookTypeList = new ObservableCollection<string>();


        public RelayCommandWithoutParams ModifyBookCommand { get; private set; }

        public RelayCommandWithoutParams DeleteBookCommand { get; private set; }

        public BookViewModel(string bookId)
        {
            _bookDAO = new BookDAO();
            _bookTypeDAO = new BookTypeDAO();
            _publisherDAO = new PublisherDAO();
            _bookId = bookId;
            if (_bookId != null)
            {
                this.GetBookDetails();

            }
            this.LoadBookTypes();
            this.LoadPublishers();
            ModifyBookCommand = new RelayCommandWithoutParams(ModifyBook);
            DeleteBookCommand = new RelayCommandWithoutParams(DeleteBook);
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

        private void GetBookDetails()
        {
            BookDTO book = _bookDAO.GetBookById(_bookId);
            BookTitle = book.Title;
            BookTypeName = book.BookTypeName;
            PublisherName = book.PublisherName;
            PublishYear = book.PublishYear;
            Stock = book.Stock;
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
            _bookDAO.CreateBook(bookToAdd);
        }

        private void UpdateBook()
        {
            BookDTO bookToUpdate = new BookDTO(Int32.Parse(_bookId), _bookTypeName, _publisherName, _publishYear,_title, _stock);
            _bookDAO.UpdateBook(bookToUpdate);
        }

        private void ModifyBook()
        {

            if (_bookId != null)
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
        }

    }
}
