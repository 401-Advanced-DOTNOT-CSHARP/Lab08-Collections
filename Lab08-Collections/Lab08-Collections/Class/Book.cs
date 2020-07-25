using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Class
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public int NumberOfPages { get; set; }
    }
    // Enum List of possible Genre's to be listed
    public enum Genre
    {
        Scifi,
        History,
        Mystery,
        Politics
    }
}
