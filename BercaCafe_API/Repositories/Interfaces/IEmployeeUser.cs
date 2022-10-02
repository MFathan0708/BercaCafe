using BercaCafe_API.ViewModels;

namespace APIDapper.Repositories.Interfaces
{
    public interface IEmployeeUser
    {
        EmployeeUserIDVM GetByEmployeeKey(int employeeKey);
        EmployeeCardDataVM GetByCardNo(string cardNo);
    }
}
