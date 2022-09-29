using APIDapper.Models;
using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace APIDapper.Repositories
{
    public class ReportRepository : IReport
    {
        public IConfiguration _configuration;  //agar bisa baca object appsetting.json

        public ReportRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters(); //menggunakan orm dapper agar bisa query sql pada method. atau menggunakan store procedure.

        public IEnumerable<ReportByMenuVM> Get(DateTime fromDate, DateTime thruDate)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json 
            {
                var spName = "spReportSummaryMenu";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var Menu = connection.Query<ReportByMenuVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return Menu;
            }
        }

        public IEnumerable<ReportEmployeeVM> GetByEmployee(
            DateTime fromDate,
            DateTime thruDate,
            string department,
            string employeeId
            )
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spReportAbsenceNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                parameters.Add("@VendorID", "7");
                parameters.Add("@Dept", department);
                parameters.Add("@Empl", employeeId);
                var absen = connection.Query<ReportEmployeeVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return absen;
            }
        }
        public IEnumerable<string> GetAllDepartment()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spDeptListNew";
                var dept = connection.Query<string>(spName, commandType: CommandType.StoredProcedure);
                return dept;
            }
        }

        public IEnumerable<ReportByCupVM> GetCup(DateTime fromDate, DateTime thruDate)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spReportSummaryCupNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var cup = connection.Query<ReportByCupVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return cup;

            }
        }

        public IEnumerable<ReportByCupVM> GetCupByDivision(DateTime fromDate, DateTime thruDate)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spReportSummaryCupByDivision";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var cup = connection.Query<ReportByCupVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return cup;

            }
        }

        public IEnumerable<ReportDivisiVM> GetByDivisi(DateTime fromDate, DateTime thruDate)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spReportAbsenceByDivisiNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var absen = connection.Query<ReportDivisiVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return absen;
            }
        }
    }
}
