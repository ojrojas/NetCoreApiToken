using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _service;
        public AreasController(IAreaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ContarAreas")]
        public async Task<IActionResult> ContarAreas()
        {
            return new JsonResult(await _service.ContarAreas() );
        }

        [HttpPost]
        [Route("CrearArea")]
        public async Task<IActionResult> CrearArea(AreaViewModel area)
        {
            return new JsonResult(
               await _service.CrearArea(area) );
        }

        [HttpPost]
        [Route("ActualizarArea")]
        public async Task<IActionResult> ActualizarArea(AreaViewModel area)
        {
            return new JsonResult(
              await _service.ActualizarArea(area) );
        }

        [HttpPost]
        [Route("EliminarArea")]
        public async Task<IActionResult> EliminarArea(AreaViewModel area)
        {
            return new JsonResult(
               await _service.EliminarArea(area) );
        }

         [HttpPost]
        [Route("ObtenerArea")]
        public async Task<IActionResult> ObtenerArea(AreaViewModel area)
        {
            return new JsonResult(
                await _service.ObtenerArea(area) );
        }


        [HttpPost]
        [Route("ObtenerAreas")]
        public async Task<IActionResult> ObtenerAreas(PaginacionViewModel paginacion)
        {
            return  new JsonResult( await _service.ObtenerAreas(paginacion));
        }
    }
}