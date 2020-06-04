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
    /// <summary>
    /// This class contains the business logic for pizza information handling
    /// </summary>
    public class PizzaBAL
    {
        PizzaDAL pizzaDAL;
        PizzaMapper mapper;

        public PizzaBAL()
        {
            pizzaDAL = new PizzaDAL();
            mapper = new PizzaMapper();
        }
        /// <summary>
        /// This method simply maps the pizza to dto object
        /// </summary>
        /// <returns>List of all the pizzas</returns>
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
        /// <summary>
        /// This method takes in Dto of a cart item and maps it to Model object and passes it to DAL
        /// </summary>
        /// <param name="cartItemDto">Dto of a cart item</param>
        public void PostPizza (CartSingleItemDto cartItemDto)
        {
            var CartObj = mapper.ToCartObjMapper(cartItemDto);
            pizzaDAL.AddPizzaToCart(CartObj);
        }
        /// <summary>
        /// This method takes in dto of a cart item and maps it to Model object and passes it to DAL
        /// </summary>
        /// <param name="cartItemDto">Dto of a cart item</param>
        public void DeletePizza(CartSingleItemDto cartItemDto)
        {
            var CartObj = mapper.ToCartObjMapper(cartItemDto);
            pizzaDAL.DeletePizzaFromCart(CartObj);
        }
        /// <summary>
        /// This method takes in username of the logged in user and passes it to the DAL layer
        /// </summary>
        /// <param name="Username">username of the logged in user</param>
        /// <returns>List of items in the cart of the user</returns>
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
        /// <summary>
        /// This method completes the order of the user
        /// </summary>
        /// <param name="Username">username of the logged in user</param>
        public void CompleteOrder(String Username)
        {
            pizzaDAL.CompleteOrder(Username);
        }
    }
}
