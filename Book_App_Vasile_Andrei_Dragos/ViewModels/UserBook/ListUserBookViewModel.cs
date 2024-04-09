using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.UserBook;
using Book_App_Vasile_Andrei_Dragos.Utils;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.UserBook
{

    public class ListUserBookViewModel : ObservableObject
    {
        private UserBookDAO _userBookDAO;
        private ObservableCollection<UserBookDTO> _userBookList = null;

        public ObservableCollection<UserBookDTO> UserBookList
        {
            get { return _userBookList; }
            set
            {
                _userBookList = value;
                OnPropertyChanged("UserBookList");

            }
        }
        public ListUserBookViewModel()
        {
            this.UserBookList = new ObservableCollection<UserBookDTO>();
            _userBookDAO = new UserBookDAO();
            this.LoadBooks();
        }


        private void LoadBooks()
        {
            this.UserBookList = _userBookDAO.GetAllUserBooks();
        }

    }
}

