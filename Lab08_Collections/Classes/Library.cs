using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab08_Collections.Classes
{
    public class Library<Book> : IEnumerable<Book>
    {
        Book[] library = new Book[5];
        int count;

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="book">Book to be added</param>
        public void Add(Book book)
        {
            if (count == library.Length)
            {
                Array.Resize(ref library, library.Length * 2);
            }
            library[count++] = book;
        }

        /// <summary>
        /// Remove a given book from the library
        /// </summary>
        /// <param name="book">Book to be removed</param>
        /// <returns>Removed book</returns>
        public Book Remove(Book book)
        {
            int tempCounter = 0;
            // Make a temporary book array for purposes of indexing it
            Book[] temp;
            Book removed = default(Book);
            if (count < library.Length / 2)
            {
                temp = new Book[count - 1];
            }
            else
            {
                temp = new Book[library.Length];
            }
            if (IsAvailable(book))
            {
                for (int i = 0; i < count; i++)
                {
                    if (library[i] != null)
                    {
                        if (library[i].Equals(book))
                        {
                            removed = library[i];
                        }
                        else
                        {
                            temp[tempCounter] = library[i];
                            tempCounter++;
                        }
                    }
                }
                // Reassign library to temporary
                library = temp;
                count--;
            }
            return removed;
        }

        /// <summary>
        /// Check if a book is in the library
        /// </summary>
        /// <param name="book">The book to search for</param>
        /// <returns>Boolean for if book is in library</returns>
        public bool IsAvailable(Book book)
        {
            foreach (Book libBook in library)
            {
                if (libBook != null && libBook.Equals(book))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get a book count.
        /// </summary>
        /// <returns>Number of books</returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Makes the library enumerable
        /// </summary>
        /// <returns>Enumerator values in library</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return library[i];
            }
        }

        /// <summary>
        /// Magic
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
