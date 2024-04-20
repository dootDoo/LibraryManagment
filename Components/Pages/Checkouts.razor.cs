using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Components;

namespace LibraryManagment.Components.Pages
{
    public partial class Checkouts : PagesInterface
    {
        // Initialize variables
        public List<Checkout> checkouts = new List<Checkout>();
        public List<Member> members = new List<Member>();
        public List<Book> books = new List<Book>();

        private Checkout checkout = new Checkout();
        private Checkout currentCheckout = new Checkout();

        private CheckoutAccessor checkoutAcessor = new CheckoutAccessor();
        private MemberAcessor memberAcessor = new MemberAcessor();
        private BookAccessor bookAcessor = new BookAccessor();

        //Get list of DB items into a list
        protected override void OnInitialized()
        {
            checkouts = checkoutAcessor.Get();
            members = memberAcessor.Get();
            books = bookAcessor.Get();

            checkout.CheckOutDate = DateTime.Now;
        }

        //Add new book
        public void Add()
        {
            checkoutAcessor.Add(checkout);

            checkouts = checkoutAcessor.Get();

            checkout = new Checkout { };
        }
        //Remove new book
        public void Remove(Checkout checkout)
        {
            checkoutAcessor.Remove(checkout);

            checkouts = checkoutAcessor.Get();
        }
        //Select currentBook by id and display contents
        public void Select(ChangeEventArgs e)
        {
            int selectedId = int.Parse(e.Value.ToString());

            if (selectedId > 0)
            {
                currentCheckout = checkouts.FirstOrDefault(checkout => checkout.CheckoutId == selectedId);
            }
            return;
        }
    }
}
