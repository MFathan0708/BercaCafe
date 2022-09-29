using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class MaterialsLog
    {
        public MaterialsLog()
        {
            Materials = new HashSet<Material>();
        }

        public int LogId { get; set; }
        public int CompTypeId { get; set; }
        public string MaterialsName { get; set; }
        public int MaterialsStock { get; set; }
        public int MaterialsQuantity { get; set; }
        public string MaterialsUnit { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public DateTime InputDate { get; set; }

        public virtual CompositionType CompType { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
