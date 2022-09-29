using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class MsMenuImageUrlNew
    {
        public int MenuId { get; set; }
        public string LinkUrl { get; set; }

        public virtual MsUdc Menu { get; set; }
    }
}
