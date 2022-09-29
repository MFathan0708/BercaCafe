using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class Material
    {
        public int MaterialsId { get; set; }
        public int LogId { get; set; }
        public int MaterialsStock { get; set; }
        public int MaterialsQuantity { get; set; }
        public DateTime InputDate { get; set; }
        public int Flag { get; set; }

        public virtual MaterialsLog Log { get; set; }
    }
}
