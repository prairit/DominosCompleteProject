using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
namespace DAL
{
    public class PizzaDAL
    {
        DominosEntities context;
        public PizzaDAL()
        {
            context = new DominosEntities();
        }
        public List<Menu> GetAllPizzas ()
        {
            try
            {
                var pizzaList = context.Menus.Include(m => m.Prices).ToList();
                return pizzaList;
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public void AddPizzaToCart(Cart CartObj)
        {
            try
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
            catch
            {
                return;
            }
        }

        public void DeletePizzaFromCart(Cart CartObj)
        {
            try
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
            catch
            {
                return;
            }
        }

        public List<Cart> GetCart (String Username)
        {
            try
            {

                var CartList = context.Carts.Where(t => t.OrderedBy == Username).ToList();
                return CartList;
            }
            catch
            {
                return new List<Cart>();
            }
        }

        public void CompleteOrder (String Username)
        {
            try
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
                        MenuId = item.MenuId,
                        Quantity = item.Quantity
                    };
                    ItemList.Add(itemOrdered);
                }
                context.ItemOrdereds.AddRange(ItemList);
                context.Carts.RemoveRange(CartList);
                context.SaveChanges();
            }
            catch
            {
                return;
            }
        }
    }
}
