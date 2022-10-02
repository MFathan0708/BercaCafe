using BercaCafe_API.ViewModels;

namespace APIDapper.Repositories.Interfaces
{
    public interface IRefill
    {
        RefillVm Get(int CompTypeID);
        int Decr(int MaterialsID);
        int Refill(int CompTypeID, int Quantity);
    }
}
