using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// This is the DAL class which performs the Database operations for account authentication and registration
    /// </summary>
    public class AccountDAL
    {
        DominosEntities context;
        public AccountDAL()
        {
            context = new DominosEntities();
        }
        /// <summary>
        /// This method validates if the user is present in the database
        /// </summary>
        /// <param name="userObj">Object of user</param>
        /// <returns>boolean value of failure or success</returns>
        public bool ValidateUser(User userObj)
        {
            bool IsValidUser = context.Users
            .Any(u => u.UserName == userObj.UserName && 
            u.Password == userObj.Password);
            return IsValidUser;
        }
        /// <summary>
        /// This method registers a new user
        /// </summary>
        /// <param name="userObj">Object of user type that need to be registered</param>
        public void RegisterUser(User userObj)
        {
            context.Users.Add(userObj);
            context.SaveChanges();            
        }

        public List<Order> GetOrders(string username)
        {
            var orders =context.Orders.Where(order => order.OrderedBy == username).ToList();
            return orders;
        }
    }
}
