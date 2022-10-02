using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class OrderRepository : IOrder
    {
        public IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        DynamicParameters parameters = new DynamicParameters();
        public int PlaceOrder(OrderTransactionVM orderTransaction)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spPlaceOrderNew";
                parameters.Add("@EmplKey", orderTransaction.employeeKey);
                parameters.Add("@UserID", orderTransaction.userID);
                parameters.Add("@MenuID", orderTransaction.menuID);
                parameters.Add("@CupID", orderTransaction.cupID);
                parameters.Add("@TypeMenu", orderTransaction.typeMenu);
                var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public OrderTransactionVM ComposeOrder (EmployeeCardDataVM employee, OrderVM order)
        {
            OrderTransactionVM transaction = new OrderTransactionVM();
            transaction.employeeKey = employee.EmployeeKey;
            transaction.userID = employee.UserID;
            transaction.menuID = order.menuID;
            transaction.cupID = order.cupID;
            transaction.typeMenu = order.typeMenu;
            return transaction;
        }
    }
}
