using System.Collections.ObjectModel;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.DataAccess;
using Book_App_Vasile_Andrei_Dragos.Models.Author;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Author
{
    public class ListAuthorsViewModel: ObservableObject
    {
        private AuthorDAO _authorDAO;
        private ObservableCollection<AuthorDTO> _authorList = null;

        public ObservableCollection<AuthorDTO> AuthorList
        {
            get { return _authorList; }
            set
            {
                _authorList = value;
                OnPropertyChanged("AuthorList");

            }
        }
        public ListAuthorsViewModel() {
            _authorDAO = new AuthorDAO();
            this.AuthorList = new ObservableCollection<AuthorDTO>();
            this.LoadAuthors();
        }
        

        private void LoadAuthors()
        {
            this.AuthorList = _authorDAO.GetAllAuthors();
        }

    }
}
