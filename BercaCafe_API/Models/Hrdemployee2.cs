using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class Hrdemployee2
    {
        public int EmployeeKey { get; set; }
        public int? DirektoratKey { get; set; }
        public int? DivisionKey { get; set; }
        public string Name { get; set; }
    }
}
