
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Models.Publisher;
using Book_App_Vasile_Andrei_Dragos.Models.BookType;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.Utils.Database;
using Book_App_Vasile_Andrei_Dragos.Models.Author;

namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class BookViewModel: ObservableObject
    {
        private string _bookId;
        private string _bookTypeName;
        private string _publisherName;
        private string _title;
        private int _publishYear;
        private int _stock;
        private ObservableCollection<string> _publisherList = new ObservableCollection<string>();
        private ObservableCollection<string> _bookTypeList = new ObservableCollection<string>();


        public RelayCommandWithoutParams UpdateBookDetailsCommand { get; private set; }

        public RelayCommandWithoutParams DeleteBookCommand { get; private set; }

        public BookViewModel(string bookId)
        {
            _bookId = bookId;
            if (_bookId != null)
            {
                this.GetBookDetails();

            }
            this.LoadBookTypes();
            this.LoadPublishers();
            /*            UpdateBookDetailsCommand = new RelayCommandWithoutParams(UpdateBookDetails);
                        DeleteBookCommand = new RelayCommandWithoutParams(DeleteBook);*/
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
            Dictionary<string, string> bookEntry = DbUtils.ExecuteQueryCommandById(DbUtils.QueryBookByIdProcedureText, Int32.Parse(_bookId), "BookId");
            GetBookDTO book = new GetBookDTO(bookEntry);
            BookTitle = book.Title;
            BookTypeName = book.BookTypeName;
            PublisherName = book.PublisherName;
            PublishYear = book.PublishYear;
            Stock = book.Stock;
        }

        private void LoadPublishers()
        {
            List<Dictionary<string, string>> listOfPublishers = DbUtils.ExecuteQueryAllCommand(DbUtils.QueryAllActivePublishersProcedureText);
            foreach (Dictionary<string, string> entry in listOfPublishers)
            {
                GetPublisherDTO getPublisherDTO = new GetPublisherDTO(entry);
                this.PublisherNameList.Add(getPublisherDTO.Name);
            }
        }

        private void LoadBookTypes()
        {
            List<Dictionary<string, string>> listOfBookTypes = DbUtils.ExecuteQueryAllCommand(DbUtils.QueryAllActiveBookTypesProcedureText);
            foreach (Dictionary<string, string> entry in listOfBookTypes)
            {
                GetBookTypeDTO bookTypeDTO = new GetBookTypeDTO(entry);
                this.BookTypeNameList.Add(bookTypeDTO.Name);
            }
        }

        //TODO: Implement book UPDATE and DELETE

        /* private void UpdateBookDetails()
         {

             if (_bookId != null)
             {
                 UpdateBookDTO bookToUpdate = new UpdateBookDTO(Int32.Parse(_bookId), _title, _publishYear, _stock);
                 DbUtils.ExecuteCommand(DbUtils.UpdateBookProcedureText, bookToUpdate);
             }
             else
             {
                 AddBookDTO bookToAdd = new AddBookDTO(_title, _publishYear, _stock);
                 DbUtils.ExecuteCommand(DbUtils.AddBookProcedureText, bookToAdd);
             }
         }

         private void DeleteBook()
         {

             DeleteBookDTO bookToDelete = new DeleteBookDTO(Int32.Parse(_bookId), false);
             DbUtils.ExecuteCommand(DbUtils.DeleteBookProcedureText, bookToDelete);
         }*/


    }
}
