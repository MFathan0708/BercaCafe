using BercaCafe_API.ViewModels;

namespace APIDapper.Repositories.Interfaces
{
    public interface IOrder
    {
        int PlaceOrder(OrderTransactionVM orderTransaction);
        OrderTransactionVM ComposeOrder(EmployeeCardDataVM employee, OrderVM order);
    }
}
