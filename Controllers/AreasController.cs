using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Controllers
{
    /// <summary>
    /// AreasController servicio que expone los endpoint de areas
    /// </summary>
    /// <author>Oscar Julian Rojas.</author>
    /// <date>09/06/2020</date>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        /// <summary>
        /// Interface que expone los metodos del servicio Area
        /// </summary>
        /// <seealso cref="AreaService"/>
        /// <author>Oscar Julian Rojas.</author>
        /// <date>09/06/2020</date>
        private readonly IAreaService _service;
        public AreasController(IAreaService service)
        {
            _service = service;
        }

        /// <summary>
        /// ContarAreas
        /// </summary>
        /// <returns>Entero con la cantidad de areas</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpGet]
        [Route("ContarAreas")]
        public async Task<IActionResult> ContarAreas()
        {
            return new JsonResult(await _service.ContarAreas());
        }

        /// <summary>
        /// CrearArea
        /// </summary>
        /// <param name="areaViewModel">Modelo de entrada para crear areas</param>
        /// <returns>Vista de modelo del area creada</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("CrearArea")]
        public async Task<IActionResult> CrearArea(AreaViewModel areaViewModel)
        {
            return new JsonResult(
               await _service.CrearArea(areaViewModel));
        }

        /// <summary>
        /// ActualizarArea
        /// </summary>
        /// <param name="areaViewModel">Modelo de entrada para actualizar areas</param>
        /// <returns>Entero que define si se actualizo o no el area</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ActualizarArea")]
        public async Task<IActionResult> ActualizarArea(AreaViewModel areaViewModel)
        {
            return new JsonResult(
              await _service.ActualizarArea(areaViewModel));
        }

        /// <summary>
        /// EliminarArea
        /// </summary>
        /// <param name="areaViewModel">Modelo de entrada para eliminar areas</param>
        /// <returns>Entero que define si se elimino o no el area</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("EliminarArea")]
        public async Task<IActionResult> EliminarArea(AreaViewModel areaViewModel)
        {
            return new JsonResult(
               await _service.EliminarArea(areaViewModel));
        }

        /// <summary>
        /// ObtenerArea
        /// </summary>
        /// <param name="areaViewModel">Modelo de entrada para obtener area</param>
        /// <returns>Vista del modelo de un area</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerArea")]
        public async Task<IActionResult> ObtenerArea(AreaViewModel area)
        {
            return new JsonResult(
                await _service.ObtenerArea(area));
        }

        /// <summary>
        /// ObtenerAreas
        /// </summary>
        /// <param name="paginacion">Datos entreda para obtener 
        /// la posicion y cantidad de datos para paginar
        /// </param>
        /// <returns>Lista de vistas del modelo de un area</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerAreas")]
        public async Task<IActionResult> ObtenerAreas(PaginacionViewModel paginacion)
        {
            return new JsonResult(await _service.ObtenerAreas(paginacion));
        }
    }
}