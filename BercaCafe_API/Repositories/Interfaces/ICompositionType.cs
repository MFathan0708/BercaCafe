using BercaCafe_API.ViewModels;
using System.Collections.Generic;

namespace APIDapper.Repositories.Interfaces
{
    public interface ICompositionType
    {
        IEnumerable<CompositionTypeVm> Get();
        CompositionTypeVm Get(int CompTypeID);
        int Insert(CompositionTypeVm compositionTypeVm);
        int Update(CompositionTypeVm compositionTypeVm);
        int Delete(CompositionTypeVm compositionTypeVm);
        public int SubstractCompositionType(UpdateCompTypeVM compType);
    }
}
