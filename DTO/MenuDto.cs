using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{ 
    /// <summary>
    /// This class contains the properties of the Dto which is used while displaying the pizzas
    /// </summary>
        public class MenuDto
        {
            public int MenuId { get; set; }
            public string MenuName { get; set; }
            public string Category { get; set; }
            public string ImageSrc { get; set; }
            public string Description { get; set; }
            public virtual ICollection<PriceDto> Prices { get; set; }
        }

}
