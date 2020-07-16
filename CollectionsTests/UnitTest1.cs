using System;
using Xunit;
using Lab08_Collections;
using Lab08_Collections.Classes;

namespace CollectionsTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddBookToLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book book = new Book("The Stranger", "Albert", "Camus", 176, Genre.Other);
            Library.Add(book);
            Assert.Equal(1, Library.Count());
        }
        [Fact]
        public void CanRemoveBookFromLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book book = new Book("The Stranger", "Albert", "Camus", 176, Genre.Other);
            Book book2 = new Book("Dune", "Frank", "Herbert", 430, Genre.Scifi);

            Library.Add(book);
            Library.Add(book2);
            Book removed = Library.Remove(book2);
            Assert.Equal(book2, removed);
        }

        [Fact]
        public void CannotRemoveBookTheDoesntExistFromLibrary()
        {
            Library<Book> Library = new Library<Book>();
            Book book = new Book("The Stranger", "Albert", "Camus", 176, Genre.Other);
            Book book2 = new Book("Dune", "Frank", "Herbert", 430, Genre.Scifi);

            Library.Add(book);
            Library.Add(book);
            Library.Add(book);
            Book removed = Library.Remove(book2);
            Assert.Equal(default(Book), removed);
        }

        [Fact]
        public void GettersAndSettersBooks()
        {
            Book book = new Book();
            book.Title = "Dune";
            Assert.Equal("Dune", book.Title);
        }

        [Fact]
        public void GettersAndSettersAuthor()
        {
            Author author = new Author();
            author.FirstName = "Albert";
            Assert.Equal("Albert", author.FirstName);
        }

        [Fact]
        public void CanCountLibraryBooks()
        {
            Library<Book> Library = new Library<Book>();
            Book book = new Book("The Stranger", "Albert", "Camus", 176, Genre.Other);
            Book book2 = new Book("Dune", "Frank", "Herbert", 430, Genre.Scifi);

            Library.Add(book);
            Library.Add(book);
            Library.Add(book);
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
