using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    /// <summary>
    /// This class contains the properties of the Dto which is used for all operations pertaining to the account
    /// </summary>
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}