using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class CompositionType
    {
        public CompositionType()
        {
            AddCompositions = new HashSet<AddComposition>();
            Compositions = new HashSet<Composition>();
            CupCompositions = new HashSet<CupComposition>();
            MaterialsLogs = new HashSet<MaterialsLog>();
        }

        public int CompTypeId { get; set; }
        public string TypeName { get; set; }
        public int TypeQuantity { get; set; }
        public string CompUnit { get; set; }

        public virtual ICollection<AddComposition> AddCompositions { get; set; }
        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<CupComposition> CupCompositions { get; set; }
        public virtual ICollection<MaterialsLog> MaterialsLogs { get; set; }
    }
}
