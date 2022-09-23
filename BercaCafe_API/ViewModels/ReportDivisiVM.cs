using System;

namespace BercaCafe_API.ViewModels
{
    public class ReportDivisiVM
    {
        public string Vendor { get; set; }
        public string DirektoratName { get; set; }
        public string divisionname { get; set; }
        public string Dept { get; set; }
        public int Jml { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}
