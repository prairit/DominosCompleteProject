using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class OrderDto
    {
        public int OrderId { get; set; }
        public Nullable<System.DateTime> OrderTime { get; set; }
        public string OrderedBy { get; set; }
        public ICollection<ItemOrderedDto> itemOrdereds{ get; set; }

    }
}
