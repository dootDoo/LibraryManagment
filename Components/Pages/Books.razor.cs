using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Components;
using MySqlConnector;

namespace LibraryManagment.Components.Pages
{
    public partial class Books : PagesInterface
    {
        // Initialize variables
        public List<Book> books = new List<Book>();
        public List<Category> categories = new List<Category>();

        private Book book = new Book();
        private Book currentBook = new Book();

        private bool invalidValue = false;


        private BookAccessor bookAcessor = new BookAccessor();
        private CategoryAccessor categoryAcessor = new CategoryAccessor();

        //Get list of DB items into a list
        protected override void OnInitialized()
        {
            categories = categoryAcessor.Get();
            books = bookAcessor.Get();
        }

        //Add new book
        public void Add()
        {
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                invalidValue = true;
                return;
            }

            bookAcessor.Add(book);

            books = bookAcessor.Get();

            book = new Book
            {
            };

            invalidValue = false;

        }
        //Remove new book
        public void Remove(Book book)
        {
            bookAcessor.Remove(book);

            books = bookAcessor.Get();
        }
        //Select currentBook by id and display contents
        public void Select(ChangeEventArgs e)
        {
            string selectedISBN = e.Value.ToString();

            if (selectedISBN != "0")
            {
                currentBook = books.FirstOrDefault(book => book.ISBN == selectedISBN);
            }
            return;
        }
    }
}
