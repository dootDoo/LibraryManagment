namespace LibraryManagment.Models
{
    public class Book : BookInterface
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
    }
}
