using System;

namespace BercaCafe_API.ViewModels
{
    public class ReportEmployeeVM
    {
        public int EmployeeKey { get; set; }
        public string EmployeeName { get; set; }
        public string Dept { get; set; }
        public DateTime LogTime { get; set; }
        public string Vendor { get; set; }
    }
}
