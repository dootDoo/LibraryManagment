using LibraryManagment.Models;
using LibraryManagment.Services;

namespace LibraryManagment.Components.Pages
{
    public partial class Books
    {
        public List<Book> books = new List<Book>();

        private Book book;

        private DBAcessor DbAcessor = new DBAcessor();
    }
}
