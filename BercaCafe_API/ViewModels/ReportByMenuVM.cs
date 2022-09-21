using System;

namespace BercaCafe_API.ViewModels
{
    public class ReportByMenuVM
    {
        public string DESC1 { get; set; }
        public int Ice { get; set; }
        public int Hot { get; set; }
        public int Total { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime thruDate { get; set; }
    }
}
