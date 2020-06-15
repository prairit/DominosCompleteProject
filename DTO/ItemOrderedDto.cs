using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class ItemOrderedDto
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int MenuId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public virtual PriceDto Price { get; set; }
        public virtual MenuDtoWithoutNav Menu { get; set; }

    }
}
