//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemOrdered
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Menu Menu { get; set; }
    }
}
