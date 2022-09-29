using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class AddComposition
    {
        public int AddCompId { get; set; }
        public int AddId { get; set; }
        public int CompTypeId { get; set; }
        public int Quantity { get; set; }
        public int AddType { get; set; }

        public virtual CompositionType CompType { get; set; }
    }
}
