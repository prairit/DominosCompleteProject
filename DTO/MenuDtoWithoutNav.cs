using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MenuDtoWithoutNav
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Category { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
    }
}
