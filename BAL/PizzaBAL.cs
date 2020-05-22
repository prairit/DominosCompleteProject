using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
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

        public void PostPizza (CartSingleItemDto cartItemDto)
        {
            var CartObj = mapper.ToCartObjMapper(cartItemDto);
            pizzaDAL.AddPizzaToCart(CartObj);
        }

        public void DeletePizza(CartSingleItemDto cartItemDto)
        {
            var CartObj = mapper.ToCartObjMapper(cartItemDto);
            pizzaDAL.DeletePizzaFromCart(CartObj);
        }

        public List<MultipleItemCartDto> GetCart(String Username)
        {
            var CartList = pizzaDAL.GetCart(Username);
            var CartDtoList = new List<MultipleItemCartDto>();
            foreach(var item in CartList)
            {
                CartDtoList.Add( mapper.ToCartDtoMapper(item));
            }
            return CartDtoList;
        }

        public void CompleteOrder(String Username)
        {
            pizzaDAL.CompleteOrder(Username);
        }
    }
}
