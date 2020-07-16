using Lab08_Collections.Class;
using System;
using System.Collections.Generic;

namespace Lab08_Collections
{
    class Program
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

                }else if(userChoice == "2")
                {
                    Console.WriteLine("Title of Book:");
                    string newBookTitle = Console.ReadLine();
                    Console.WriteLine("Author's First Name:");
                    string newBookAuthorFirstName = Console.ReadLine();
                    Console.WriteLine("Author's Last Name");
                    string newBookAuthorsLastName = Console.ReadLine();


                }else if(userChoice == "3")
                {
                    Dictionary<int, string> books = new Dictionary<int, string>();
                    Console.WriteLine("Please select one of the available books listed");


                }else if(userChoice == "4")
                {

                }else if(userChoice == "5")
                {

                }else if(userChoice == "6")
                {

                }
                else
                {

                }
                Console.Clear();
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
            Library.Add(returnedBook);
        }
        /// <summary>
        /// Is creating a new instance of a book which takes in the users inputs and creates a new instance of an author which takes in the users input
        /// the book then takes in the users input for number of pages, genre and then adding the book to the library
        /// </summary>
        /// <param name="title"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="genre"></param>
        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
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
                Genre = genre
            };

            Library.Add(book);
        }
    }
}
