using BercaCafe_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System;
using APIDapper.Repositories.Interfaces;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionsController : ControllerBase
    {
        private readonly IComposition compositionRepository;

        public CompositionsController(IComposition compositionRepository)
        {
            this.compositionRepository = compositionRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {

            var rComp = compositionRepository.Get();
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

        public ActionResult Insert(CompositionVm compositionVm)
        {
            int Ins = 1;
            switch (Ins)
            {
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, Message = "Composisi Berhasil Ditambahkan!", result = compositionRepository.Insert(compositionVm) });
                case 2:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, Message = "Composisi Gagal Ditambahkan!", result = compositionRepository.Insert(compositionVm) });

                default:
                    return Ok();
            }
        }

        [HttpPut]

        public ActionResult Update(CompositionVm compositionVm)
        {
            var Upd = compositionRepository.Update(compositionVm);
            switch (Upd)
            {
                case 0:
                    return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Gagal Diperbaharui!", result = Upd });
                case 1:
                    return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Berhasil Diperbaharui!", result = Upd });
                default:
                    return StatusCode(400, new { StatusCode = HttpStatusCode.BadRequest, message = "Data Gagal Diperbaharui!", result = Upd });

            }
        }
        
        [HttpGet("{CompID}")]
        public ActionResult Get(int CompID)
        {
            try
            {
                var Get = compositionRepository.Get(CompID);

                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Berhasil Ditemukan!", result = Get});
            }
            catch (Exception)
            {
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ada!" });
            }
        }

        [Route("menu/{menuID}")]
        [HttpGet("menu/{menuID}")]
        public ActionResult GetByMenu(int menuID)
        {
            var menuComposition = compositionRepository.GetByMenu(menuID);
            if(menuComposition.Count() != 0)
            {
                return StatusCode(200, new
                {
                    StatusCode = HttpStatusCode.OK,
                    message = menuComposition.Count() + " data found",
                    result = menuComposition
                    //result = updateComps
                });
            }
            else
            {
                return StatusCode(404, new 
                { 
                    StatusCode = HttpStatusCode.NotFound,
                    message = "No Composition"
                });
            }
        }
    }
}
    