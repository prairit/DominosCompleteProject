using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using DTO;
using BAL.Mapper;

namespace BAL
{
    public class PizzaBAL
    {
        PizzaDAL pizzaDAL;
        PizzaMapper mapper;

        public PizzaBAL()
        {
            pizzaDAL = new PizzaDAL();
            mapper = new PizzaMapper();
        }
        public List<MenuDto> GetAllPizzas()
        {
            var ListMenu = pizzaDAL.GetAllPizzas();
            List<MenuDto> ListMenuDto = new List<MenuDto>();
            foreach(var item in ListMenu)
            {
                ListMenuDto.Add(mapper.MenuMapper(item));
            }
            return ListMenuDto;
        }

        public void CreateOrder(List<CartItemDto> Cart)
        {
            double totalAmount = new double();
            List<ItemOrdered> ListitemOrdered = new List<ItemOrdered>();
            foreach(var item in Cart)
            {
                totalAmount += item.Price;
                ListitemOrdered.Add(new ItemOrdered { MenuId = item.MenuId, Quantity = item.Quantity});
            }
            var orderObj = new Order
            {
                OrderTime = DateTime.Now,
                OrderedBy=Cart[0].Username,
                OrderAmount=(totalAmount*1.05d)
            };
            pizzaDAL.CreateOrder(orderObj, ListitemOrdered);
        }
    }
}
