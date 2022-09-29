using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using BercaCafe_API.Models;

namespace BercaCafe_API.Repositories.Data
{
    public class StockRepository : IStock
    {
        public IConfiguration _configuration;  //agar bisa baca object appsetting.json

        public StockRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters(); //menggunakan orm dapper agar bisa query sql pada method. atau menggunakan store procedure.
        public int Insert(StockVM stockVM)
        //method insert ke table materials dan materials_log
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spInsertMaterialsAll";
                parameters.Add("@CompTypeID", stockVM.CompTypeID);
                parameters.Add("@MaterialsName", stockVM.MaterialsName);
                parameters.Add("@MaterialsStock", stockVM.MaterialsStock);
                parameters.Add("@MaterialsQuantity", stockVM.MaterialsQuantity);
                parameters.Add("@MaterialsUnit", stockVM.MaterialsUnit);
                parameters.Add("@Price", stockVM.Price);

                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public IEnumerable<StockTersediaVM> Get(DateTime fromDate, DateTime thruDate)
        //method get untuk spStockTersedia 
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spStockTersediaNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var stock = connection.Query<StockTersediaVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return stock;

            }
        }

        public IEnumerable<StockTersediaVM> GetTerpakai(DateTime fromDate, DateTime thruDate)
        //method get untuk spStockTersedia 
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spStockTerpakaiNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var stock = connection.Query<StockTersediaVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return stock;

            }
        }

        public IEnumerable<Mat_LogVM> GetMaterials()
        //method get untuk spGetMaterials_LogNew 
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spGetMaterialsNew";
                var getMaterial = connection.Query<Mat_LogVM>(spName, commandType: CommandType.StoredProcedure);
                return getMaterial;
            }
            //return context.MaterialsLogs.ToList();
        }


        public IEnumerable<CompositionType> GetCompType()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spGetAllDataCompositionTypeNew";
                var getComp = connection.Query<CompositionType>(spName, commandType: CommandType.StoredProcedure);
                return getComp;
            }
        }
    }
}
