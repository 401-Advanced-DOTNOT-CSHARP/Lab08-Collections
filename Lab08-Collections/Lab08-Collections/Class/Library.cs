using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_Collections.Class
{
    public class Library<T> : IEnumberable
    {
        T[] bookshelf = new T[10];
        int bookCount = 0;

        public void AddBook(T newBook)
        {
            if(bookCount == bookshelf.Length)
            {
                Array.Resize(ref bookshelf, bookshelf.Length * 2);
            }
            bookshelf[bookCount++] = newBook;
        }

            }
        }
