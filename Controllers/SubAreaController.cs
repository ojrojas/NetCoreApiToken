using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Controllers
{
    /// <summary>
    /// SubAreasController
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class SubAreasController : ControllerBase
    {
        /// <summary>
        /// Interface que expone los metodos del servicio SubAreas
        /// </summary>
        /// <seealso cref="SubAreaService"/>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly ISubAreaService _service;
        public SubAreasController(ISubAreaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ContarSubAreas
        /// </summary>
        /// <returns>Entero que informa la cantidad de subareas 
        /// existentes en base de datos.</returns>
        ///  <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpGet]
        [Route("ContarSubAreas")]
        public async Task<IActionResult> ContarSubAreas()
        {
            return new JsonResult(await _service.ContarSubAreas());
        }

        /// <summary>
        /// CrearSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada para crear subareas</param>
        /// <returns>Vista modelo creado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("CrearSubArea")]
        public async Task<IActionResult> CrearSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
                await _service.CrearSubArea(subArea));
        }

        /// <summary>
        /// ActualizarSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada para 
        /// la actualizar de subareas</param>
        /// <returns>Vista modelo actualizado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ActualizarSubArea")]
        public async Task<IActionResult> ActualizarSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
               await _service.ActualizarSubArea(subArea));
        }

        /// <summary>
        /// EliminarSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada 
        /// para la eliminacion de areas</param>
        /// <returns>Vista modelo del subarea eliminado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("EliminarSubArea")]
        public async Task<IActionResult> EliminarSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
               await _service.EliminarSubArea(subArea));
        }

        /// <summary>
        /// OBtenerSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo de la subarea solictada</param>
        /// <returns>Vista de modelo solicitada</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerSubArea")]
        public async Task<IActionResult> ObtenerSubArea(SubAreaViewModel subArea)
        {
            return new JsonResult(
              await _service.ObtenerSubArea(subArea));
        }

        /// <summary>
        /// ObtenerSubAreas
        /// </summary>
        /// <param name="paginacion">Vista modelo paginacion 
        /// cantidad de registro solicitados</param>
        /// <returns>Lista de vista de modelo de subareas</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerSubAreas")]
        public async Task<IActionResult> ObtenerSubAreas(PaginacionViewModel paginacion)
        {
            return new JsonResult(await _service.ObtenerSubAreas(paginacion));
        }

        /// <summary>
        /// ObtenerSubAreasByAreaId
        /// </summary>
        /// <param name="area"></param>
        /// <returns>Devuelve la lista de subareas asociadas a un areaId</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerSubAreasByAreaId")]
        public async Task<IActionResult> ObtenerSubAreasByAreaId(AreaViewModel area)
        {
            return new JsonResult(await _service.ObtenerSubAreasByAreaId(area));
        }
    }
}