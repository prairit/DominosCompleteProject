using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// This class contains the properties of the Dto which is used when the cart items are requested
    /// </summary>
    public class MultipleItemCartDto
    {
        public int CartId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public string OrderedBy { get; set; }
        public int ProductId { get; set; }

        public virtual MenuDto Menu { get; set; }
        public virtual PriceDto Price { get; set; }
    }
}
