
namespace Book_App_Vasile_Andrei_Dragos.Models.Publisher
{
    public class PublisherDTO
    {
        public PublisherDTO(int publisherId,string name,string adress)
        {
            this.PublisherId = publisherId;
            this.Name = name;
            this.Adress = adress;
        }
        public int PublisherId { get; }
        public string Name { get; set; }
        public string Adress { get; set; }
     }
}
