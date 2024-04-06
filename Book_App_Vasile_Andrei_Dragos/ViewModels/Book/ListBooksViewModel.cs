using Book_App_Vasile_Andrei_Dragos.Models.Book;
using Book_App_Vasile_Andrei_Dragos.Utils.Database;
using Book_App_Vasile_Andrei_Dragos.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Book
{
    public class ListBooksViewModel : ObservableObject
    {
        private ObservableCollection<GetBookDTO> _bookList = null;

        public ObservableCollection<GetBookDTO> BookList
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
            this.BookList = new ObservableCollection<GetBookDTO>();
            this.LoadBooks();
        }


        private void LoadBooks()
        {
            List<Dictionary<string, string>> listOfBooks = DbUtils.ExecuteQueryAllCommand(DbUtils.QueryAllActiveBooksProcedureText);
            foreach (Dictionary<string, string> entry in listOfBooks)
            {
               this.BookList.Add(new GetBookDTO(entry));
            }
        }

    }
}
