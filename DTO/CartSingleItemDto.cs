using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CartSingleItemDto
    {
        public int MenuId { get; set; }
        public int ProductId { get; set; }
        public string OrderedBy { get; set; }
    }
}
