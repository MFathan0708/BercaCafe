using BercaCafe_API.ViewModels;
using System.Collections.Generic;
using System;
using BercaCafe_API.Models;

namespace APIDapper.Repositories.Interfaces
{
    public interface IStock
    {
        int Insert(StockVM stockVM);
        IEnumerable<StockTersediaVM> Get(DateTime fromDate, DateTime thruDate);
        IEnumerable<StockTersediaVM> GetTerpakai(DateTime fromDate, DateTime thruDate);
        IEnumerable<Mat_LogVM> GetMaterials();
        IEnumerable<CompositionType> GetCompType();
    }
}
