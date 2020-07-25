using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Class
{
    public class Library<T> : IEnumerable
    {
        T[] bookshelf = new T[10];
        int bookCount = 0;
        /// <summary>
        /// Method that adds a book to the Library
        /// </summary>
        /// <param name="newBook">The book object that is to be added</param>
        public void AddBook(T newBook)
        {
            if(bookCount == bookshelf.Length)
            {
                Array.Resize(ref bookshelf, bookshelf.Length * 2);
            }
            bookshelf[bookCount++] = newBook;
        }
        /// <summary>
        /// Removes the book object from the Library
        /// </summary>
        /// <param name="item">The book object to be removed</param>
        /// <returns>The book that was removed</returns>
        public T Remove(T item)
        {
            int removeCount = 0;
            T[] temp;
            T removed = default(T);

            if (bookCount < bookshelf.Length /2)
            {
                temp = new T[bookCount - 1];
            }
            else
            {
                temp = new T[bookshelf.Length];
            }

            for (int i = 0; i < bookCount; i++)
            {
                if(bookshelf[i] == null)
                {

                if (bookshelf[i].Equals(item))
                {
                    removed = bookshelf[i];
                }
                else
                {
                    temp[removeCount] = bookshelf[i];
                    removeCount++;
                }
                }
            }
            bookshelf = temp;
            bookCount--;
            return removed;
        }
        /// <summary>
        /// Method that returns the number of books currently in the Library
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return bookCount;
        }
        /// <summary>
        /// Method that iterates over each book in the library
        /// </summary>
        /// <returns>The book</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < bookCount; i++)
            {
                yield return bookshelf[i];
            }

        }
        /// <summary>
        /// Magic aka a method that is required
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
        }
