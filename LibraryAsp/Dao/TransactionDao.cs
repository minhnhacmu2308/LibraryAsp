using LibraryAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAsp.Dao
{
    public class TransactionDao
    {
        LibraryDbContext myDb = new LibraryDbContext();

        public void borrowBook(Transaction transaction)
        {
            myDb.transactions.Add(transaction);
            myDb.SaveChanges();
        }

        public Transaction checkExistTransaction(int userId, int bookId)
        {
            return myDb.transactions.Where(t => t.id_user == userId && t.id_book == bookId).FirstOrDefault();
        }

        public List<Transaction> getTransactionBorrow()
        {
            return myDb.transactions.OrderByDescending(t => t.id_transaction).Where(t => t.status != 4).ToList();
        }

        public List<Transaction> getTransactionPunish()
        {
            return myDb.transactions.OrderByDescending(t => t.id_transaction).Where(t => t.status == 4).ToList();
        }

    }
}