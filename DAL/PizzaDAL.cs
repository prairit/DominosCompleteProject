using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            var pizza = context.Menus.Include(m => m.Prices).ToList();
            return pizza;
        }
    }
}
