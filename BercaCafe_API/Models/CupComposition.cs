using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class CupComposition
    {
        public int CupCompId { get; set; }
        public int CupId { get; set; }
        public int CompTypeId { get; set; }
        public int Quantity { get; set; }
        public int CupType { get; set; }

        public virtual CompositionType CompType { get; set; }
    }
}
