using Microsoft.AspNetCore.Mvc;

namespace BercaCafe_Client.TempController
{
    public class StocksController : Controller
    {
        public IActionResult MaterialsLog()
        {
            return View();
        }
    }
}
