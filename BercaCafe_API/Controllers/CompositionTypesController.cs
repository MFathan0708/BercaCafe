using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System;
using BercaCafe_API.ViewModels;
using APIDapper.Repositories.Interfaces;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionTypesController : ControllerBase
    {
        private readonly ICompositionType compositionTypeRepository;

        public CompositionTypesController(ICompositionType compositionTypeRepository)
        {
            this.compositionTypeRepository = compositionTypeRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {

            var rComp = compositionTypeRepository.Get();
            if (rComp.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan!", result = rComp });
            }
            else
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ada!", result = rComp });
            }
        }

        [HttpPost]

        public ActionResult Insert(CompositionTypeVm compositionTypeVm)
        {
            int Ins = 1;
            switch (Ins)
            {
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, Message = "Composisi Type Berhasil Ditambahkan!", result = compositionTypeRepository.Insert(compositionTypeVm) });
                case 2:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, Message = "Composisi Type Gagal Ditambahkan!", result = compositionTypeRepository.Insert(compositionTypeVm) });

                default:
                    return Ok();
            }
        }

        [HttpPut]

        public ActionResult Update(CompositionTypeVm compositionTypeVm)
        {
            var Upd = compositionTypeRepository.Update(compositionTypeVm);
            switch (Upd)
            {
                case 0:
                    return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Composisi Type Gagal Diperbaharui!", result = Upd });
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Composisi Type Berhasil Diperbaharui!", result = Upd });
                default:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, message = "Data Gagal Diperbaharui!", result = Upd });

            }
        }

        [HttpDelete]
        public ActionResult Delete(CompositionTypeVm compositionTypeVm)
        {
            var Del = compositionTypeRepository.Delete(compositionTypeVm);
            if (Del != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Composisi Type Berhasil Dihapus!", result = Del });
            }
            else
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Composisi Type Gagal Dihapus!", result = Del });
            }
        }

        [HttpGet("{CompTypeID}")]
        public ActionResult Get(int CompTypeID)
        {
            try
            {
                var Get = compositionTypeRepository.Get(CompTypeID);

                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Berhasil Ditemukan!", result = Get });
            }
            catch
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ada!" });
            }
        }

        [Route("substract")]
        [HttpPost]
        public ActionResult Substract(UpdateCompTypeVM compType)
        {
            var subtresult = compositionTypeRepository.SubstractCompositionType(compType);
            // return Ok(subtresult);
            switch (subtresult)
            {
                case 1:
                    return StatusCode(200, new
                    {
                        StatusCode = HttpStatusCode.OK,
                        message = "Berhasil mengurangi bahan"
                    });
                case -1:
                    return StatusCode(404, new
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        message = "Bahan tidak ditemukan"
                    });
                default:
                    return StatusCode(500, new
                    {
                        statusCode = HttpStatusCode.InternalServerError,
                        messsage = "Kesalahan server"
                    });
            }
        }
    }
}