using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using BercaCafe_API.ViewModels;
using APIDapper.Repositories.Interfaces;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefillsController : ControllerBase
    {
        private readonly IRefill refillRepository;

        public RefillsController(IRefill refillRepository)
        {
            this.refillRepository = refillRepository;
        }

        [Route("RefillFirst")]
        [HttpGet("RefillFirst/{CompTypeID}")]
        public ActionResult Get(int CompTypeID)
        {
            try
            {
                var Get = refillRepository.Get(CompTypeID);

                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Berhasil Ditemukan!", result = Get });
            }
            catch (Exception)
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ada!" });
            }
        }

        [Route("DecreStock")]
        [HttpPost]
        public ActionResult Decr(int MaterialsID)
        {
            var Decr = refillRepository.Decr(MaterialsID);
            switch (Decr)
            {
                case 0:
                    return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Stock Materials Gagal Diperbaharui!", result = Decr });
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Stock Materials Berhasil Diperbaharui!", result = Decr });
                default:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, message = "Data Gagal Diperbaharui!", result = Decr });

            }
        }
        [Route("RefillComposition")]
        [HttpPost]
        public ActionResult Refill(int CompTypeID, int Quantity)
        {
            var Refiil = refillRepository.Refill(CompTypeID, Quantity);
            switch (Refiil)
            {
                case 0:
                    return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Quantity Composition Type Gagal Diperbaharui!", result = Refiil });
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Quantity Composition Type Berhasil Diperbaharui!", result = Refiil });
                default:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, message = "Data Gagal Diperbaharui!", result = Refiil });

            }
        }

        [Route("menu")]
        [HttpPost]
        public ActionResult RefillFull(int CompTypeID)
        {
            try
            {
                RefillVm refillMaterial = new RefillVm();
                refillMaterial = refillRepository.Get(CompTypeID);

                refillRepository.Decr(refillMaterial.MaterialsID);
                refillRepository.Refill(refillMaterial.CompTypeID, refillMaterial.MaterialsQuantity);
                return StatusCode(200, new
                {
                    StatusCode = HttpStatusCode.OK,
                    message = "Composition Type Refilled Successfully",
                    result = refillMaterial
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    message = "Stock in warehouse runs out",
                    exception = ex.Message

                });
            }
        }
    }
}
