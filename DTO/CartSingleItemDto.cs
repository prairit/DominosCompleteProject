using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// This class contains the properties of the Dto object which is used when a user adds or deletes an item in the cart
    /// </summary>
    public class CartSingleItemDto
    {
        public int MenuId { get; set; }
        public int ProductId { get; set; }
        public string OrderedBy { get; set; }
    }
}
