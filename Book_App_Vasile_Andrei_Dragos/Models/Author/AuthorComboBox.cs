namespace Book_App_Vasile_Andrei_Dragos.Models.Author
{
    public class AuthorComboBox
    {
        public AuthorComboBox(int authorId, string fullName, bool isChecked = false) {
            this.AuthorId = authorId;
            this.Fullname = fullName;
            this.IsChecked = isChecked;
        }

        public int AuthorId { get; }
        public string Fullname { get; set; }
        public bool IsChecked { get; set; }
    }
}
