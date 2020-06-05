using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using BAL.Mapper;

namespace BAL
{
    /// <summary>
    /// This class contains the business logic for account handling
    /// </summary>
    public class AccountBAL
    {
        AccountDAL accountDAL;
        AccountMapper mapper;   
        public AccountBAL()
        {
            mapper = new AccountMapper();
            accountDAL = new AccountDAL();
        }
        /// <summary>
        /// This method takes the userDto and passes it to DAL in form of Model object
        /// </summary>
        /// <param name="userDto">Dto of user type</param>
        /// <returns>Boolean success or failure</returns>
        public bool ValidateUser(UserDto userDto)
        {
            User userObj = mapper.UserMapper(userDto);
            bool val = accountDAL.ValidateUser(userObj);
            return val;
        }
        /// <summary>
        /// This method takes the userDto and passes it to DAL in form of Model object
        /// </summary>
        /// <param name="userDto">Dto of the user type</param>
        public void RegisterUser(UserDto userDto)
        {
            User userObj = mapper.UserMapper(userDto);
            accountDAL.RegisterUser(userObj);
        }

        public List<OrderDto> GetOrders(string username)
        {
            var ordersList = accountDAL.GetOrders(username);
            List<OrderDto> orderDtosList = new List<OrderDto>();
            foreach(var item in ordersList)
            {
                orderDtosList.Add(mapper.OrderMapper(item));
            }
            return orderDtosList;
        }
    }
}
