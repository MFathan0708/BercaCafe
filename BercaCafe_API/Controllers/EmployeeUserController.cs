using APIDapper.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeUserController : ControllerBase
    {
        private readonly IEmployeeUser employeeUserRepository;

        public EmployeeUserController(IEmployeeUser repository)
        {
            this.employeeUserRepository = repository;
        }

        [Route("getByEmployeeKey")]
        [HttpGet]
        public ActionResult GetByEmployee(int employeeKey)
        {
            try
            {
                var employee = employeeUserRepository.GetByEmployeeKey(employeeKey);
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data ada",
                    result = employee
                });
            }
            catch
            {
                return StatusCode(404, new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Data tidak ditemukan"
                });
            }
        }

        [Route("getByCard")]
        [HttpGet]
        public ActionResult GetByCard(string cardNo)
        {
            try
            {
                var employee = employeeUserRepository.GetByCardNo(cardNo);
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data ada",
                    result = employee
                });
            }
            catch
            {
                return StatusCode(404, new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Data tidak ditemukan"
                });
            }
        }
    }
}
