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
    public class AccountBAL
    {
        AccountDAL accountDAL;
        AccountMapper mapper;   
        public AccountBAL()
        {
            mapper = new AccountMapper();
            accountDAL = new AccountDAL();
        }
        public bool ValidateUser(UserDto userDto)
        {
            User userObj = mapper.UserMapper(userDto);
            bool val = accountDAL.ValidateUser(userObj);
            return val;
        }

        public void RegisterUser(UserDto userDto)
        {
            User userObj = mapper.UserMapper(userDto);
            accountDAL.RegisterUser(userObj);
        }
    }
}
