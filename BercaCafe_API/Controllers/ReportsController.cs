using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System;
using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReport reportRepository;

        public ReportsController(IReport reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet("ReportMenu")]
        public ActionResult GetMenu(DateTime fromDate, DateTime thruDate)
        {

            var rMenu = reportRepository.Get(fromDate, thruDate);
            if (rMenu.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan!", result = reportRepository.Get(fromDate, thruDate) });
            }
            else
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ada!", result = reportRepository.Get(fromDate, thruDate) });
            }

        }

        [HttpGet("ReportEmployee")]
        public ActionResult GetByEmployee(
            DateTime fromDate,
            DateTime thruDate,
            string department,
            string employeeId
            )
        {

            var report = reportRepository.GetByEmployee(fromDate, thruDate, department, employeeId);
            if (report.Count() == 0)
            {
                return StatusCode(404, new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Tidak ada data"
                });
            }
            else
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = report.Count() + " DATA ADA",
                    result = report
                });
            }
        }

        [HttpGet("ReportCup")]
        public ActionResult Get(DateTime fromDate, DateTime thruDate)
        {
            var rCup = reportRepository.GetCup(fromDate, thruDate);

            if (rCup.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = rCup });
            }
            else
            {

                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = rCup });
            }
        }

        [HttpGet("DepartmentList")]
        public ActionResult GetDepartment()
        {
            var dept = reportRepository.GetAllDepartment();
            if (dept.Count() == 0)
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
                    message = dept.Count() + " data found",
                    result = dept
                });
            }
        }
    }
}
