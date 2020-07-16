using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public Genre Genre { get; set; }

        public Book(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Title = title;
            Author = new Author()
            {
                FirstName = firstName,
                LastName = lastName
            };
            NumberOfPages = numberOfPages;
            Genre = genre;
        }
        public Book()
        {

        }

    }
    public enum Genre
    {
        Scifi,
        Fantasy,
        Nonfiction,
        Instructional,
        Adventure,
        Mystery,
        Philosophy,
        Other
    }
}
