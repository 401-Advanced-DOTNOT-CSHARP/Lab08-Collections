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
    }
}
