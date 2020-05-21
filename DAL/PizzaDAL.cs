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
    }
}
