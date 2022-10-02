using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class EmployeeUserRepository : IEmployeeUser
    {
        public IConfiguration _configuration;  //agar bisa baca object appsetting.json

        public EmployeeUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters(); //menggunakan orm dapper agar bisa query sql pada method. atau menggunakan store procedure.
        public EmployeeUserIDVM GetByEmployeeKey(int employeeKey)
        {

            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spGetEmployeeKeyUserIDNew";
                parameters.Add("@EmplKey", employeeKey);
                var employeeByKey = connection.QuerySingle<EmployeeUserIDVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return employeeByKey;
            }
        }
        public EmployeeCardDataVM GetByCardNo(string cardNo)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spGetCardNumberData";
                parameters.Add("@CardNumber", cardNo);
                var employeeByCard = connection.QuerySingle<EmployeeCardDataVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return employeeByCard;
            }
        }
    }
}
