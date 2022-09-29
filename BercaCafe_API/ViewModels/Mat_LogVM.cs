using System;

namespace BercaCafe_API.ViewModels
{
    public class Mat_LogVM
    {
        public int LogId { get; set; }
        public int CompTypeId { get; set; }
        public string TypeName { get; set; }
        public string MaterialsName { get; set; }
        public int MaterialsStock { get; set; }
        public int MaterialsQuantity { get; set; }
        public string MaterialsUnit { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public DateTime InputDate { get; set; }

    }
}
