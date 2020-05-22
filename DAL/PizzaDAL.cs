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
            var pizzaList = context.Menus.Include(m => m.Prices).ToList();
            return pizzaList;
        }

        public void CreateOrder(Order orderObj,List<ItemOrdered> itemOrderedObj)
        {
            var returnedObj = context.Orders.Add(orderObj);
            context.SaveChanges();
            foreach(var item in itemOrderedObj)
            {
                item.OrderId = returnedObj.OrderId;
                context.ItemOrdereds.Add(item);
            }
            context.SaveChanges();
        }

        public void AddPizzaToCart(Cart CartObj)
        {
            var returnedObj = context.Carts.FirstOrDefault(t => t.OrderedBy == CartObj.OrderedBy && t.ProductId == CartObj.ProductId);
            if(returnedObj==null)
            {
                CartObj.Quantity = 1;
                context.Carts.Add(CartObj);
            }
            else
            {
                returnedObj.Quantity ++;
            }
            context.SaveChanges();
        }

        public void DeletePizzaFromCart(Cart CartObj)
        {
            var returnedObj = context.Carts.FirstOrDefault(t => t.OrderedBy == CartObj.OrderedBy && t.ProductId == CartObj.ProductId);
            if (returnedObj.Quantity<=1)
            {
                context.Carts.Remove(returnedObj);
            }
            else
            {
                returnedObj.Quantity--;
            }
            context.SaveChanges();
        }

        public List<Cart> GetCart (String Username)
        {
            var CartList = context.Carts.Where(t => t.OrderedBy == Username).ToList();
            return CartList;
        }

        public void CompleteOrder (String Username)
        {
            var CartList = context.Carts.Where(t => t.OrderedBy == Username).ToList();
            var OrderObj = new Order
            {
                OrderTime = DateTime.Now,
                OrderedBy = Username,
                OrderAmount = 100
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
    }
}
