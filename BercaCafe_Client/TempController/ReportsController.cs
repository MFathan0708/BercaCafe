using Microsoft.AspNetCore.Mvc;

namespace BercaCafe_Client.TempController
{
    public class ReportsController : Controller
    {
        public IActionResult MenuReport()
        {
            return View();
        }

        public IActionResult EmployeeReport()
        {
            return View();
        }

        public IActionResult CupReport()
        {
            return View();
        }

        public IActionResult DivisionReport()
        {
            return View();
        }
    }
}
