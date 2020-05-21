using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class CartItemDto
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
    }
}