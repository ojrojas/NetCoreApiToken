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
    public class SubAreasController : ControllerBase
    {
        private readonly ISubAreaService _service;
        public SubAreasController(ISubAreaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ContarSubAreas")]
        public async Task<IActionResult> ContarSubAreas()
        {
            return new JsonResult(new { data = await _service.ContarSubAreas() });
        }

        [HttpPost]
        [Route("CrearSubArea")]
        public async Task<IActionResult> CrearSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
                new { data = await _service.CrearSubArea(
                    subArea.SubAreaViewModelToSubArea(subArea)) });
        }

        [HttpPost]
        [Route("ActualizarSubArea")]
        public async Task<IActionResult> ActualizarSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
                new { data = await _service.ActualizarSubArea(
                    subArea.SubAreaViewModelToSubArea(subArea)) });
        }

         [HttpPost]
        [Route("EliminarSubArea")]
        public async Task<IActionResult> EliminarSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
                new { data = await _service.EliminarSubArea(
                    subArea.SubAreaViewModelToSubArea(subArea)) });
        }

         [HttpPost]
        [Route("ObtenerSubArea")]
        public async Task<IActionResult> ObtenerSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
                new { data = await _service.ObtenerSubArea(
                    subArea.SubAreaViewModelToSubArea(subArea)) });
        }


         [HttpPost]
        [Route("ObtenerSubAreas")]
        public async Task<IActionResult> ObtenerSubAreas()
        {
            return new JsonResult(
                new { data = await _service.ObtenerSubAreas() });
        }
    }
}