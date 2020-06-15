using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL;
using DTO;

namespace BAL.Mapper
{
    /// <summary>
    /// This is the mapper class for pizza mapping
    /// </summary>
    class PizzaMapper
    {
        /// <summary>
        /// This method takes in a menu Model object and converts it to Dto object using Automapper
        /// </summary>
        /// <param name="MenuObj">menu Model object</param>
        /// <returns>menu Dto object</returns>
        public MenuDto MenuMapper(Menu MenuObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<Price, PriceDto>();
            });
            var mapper = configuration.CreateMapper();
            var MenuDtoObj = mapper.Map<MenuDto>(MenuObj);
            return MenuDtoObj;
        }
        /// <summary>
        /// This method takes in a cart Dto object and converts it to Model object using Automapper
        /// </summary>
        /// <param name="cartSingleItemDto">cart Dto object</param>
        /// <returns>cart Model object</returns>
        public Cart ToCartObjMapper(CartSingleItemDto cartSingleItemDto)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartSingleItemDto, Cart>();
            });
            var mapper = configuration.CreateMapper();
            var CartObj = mapper.Map<Cart>(cartSingleItemDto);
            return CartObj;
        }
        /// <summary>
        /// This methodtakes in a cart Model object and converts it to Dto object using Automapper
        /// </summary>
        /// <param name="cartObj">cart Model object</param>
        /// <returns>cart Dto object</returns>
        public MultipleItemCartDto ToCartDtoMapper(Cart cartObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, MultipleItemCartDto>();
                cfg.CreateMap<Menu, MenuDtoWithoutNav>();
                cfg.CreateMap<Price, PriceDto>();
            });
            var mapper = configuration.CreateMapper();
            var CartDto = mapper.Map<MultipleItemCartDto>(cartObj);
            return CartDto;
        }

    }
}
