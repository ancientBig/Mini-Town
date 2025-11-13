using _1.KasiLibrary.Entity;
public class Program
{
    public static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book { Title = "How to write code", Author = "Douglas Adams", ISBN = "978-0345391803", PublicationYear = 1979 });
        library.AddBook(new Book { Title = "When the sun stops shining", Author = "Frank Herbert", ISBN = "978-0441172719", PublicationYear = 1965 });
        library.AddBook(new Book { Title = "1984", Author = "George Orwell", ISBN = "978-0451524935", PublicationYear = 1949 });

        int menuOption = 0;
        while(menuOption != -1)
        {
            menu(library);
            menuOption = int.Parse(Console.ReadLine());
            switch (menuOption)
            {
                case 1:
                    searchForBook(library);
                    break;
                case 2:
                    AddBook(library);
                    break;
                case 3:
                    remove(library);
                    break;
                case 4:
                    library.DisplayAllBooks();
                    break;
                case 0:
                    Console.WriteLine("\n Goodbye...");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n Goodbye...");
                    System.Environment.Exit(0);
                    break;
            }
        }

        static void searchForBook(Library library)
        {
            // Display a prompt to the user
            Console.WriteLine("Please enter title of book:");
            string title = Console.ReadLine();
            var searchResults = library.SearchByTitle(title);
            Console.WriteLine($"\nSearch Results for '{title}':");
            foreach (var book in searchResults)
            {
                Console.WriteLine(book);
            }
        }

        static void menu(Library library)
        {
            Console.WriteLine("Welcome to Kasi Library");
            Console.WriteLine("\n Here is the list of available books:");

            Console.WriteLine("\n ------------------------------");
            Console.WriteLine("\n Menu:");
            Console.WriteLine("\n 1-----Search Book by tittle");
            Console.WriteLine("\n 2-----Add book");
            Console.WriteLine("\n 3-----Remove book by ISBN");
            Console.WriteLine("\n 4-----See all the Book");
            Console.WriteLine("\n 0-----To exit");
            Console.WriteLine("\n ------------------------------");
        }

        static void AddBook(Library library)
        {
            // Display a prompt to the user
            Console.WriteLine("Please enter title of book:");
            string title = Console.ReadLine();
            Console.WriteLine("Please ISBN:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Please year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Author:");
            string author = Console.ReadLine();
            library.AddBook(new Book { Title = title, Author = author, ISBN = isbn, PublicationYear = year });
            Console.WriteLine("Book Has been added!");
        }

        static void remove(Library library) {
            Console.WriteLine("Please ISBN of book to remove:");
            string isbn = Console.ReadLine();
            library.RemoveBook(isbn);
        }
    }

}