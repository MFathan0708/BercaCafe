using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class Composition
    {
        public int CompId { get; set; }
        public int MenuId { get; set; }
        public int CompTypeId { get; set; }
        public int Quantity { get; set; }
        public int MenuType { get; set; }

        public virtual CompositionType CompType { get; set; }
    }
}
