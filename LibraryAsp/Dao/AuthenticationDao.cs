using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAsp.Models;

namespace LibraryAsp.Dao
{
    public class AuthenticationDao
    {
        LibraryDbContext myDb = new LibraryDbContext();
        public bool checkLogin(string email, string password)
        {
            var user = myDb.users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User getInformationByUserName(string email)
        {
            return myDb.users.Where(u => u.email == email).FirstOrDefault();
        }
    }
}