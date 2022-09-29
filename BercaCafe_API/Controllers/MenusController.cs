using APIDapper.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenu menuRepository;

        public MenusController(IMenu menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        [HttpGet]
        public ActionResult GetAllMenus()
        {
            var menu = menuRepository.GetAllMenus();
            if (menu.Count() == 0)
            {
                return StatusCode(404, new
                {
                    status = HttpStatusCode.NotFound,
                    message = "No data"
                });
            }
            else
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = menu.Count() + " data found",
                    result = menu
                });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetMenuById(int id)
        {
            try
            {
                var menuSingle = menuRepository.GetMenuById(id);
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data found",
                    result = menuSingle
                });
            }
            catch
            {
                return StatusCode(404, new
                {
                    status = HttpStatusCode.NotFound,
                    message = "No data"
                });

            }
        }
    }
}
