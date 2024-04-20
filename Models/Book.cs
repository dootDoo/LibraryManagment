namespace LibraryManagment.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }

        public Book()
        {
            ISBN = "";
            Title = "";
            Author = "";
            Category = "";
            Publisher = "";
            PublicationYear = 0;
        }
    }
}
