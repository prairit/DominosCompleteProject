﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        DominosEntities context;
        public AccountDAL()
        {
            context = new DominosEntities();
        }

        public bool ValidateUser(User userObj)
        {
            try
            {
                bool IsValidUser = context.Users
               .Any(u => u.UserName == userObj.UserName.ToLower() && u
               .Password == userObj.Password);
                return IsValidUser;
            }
            catch
            {
                return false;
            }
            
        }

        public void RegisterUser(User userObj)
        {
            try
            {
                context.Users.Add(userObj);
                context.SaveChanges();
            }
            catch
            {
                return;
            }
            
        }
    }
}
