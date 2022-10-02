using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class RefillRepository : IRefill
    {
        public IConfiguration _configuration;

        public RefillRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // DynamicParameters parameters = new DynamicParameters();

        public RefillVm Get(int CompTypeID)
        {
            DynamicParameters parameters = new DynamicParameters();
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spMaterialsFirstRowByCompType";
                parameters.Add("@CompTypeID", CompTypeID);

                var get = connection.QuerySingle<RefillVm>(procName, parameters, commandType: CommandType.StoredProcedure);
                return get;
            }
        }

        public int Decr(int MaterialsID)
        {
            DynamicParameters parameters = new DynamicParameters();
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spDecrMaterials";
                parameters.Add("@MaterialsID", MaterialsID);
                //parameters.Add("@MaterialsID", 2);
                var decr = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return decr;
            }
        }

        public int Refill(int CompTypeID, int Quantity)
        {
            DynamicParameters parameters = new DynamicParameters();
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spRefillCompositionType";
                parameters.Add("@CompTypeID", CompTypeID);
                parameters.Add("@Quantity", Quantity);

                var refill = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return refill;
            }
        }
    }
}
