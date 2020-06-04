﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// This class contains the properties of the price table which is never used stand-alone
    /// </summary>
    public class PriceDto
    {
            public int ProductId { get; set; }
            public int MenuId { get; set; }
            public string Size { get; set; }
            public int PriceOfProduct { get; set; }
    }
}
