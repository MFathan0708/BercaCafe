using APIDapper.Models;
using BercaCafe_API.ViewModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;

namespace APIDapper.Repositories.Interfaces
{
    public interface IReport
    {
        IEnumerable<ReportByMenuVM> Get(DateTime fromDate, DateTime thruDate);
        IEnumerable<ReportEmployeeVM> GetByEmployee(
            DateTime fromDate,
            DateTime thruDate,
            string department,
            string employeeId
            );

    }
}
