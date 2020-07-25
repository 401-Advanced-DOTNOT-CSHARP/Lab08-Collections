using Lab08_Collections.Class;
using System;
using System.Collections.Generic;

namespace Lab08_Collections
{
    public class Program
    {
        public static Library<Book> Library { get; set; }
        public static List<Book> BookBag { get; set; }
        static void Main(string[] args)
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();
            LoadBooks();
            UserInterface();

    }
        /// <summary>
        /// Method that prompts the user and calls all other methods
        /// </summary>
        static void UserInterface()
        {
            string userChoice = "";
            while(userChoice != "6")
            {
            Console.WriteLine("Welcome to Phil's Lending Library!!!");
            Console.WriteLine("Please select an option below");
            Console.WriteLine("1. View List of Books");
            Console.WriteLine("2. Add a Book to the list");
            Console.WriteLine("3. Rent a book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. View list of books checked out");
            Console.WriteLine("6. Exit");
                userChoice = Console.ReadLine();
                Console.Clear();
                if(userChoice == "1")
                {
                    ShowAllBooks();

                }
                else if(userChoice == "2")
                {
                    Console.WriteLine("Title of Book:");
                    string newBookTitle = Console.ReadLine();
                    Console.WriteLine("Author's First Name:");
                    string newBookAuthorFirstName = Console.ReadLine();
                    Console.WriteLine("Author's Last Name:");
                    string newBookAuthorsLastName = Console.ReadLine();
                    Console.WriteLine("Number of Pages:");
                    string numberOfPages = Console.ReadLine();
                    int.TryParse(numberOfPages, out int result);
                    AddABook(newBookTitle, newBookAuthorFirstName, newBookAuthorsLastName, result);


                }
                else if(userChoice == "3")
                {
                    Dictionary<int, string> books = new Dictionary<int, string>();
                    Console.WriteLine("Please select one of the available books listed");
                    int counter = 1;
                    foreach(Book book in Library)
                    {
                        books.Add(counter, book.Title);
                        Console.WriteLine($"{counter++}, {book.Title}, {book.Author.FirstName}, {book.Author.LastName} ");
                    }
                    string response = Console.ReadLine();
                    int.TryParse(response, out int result);
                    books.TryGetValue(result, out string borrowed);
                    Borrow(borrowed);
                    Console.Clear();

                }
                else if(userChoice == "4")
                {
                    ReturnBook();
                }
                else if(userChoice == "5")
                {
                    Console.Clear();
                    foreach(Book book in BookBag)
                    {
                        if(book.Author == null)
                        {
                            Console.WriteLine("No books currently checked out");
                            Console.WriteLine("");

                        }
                        else
                        {
                        Console.WriteLine($"{book.Title}, {book.Author.FirstName}, {book.Author.LastName}");
                        Console.WriteLine("");

                        }
                    }
                }
                else if(userChoice == "6")
                {
                    Environment.Exit(1);

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        /// <summary>
        /// The ForEach is iterating over all items in the BookBag and displaying them to the user.
        /// response is the users input
        /// converting the users response to an int
        /// TryGetValue is verifying that books contains the book requesting to be removed
        /// remove is removing the book from their checked out books and then adding it back to the available list of books
        /// </summary>
        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.AddBook(returnedBook);
        }
        /// <summary>
        /// Is creating a new instance of a book which takes in the users inputs and creates a new instance of an author which takes in the users input
        /// the book then takes in the users input for number of pages, genre and then adding the book to the library
        /// </summary>
        /// <param name="title">Title of the book to be added</param>
        /// <param name="firstName">Author's First Name to be added</param>
        /// <param name="lastName">Author's Last Name to be added</param>
        /// <param name="numberOfPages">Amount of pages in the book</param>
        /// <param name="genre">The category to be placed</param>
        static void AddABook(string title, string firstName, string lastName, int numberOfPages)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = Genre.Scifi
            };

            Library.AddBook(book);
        }
        /// <summary>
        /// Displays all the books to the user that have been added to the Library and have not been checked out
        /// </summary>
        static void ShowAllBooks()
        {
            int counter = 1;
            foreach(Book book in Library)
            {
                Console.WriteLine($"{counter++}. {book.Title} {book.Author.FirstName} {book.Author.LastName}");
            }
        }
        /// <summary>
        /// Creates 5 initial books and puts them in the Library
        /// </summary>
        static void LoadBooks()
        {
            Book hatchet = new Book(){ Title = "Hatchet", Author = new Author() { FirstName = "John", LastName = "Lewis" }, Genre = Genre.History };
            Book got = new Book() { Title = "Song of Ice and Fire", Author = new Author() { FirstName = "George", LastName = "Martin" }, Genre = Genre.History };
            Book scar = new Book() { Title = "Scarlett Letter", Author = new Author() { FirstName = "Nathaniel", LastName = "Hawthorne" }, Genre = Genre.History };
            Book prairie = new Book() { Title = "Little House on the Prairie", Author = new Author() { FirstName = "Laura", LastName = "Wilder" }, Genre = Genre.History };
            Book war = new Book() { Title = "The Art of War", Author = new Author() { FirstName = "Sun", LastName = "Tzu" }, Genre = Genre.History };

            Library.AddBook(hatchet);
            Library.AddBook(got);
            Library.AddBook(scar);
            Library.AddBook(prairie);
            Library.AddBook(war);
        }
        /// <summary>
        /// Removes the book from the Library and adds it to the BookBag which represents it being borrowed and no longer available
        /// </summary>
        /// <param name="title">The title of the book being borrowed</param>
        /// <returns>The borrowed book</returns>
        public static Book Borrow(string title)
        {
            Book borrowed = null;
            foreach(Book book in Library)
            {
                if(book.Title == title)
                {
                borrowed = book;
                BookBag.Add(book);
                    Library.Remove(borrowed);
                }
            }
            return borrowed;
        }
    }
}
