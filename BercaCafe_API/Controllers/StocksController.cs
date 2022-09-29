using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStock stockRepository;

        public StocksController(IStock stockRepository)
        {
            this.stockRepository = stockRepository;
        }
        [Route("AddMaterialsAll")]
        [HttpPost]
        //method post ke table materials dan materials_log
        public ActionResult Insert(StockVM stockVM)
        {
            var materialOk = stockRepository.Insert(stockVM);
            switch (materialOk)
            {
                case 0:
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Data Tidak Berhasil Ditambah ", result = materialOk });
                case 2:
                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Ditambahkan ", result = materialOk });
                //case 404:
                //    return StatusCode(404, new { status = HttpStatusCode.BadRequest, message = "Account Tidak Ditemukan ", result = loginOK });
                default:
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Tidak Sesuai ", result = materialOk });

            }
        }

        [Route("StockTersedia")]
        [HttpGet]
        // get untuk repo tersedia
        public ActionResult Get(DateTime fromDate, DateTime thruDate)
        {
            var stockavai = stockRepository.Get(fromDate, thruDate);

            if (stockavai.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = stockavai });
            }
            else
            {

                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = stockavai });
            }
        }

        [Route("StockTerpakai")]
        [HttpGet]
        // get untuk repo terpakai
        public ActionResult GetTerpakai(DateTime fromDate, DateTime thruDate)
        {
            var stockuse = stockRepository.GetTerpakai(fromDate, thruDate);

            if (stockuse.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = stockuse });
            }
            else
            {

                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = stockuse });
            }
        }

        [Route("MaterialsLog")]
        [HttpGet]
        // get untuk repo tersedia
        public ActionResult GetMaterials()
        {
            var matlog = stockRepository.GetMaterials();

            if (matlog.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = matlog });
            }
            else
            {

                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = matlog });
            }
        }

        [Route("CompTypeAll")]
        [HttpGet]
        // get untuk repo tersedia
        public ActionResult GetCompType()
        {
            var comptype = stockRepository.GetCompType();

            if (comptype.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = comptype });
            }
            else
            {

                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = comptype });
            }
        }
    }
}
