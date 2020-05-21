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
    }
}
