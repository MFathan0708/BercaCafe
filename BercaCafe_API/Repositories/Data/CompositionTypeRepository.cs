using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class CompositionTypeRepository : ICompositionType
    {
        public IConfiguration _configuration;  //agar bisa baca object appsetting.json

        public CompositionTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters(); //menggunakan orm dapper agar bisa query sql pada method. atau menggunakan store procedure.
        IEnumerable<CompositionTypeVm> ICompositionType.Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var spName = "spGetAllDataCompositionTypeNew";
                var comp = connection.Query<CompositionTypeVm>(spName, commandType: CommandType.StoredProcedure);
                return comp;

            }
        }


        public int Insert(CompositionTypeVm compositionTypeVm)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spInsertCompositionTypeNew";
                parameters.Add("@TypeName", compositionTypeVm.TypeName);
                parameters.Add("@TypeQuantity", compositionTypeVm.TypeQuantity);

                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Update(CompositionTypeVm compositionTypeVm)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spUpdateCompositionTypeNew";
                parameters.Add("@CompTypeID", compositionTypeVm.CompTypeID);
                parameters.Add("@TypeQuantity", compositionTypeVm.TypeQuantity);

                var Update = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Update;
            }
        }
        public int Delete(CompositionTypeVm compositionTypeVm)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spDeleteCompositionTypeNew";
                parameters.Add("@CompTypeId", compositionTypeVm.CompTypeID);

                var Delete = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Delete;
            }
        }

        public CompositionTypeVm Get(int CompTypeID)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var procName = "spGetAllDataCompositionTypeByIDNew";
                parameters.Add("@CompTypeId", CompTypeID);

                var Get = connection.QuerySingle<CompositionTypeVm>(procName, parameters, commandType: CommandType.StoredProcedure);
                return Get;
            }
        }

        public int SubstractCompositionType(UpdateCompTypeVM compType)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var spName = "spSubstractCompTypeNew";
                parameters.Add("@CompTypeID", compType.CompTypeID);
                parameters.Add("@Quantity", compType.Quantity);
                parameters.Add("Result");
                int subtresult = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return subtresult;
            }
        }
    }
}
