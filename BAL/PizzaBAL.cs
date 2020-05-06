using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class PizzaBAL
    {
        PizzaDAL pizzaDAL;

        public PizzaBAL()
        {
            pizzaDAL = new PizzaDAL();
        }
        public List<Menu> GetAllPizzas()
        {
            return pizzaDAL.GetAllPizzas();
        }
    }
}
