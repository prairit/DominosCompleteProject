using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL;
using DTO;

namespace BAL.Mapper
{
    class PizzaMapper
    {
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

        public MultipleItemCartDto ToCartDtoMapper(Cart cartObj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, MultipleItemCartDto>();
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<Price, PriceDto>();
            });
            var mapper = configuration.CreateMapper();
            var CartDto = mapper.Map<MultipleItemCartDto>(cartObj);
            return CartDto;
        }

    }
}
