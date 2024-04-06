using Book_App_Vasile_Andrei_Dragos.Models.Author;
using Book_App_Vasile_Andrei_Dragos.Utils;
using Book_App_Vasile_Andrei_Dragos.Utils.Database;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Book_App_Vasile_Andrei_Dragos.ViewModels.Author
{
    public class ListAuthorsViewModel: ObservableObject
    {
        private ObservableCollection<GetAuthorDTO> _authorList = null;

        public ObservableCollection<GetAuthorDTO> AuthorList
        {
            get { return _authorList; }
            set
            {
                _authorList = value;
                OnPropertyChanged("AuthorList");

            }
        }
        public ListAuthorsViewModel() {
            this.AuthorList = new ObservableCollection<GetAuthorDTO>();
            this.LoadAuthors();
        }
        

        private void LoadAuthors()
        {
            List<Dictionary<string, string>> listOfAuthors = DbUtils.ExecuteQueryAllCommand(DbUtils.QueryAllActiveAuthorsProcedureText);
            foreach(Dictionary<string, string> entry in listOfAuthors)
            {
                this.AuthorList.Add(new GetAuthorDTO(entry));
            }
        }

    }
}
