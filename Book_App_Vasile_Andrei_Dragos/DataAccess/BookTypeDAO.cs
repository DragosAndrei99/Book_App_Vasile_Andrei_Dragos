
using Book_App_Vasile_Andrei_Dragos.Models.BookType;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class BookTypeDAO
    {
        private const string QueryAllActiveBookTypesProcedureText = "spBookTypeSelectAllActive";

        public BookTypeDAO() { }

        public ObservableCollection<BookTypeDTO> GetAllBookTypes()
        {
            ObservableCollection<BookTypeDTO> bookTypesList = new ObservableCollection<BookTypeDTO>();
            List<Dictionary<string, string>> listOfBookTypes = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActiveBookTypesProcedureText);
            foreach (Dictionary<string, string> entry in listOfBookTypes)
            {
                int bookTypeId = Int32.Parse(entry["BookTypeId"]);
                string name = entry["Name"];
                bookTypesList.Add(new BookTypeDTO(bookTypeId, name));
            }

            return bookTypesList;
        }
       /* public BookTypeDTO GetBookTypeById(string bookTypeId)
        {
            
        }

        public void CreateBookType(BookTypeCreateDTO bookTypeToAdd)
        {

        }

        public void UpdateBookType(BookTypeDTO bookTypeToUpdate)
        {

        }

        public void DeleteBookType(string bookTypeId)
        {
      
        }*/
    }
}
