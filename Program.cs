namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Library library = new Library();
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n ---------------- Library Management System ----------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - Add Book");
                Console.WriteLine("2 - Remove Book");
                Console.WriteLine("3 - Display all Books");
                Console.WriteLine("4 - Borrow a Book");
                Console.WriteLine("5 - Return a Book");
                Console.WriteLine("6 - Exit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose One: ");
                Console.ResetColor();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter Book ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();
                        library.AddBook(id, title, author);
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Enter Book ID to delete: ");
                        id = int.Parse(Console.ReadLine());
                        library.RemoveBook(id);
                        break;

                    case "3":
                        library.DisplayBooks();
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Enter Book ID to Borrow: ");
                        id = int.Parse(Console.ReadLine());
                        library.BorrowBook(id);
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter Book ID to Return: ");
                        id = int.Parse(Console.ReadLine());
                        library.ReturnBook(id);
                        break;

                    case "6":
                        running = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Thanks For Using Our 'Library Management System'");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("'Invalid' Choice Please Try Again");
                        break;
                }
                Console.ResetColor();
            }
        }

        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsAvailable { get; set; } = true;
        }

        public class Library
        {
            public List<Book> books = new List<Book>();

            public void AddBook(int id, string title, string author)
            {
                books.Add(new Book { Id = id, Title = title, Author = author });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book Successfully Added");
                Console.ResetColor();
            }

            public void RemoveBook(int id)
            {
                Book book = books.Find(b => b.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book Successfully Deleted");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Book Not Found");
                }
                Console.ResetColor();
            }

            public void DisplayBooks()
            {
                if (books.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No books in The Library");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Books List in Library:");
                    Console.ResetColor();
                    foreach (Book book in books)
                    {
                        Console.ForegroundColor = book.IsAvailable ? ConsoleColor.Green : ConsoleColor.DarkRed;
                        Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Availability: {(book.IsAvailable ? "Yes" : "No")}");
                        Console.ResetColor();
                    }
                }
            }

            public void BorrowBook(int id)
            {
                Book book = books.Find(b => b.Id == id);
                if (book != null && book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Borrowed Successfully");
                }
                else if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Book not found in Library");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The book is Not Available (Already Borrowed)");
                }
                Console.ResetColor();
            }

            public void ReturnBook(int id)
            {
                Book book = books.Find(b => b.Id == id);
                if (book != null && !book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book is returned Successfully");
                }
                else if (book == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Book is Not Found in Library");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This book was not Borrowed");
                }
                Console.ResetColor();
            }
        }
    }
}
