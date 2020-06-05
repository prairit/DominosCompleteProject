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
    /// <summary>
    /// This is the mapper class for account mapping
    /// </summary>
    class AccountMapper
    {
        /// <summary>
        /// This method takes in a UserDto and converts it to Model object using Automapper
        /// </summary>
        /// <param name="userDto">Object of Dto type</param>
        /// <returns>Object of model type</returns>
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

        public OrderDto OrderMapper(Order orderObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<ItemOrdered, ItemOrderedDto>();
            });
            var mapper = configuration.CreateMapper();
            var orderDto = mapper.Map<OrderDto>(orderObj);
            return orderDto;
        }
    }
}
