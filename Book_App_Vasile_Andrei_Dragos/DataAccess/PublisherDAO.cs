using Book_App_Vasile_Andrei_Dragos.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Book_App_Vasile_Andrei_Dragos.DataAccess
{
    public class PublisherDAO
    {
        private const string QueryAllActivePublishersProcedureText = "spPublisherSelectAllActive";

        public PublisherDAO() { }

        public ObservableCollection<PublisherDTO> GetAllPublishers()
        {
            ObservableCollection<PublisherDTO> publishersList = new ObservableCollection<PublisherDTO>();
            List<Dictionary<string, string>> listOfpublishers = DatabaseAccess.ExecuteQueryAllCommand(QueryAllActivePublishersProcedureText);
            foreach (Dictionary<string, string> entry in listOfpublishers)
            {
                int publisherId = Int32.Parse(entry["PublisherId"]);
                string name = entry["Name"];
                string adress = entry["Adress"];
                publishersList.Add(new PublisherDTO(publisherId, name, adress));
            }

            return publishersList;
        }
        /* public PublisherDTO GetPublisherById(string publisherId)
         {

         }

         public void CreatePublisher(PublisherCreateDTO publisherToAdd)
         {

         }

         public void UpdatePublisher(PublisherDTO publisherToUpdate)
         {

         }

         public void DeletePublisher(string publisherId)
         {

         }*/
    }
}
