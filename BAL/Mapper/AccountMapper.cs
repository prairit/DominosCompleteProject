using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;

namespace BAL.Mapper
{
    class AccountMapper
    {
        public User UserMapper(UserDto userDto)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>();
            });
            var mapper = configuration.CreateMapper();
            var UserObj = mapper.Map<User>(userDto);
            return UserObj;
        }
    }
}
