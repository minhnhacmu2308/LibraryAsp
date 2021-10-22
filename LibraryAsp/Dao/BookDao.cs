using LibraryAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAsp.Dao
{
    public class BookDao
    {
        LibraryDbContext myDb = new LibraryDbContext();

        public List<Book> getAll()
        {
            return myDb.books.OrderByDescending(p => p.id_book).ToList();
        }

    }
}