using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    /// <summary>
    /// This class performs all the database operations required to manage the pizza information
    /// </summary>
    public class PizzaDAL
    {
        DominosEntities context;
        public PizzaDAL()
        {
            context = new DominosEntities();
        }
        /// <summary>
        /// This method returns the list of all the pizzas in the database
        /// </summary>
        /// <returns>List of all pizzas</returns>
        public List<Menu> GetAllPizzas ()
        {
            var pizzaList = context.Menus.Include(m => m.Prices).ToList();
            return pizzaList;
        }

        public void AddPizzaToCart(Cart CartObj)
        {
            var returnedObj = context.Carts.FirstOrDefault(t => t.OrderedBy == CartObj.OrderedBy && t.ProductId == CartObj.ProductId);
            if (returnedObj == null)
            {
                CartObj.Quantity = 1;
                context.Carts.Add(CartObj);
            }
            else
            {
                returnedObj.Quantity++;
            }
            context.SaveChanges();
        }
        /// <summary>
        /// This method deletes a single pizza from the cart
        /// </summary>
        /// <param name="CartObj">Object of cart that contains the details of the pizza</param>
        public void DeletePizzaFromCart(Cart CartObj)
        {
            var returnedObj = context.Carts.FirstOrDefault(t => t.OrderedBy == CartObj.OrderedBy && t.ProductId == CartObj.ProductId);
            if (returnedObj.Quantity <= 1)
            {
                context.Carts.Remove(returnedObj);
            }
            else
            {
                returnedObj.Quantity--;
            }
            context.SaveChanges();
        }
        /// <summary>
        /// This method returns all the items that are present in the cart for the user
        /// </summary>
        /// <param name="Username">Username of the logged in user</param>
        /// <returns></returns>
        public List<Cart> GetCart (String Username)
        {
            var CartList = context.Carts.Where(t => t.OrderedBy == Username).ToList();
            return CartList;
        }
        /// <summary>
        /// This method is triggered when the user completes the order and transfers the data from cart to itemordered table
        /// </summary>
        /// <param name="Username">The username of the logged in user</param>
        public void CompleteOrder (String Username)
        {
            var CartList = context.Carts.Where(t => t.OrderedBy == Username).ToList();
            var OrderObj = new Order
            {
                OrderTime = DateTime.Now,
                OrderedBy = Username
            };
            context.Orders.Add(OrderObj);
            context.SaveChanges();
            var ItemList = new List<ItemOrdered>();
            foreach (var item in CartList)
            {
                var itemOrdered = new ItemOrdered
                {
                    OrderId = OrderObj.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                ItemList.Add(itemOrdered);
            }
            context.ItemOrdereds.AddRange(ItemList);
            context.Carts.RemoveRange(CartList);
            context.SaveChanges();
        }
    }
}
