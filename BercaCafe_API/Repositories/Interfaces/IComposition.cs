using BercaCafe_API.ViewModels;
using System.Collections.Generic;

namespace APIDapper.Repositories.Interfaces
{
    public interface IComposition
    {
        IEnumerable<CompositionVm> Get();
        CompositionVm Get(int CompID);
        int Insert(CompositionVm compositionVm);
        int Update(CompositionVm compositionVm);
        IEnumerable<CompositionVm> GetByMenu(int menuID, int menuType);
    }
}
