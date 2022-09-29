using BercaCafe_API.ViewModels;
using System.Collections.Generic;

namespace APIDapper.Repositories.Interfaces
{
    public interface IMenu
    {

        IEnumerable<MenuVM> GetAllMenus();
        MenuVM GetMenuById(int id);
    }
}
