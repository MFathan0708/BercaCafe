using System;

namespace BercaCafe_API.ViewModels
{
    public class ReportByCupVM
    {
        public int EmployeeKey { get; set; }
        public string Name { get; set; }

        public string DivisionName { get; set; }
        public int MyCup { get; set; }
        public int YourCup { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime thruDate { get; set; }
    }
}
