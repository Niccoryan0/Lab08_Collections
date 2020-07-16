using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Classes
{
    public class Library<Book> : IEnumerable<Book>
    {
        Book[] library = new Book[5];
        int count;

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
            int removedSize = count - 1;
            int tempCounter = 0;
            Book[] temp;
            Book removed = default(Book);
            if (count < library.Length / 2)
            {
                temp = new Book[removedSize];
            }
            else
            {
                temp = new Book[library.Length];
            }
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
            if (removed.Equals(default(Book)))
            {
                Console.WriteLine("It looks like that book isn't in the library!");
            }
            else
            {
                library = temp;
                count--;
            }
            return removed;
        }

        public int Count()
        {
            return count;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return library[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
