﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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

        public void editUser(User user)
        {
            string sql = "update dbo.Users set fullname=@fullname,address =@address,gender = @gender,phone=@phone ,birthday = @birthday where email = @email";
            myDb.Database.ExecuteSqlCommand(sql, new SqlParameter("@fullname", user.fullname),
                new SqlParameter("@address", user.address),
                new SqlParameter("@gender", user.gender),
                new SqlParameter("@birthday", user.birthday),
                new SqlParameter("@phone", user.phone),
                new SqlParameter("@email", user.email)
            );
        }

        public void updatePassword(string email,string password)
        {
            string sql = "update dbo.Users set password = @password where email = @email";
            myDb.Database.ExecuteSqlCommand(sql, new SqlParameter("@email", email),
                new SqlParameter("@password", password)
            );
        }

        public List<User> getAll()
        {
            return myDb.users.OrderByDescending(u => u.id_user).ToList();
        }
    }
}