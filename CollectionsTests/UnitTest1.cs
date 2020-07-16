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

    }
}
