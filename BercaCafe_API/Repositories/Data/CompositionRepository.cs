using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class CompositionRepository : IComposition
    {
        public IConfiguration _configuration;

        public CompositionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters();

        IEnumerable<CompositionVm> IComposition.Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var spName = "spGetAllDataCompositionNew";
                //var spName = "spGetDataComposition";
                var comp = connection.Query<CompositionVm>(spName, commandType: CommandType.StoredProcedure);
                return comp;

            }
        }


        public int Insert(CompositionVm compositionVm)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spInsertCompositionNew";
                parameters.Add("@MenuID", compositionVm.MenuID);
                parameters.Add("@CompTypeID", compositionVm.CompTypeID);
                parameters.Add("@Quantity", compositionVm.Quantity);
                parameters.Add("@MenuType", compositionVm.MenuType);

                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Update(CompositionVm compositionVm)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var procName = "spUpdateCompositionNew";
                parameters.Add("@CompID", compositionVm.CompID);
                parameters.Add("@Quantity", compositionVm.Quantity);

                var Update = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Update;
            }
        }
        
        public CompositionVm Get(int CompID)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var procName = "spGetAllDataCompositionByIDNew";
                parameters.Add("@CompId", CompID);

                var Get = connection.QuerySingle<CompositionVm>(procName, parameters, commandType: CommandType.StoredProcedure);
                return Get;
            }
        }

        public IEnumerable<CompositionVm> GetByMenu(int menuID, int menuType)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"])) //manggil object connection string dari file appsettings.json
            {
                var spName = "spGetAllDataCompositionByMenuNew";
                parameters.Add("@MenuID", menuID);
                parameters.Add("@MenuType", menuType);
                var menuComposition = connection.Query<CompositionVm>(spName, parameters, commandType: CommandType.StoredProcedure);
                return menuComposition;
            }
        }
    }
}

