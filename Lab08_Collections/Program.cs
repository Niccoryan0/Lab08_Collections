using Lab08_Collections.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Lab08_Collections
{
    class Program
    {
        public static Library<Book> Library { get; set; }
        public static List<Book> BookBag { get; set; }
        /// <summary>
        /// Instantiates library, bookbag, loads book and then runs the UI.
        /// </summary>
        static void Main()
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();
            LoadBooks();
            Console.WriteLine("Welcome to Phil's Lending Library!");
            UserInterface();
        }

        /// <summary>
        /// Runs the UI for the application
        /// </summary>
        static void UserInterface()
        {
            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(@"What would you like to do:
1. View all books
2. Add a book
3. Borrow a book
4. Return a book
5. View Book bag
6. Exit Program");
                string userChoice = Console.ReadLine();
                int.TryParse(userChoice, out choice);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        ViewLibrary();
                        break;
                    case 2:
                        HandleAddBook();
                        break;
                    case 3:
                        HandleBorrowBook();
                        break;
                    case 4:
                        HandleReturnBook();
                        break;
                    case 5:
                        ViewBookBag();
                        break;
                }

            }
        }

        /// <summary>
        /// Show all books in library.
        /// </summary>
        static void ViewLibrary()
        {
            Console.WriteLine("The following books are currently in the library:");
            foreach (Book book in Library)
            {
                Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}, with {book.NumberOfPages} and defined as genre: {book.Genre}");
            }
        }

        /// <summary>
        /// Show all books in bookbag.
        /// </summary>
        static void ViewBookBag()
        {
            Console.WriteLine("The following books are currently in your bookbag:");
            foreach (Book book in BookBag)
            {
                Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}");
            }
        }

        /// <summary>
        /// Get user input for adding a book
        /// </summary>
        static void HandleAddBook()
        {
            Console.WriteLine("Enter the book's title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the author's first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the author's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the number of pages:");
            string pageString = Console.ReadLine();
            int.TryParse(pageString, out int pages);
            Console.WriteLine("Select the book's genre from the following:");
            int i = 1;
            foreach (string genre in Enum.GetNames(typeof(Genre)))
            {
                Console.WriteLine($"{i}. {genre}");
                i++;
            }
            string genreString = Console.ReadLine();
            int.TryParse(genreString, out int genreParse);
            Genre genreChoice = (Genre)genreParse-1;
            AddBook(title, firstName, lastName, pages, genreChoice);
        }

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="title">Book Title</param>
        /// <param name="firstName">Author first name</param>
        /// <param name="lastName">Author last name</param>
        /// <param name="numberOfPages">Number of pages</param>
        /// <param name="genre">Genre</param>
        static void AddBook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book(title, firstName, lastName, numberOfPages, genre);
            Library.Add(book);
        }

        /// <summary>
        /// Handle user input for borrowing books
        /// </summary>
        static void HandleBorrowBook()
        {
            ViewLibrary();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("What is the name of the book you'd like to borrow?");
            string title = Console.ReadLine();
            BorrowBook(title);
        }

        /// <summary>
        /// Handle logic for borrowing a book
        /// </summary>
        /// <param name="title">Title of book to be borrows</param>
        /// <returns>Borrowed book</returns>
        public static Book BorrowBook(string title)
        {
            Book borrowed = default(Book);
            foreach (Book book in Library)
            {
                if (title == book.Title)
                {
                    borrowed = book;
                    BookBag.Add(Library.Remove(borrowed));
                    break;
                }
            }
            if (borrowed == null)
            {
                Console.WriteLine("Oh noes! Looks like that books not available.");
            }
            else
            {
                Console.WriteLine($"{title} borrowed successfully!");
            }
            return borrowed;
        }

        /// <summary>
        /// Return a book from the user's bookbag
        /// </summary>
        static void HandleReturnBook()
        {
            // Set up temporary book storing Dictionary and counter so they can be displayed below
            Dictionary<int, Book> tempBooks = new Dictionary<int, Book>();
            int counter = 1;
            Console.WriteLine("Which of your books would you like to return:");
            foreach (Book book in BookBag)
            {
                // Add all bookbag books to temporary dictionary
                tempBooks.Add(counter, book);
                Console.WriteLine($"{counter++}. {book.Title}");
            }
            string choice = Console.ReadLine();
            int.TryParse(choice, out int userChoice);
            // Check if the user's choice is in the tempBooks, and if so output the book object
            if (tempBooks.TryGetValue(userChoice, out Book result)){
                Console.WriteLine($"{result.Title} returned successfully!");
                Library.Add(result);
                BookBag.Remove(result);
            }else
            {
                Console.WriteLine("I think there's been an error!");
            }
        }

        /// <summary>
        /// Load hard coded books into library
        /// </summary>
        static void LoadBooks()
        {
            Library.Add(new Book("The Stranger", "Albert", "Camus", 176, Genre.Other));
            Library.Add(new Book("Fear and Trembling", "Soren", "Kierkegaard", 350, Genre.Philosophy));
            Library.Add(new Book("Dune", "Frank", "Herbert", 430, Genre.Scifi));
            Library.Add(new Book("Automate the Boring Stuff W/ Python", "Al", "Sweigart", 320, Genre.Instructional));
            Library.Add(new Book("Game of Thrones", "George", "Martin", 513, Genre.Fantasy));
        }
    }
}
