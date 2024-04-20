namespace LibraryManagment.Models
{
    internal interface BookInterface
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN {  get; set; }
        public string CategoryName { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
    }
}
