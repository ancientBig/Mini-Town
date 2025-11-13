
namespace _1.KasiLibrary.Entity
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Added: {book.Title}");
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Removed book with ISBN: {isbn}");
            }
            else
            {
                Console.WriteLine($"Book with ISBN {isbn} not found.");
            }
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void DisplayAllBooks()
        {
            if (books.Any())
            {
                Console.WriteLine("\nCurrent Library Collection:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("\nLibrary is empty.");
            }
        }
    }
}
