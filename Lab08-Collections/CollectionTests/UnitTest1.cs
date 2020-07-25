using System;
using Xunit;
using static Lab08_Collections.Program;
using Lab08_Collections.Class;

namespace CollectionTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddBookToLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book warz = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Library.AddBook(warz);
            Assert.Equal(1, Library.Count());
        }
        [Fact]
        public void CanRemoveBookFromLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book warz = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Book warz2 = new Book() { Title = "World War Z2", Author = new Author() { FirstName = "Awesome2", LastName = "Zombies2" }, Genre = Genre.Scifi };

            Library.AddBook(warz);
            Library.AddBook(warz2);
            Library.Remove(warz2);
            Assert.Equal(1, Library.Count());
        }
        [Fact]
        public void CannotRemoveBookTheDoesntExistFromLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book warz = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Book warz2 = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Book warz3 = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };


            Library.AddBook(warz);
            Library.AddBook(warz);
            Library.AddBook(warz3);
            Book removed = Library.Remove(warz2);
            Assert.Equal(default(Book), removed);
        }

        [Fact]
        public void GettersAndSettersBooks()
        {
            Book book = new Book();
            book.Title = "World War Z";
            Assert.Equal("World War Z", book.Title);
        }

        [Fact]
        public void GettersAndSettersAuthor()
        {
            Author author = new Author();
            author.FirstName = "Awesome";
            Assert.Equal("Awesome", author.FirstName);
        }

        [Fact]
        public void CanCountLibraryBooks()
        {
            Library<Book> Library = new Library<Book>();
            Book warz = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Book warz2 = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };
            Book warz3 = new Book() { Title = "World War Z", Author = new Author() { FirstName = "Awesome", LastName = "Zombies" }, Genre = Genre.Scifi };


            Library.AddBook(warz);
            Library.AddBook(warz2);
            Library.AddBook(warz3);
            int count = Library.Count();
            Assert.Equal(3, count);
        }

        [Fact]
        public void CanCountZeroLengthLibrary()
        {
            Library<Book> Library = new Library<Book>();
            int count = Library.Count();
            Assert.Equal(0, count);
        }
    }
}
