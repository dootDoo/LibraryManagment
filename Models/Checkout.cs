namespace LibraryManagment.Models
{
    public class Checkout
    {
        public int CheckoutId {  get; set; }
        public string ISBN { get; set; }
        public int MemberId { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReturnDate { get; set;}
        public string Title {  get; set; }
        public string Member { get; set; }
    }
}
