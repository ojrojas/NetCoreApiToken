using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;
using RappiApi.Services.Interfaces;

namespace RappiApi.Controllers
{
    /// <summary>
    /// EmpledosController, servicio que expone los endpoint para empleados
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        /// <summary>
        /// Interface que expone los metodos del servicio EmpleadoService
        /// </summary>
        /// <seealso cref="EmpleadoService"/>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly IEmpleadoService _service;
        public EmpleadosController(IEmpleadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// ContarEmpleados
        /// </summary>
        /// <returns>La cantidad de empleados existentes</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpGet]
        [Route("ContarEmpleados")]
        public async Task<IActionResult> ContarEmpleados()
        {
            return new JsonResult(await _service.ContarEmpleados());
        }

        /// <summary>
        /// BuscarEmpleados
        /// </summary>
        /// <param name="filtro">Busca los empleados por un filtro que
        /// comprende entre identificacion, nombre y apellido</param>
        /// <returns>Lista vista de modelo de empleados</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpGet]
        [Route("BuscarEmpleados")]
        public async Task<IActionResult> BuscarEmpleados(string filtro)
        {
            return new JsonResult(await _service.BuscarEmpleados(filtro));
        }

        /// <summary>
        /// CrearEmpleado
        /// </summary>
        /// <param name="empleado">Vista de modelo de entrada para la creacion de empleados</param>
        /// <returns>Vista del modelo que se creo en la base de datos</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("CrearEmpleado")]
        public async Task<IActionResult> CrearEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(await _service.CrearEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)));
        }

        /// <summary>
        /// ActualizarEmpleado
        /// </summary>
        /// <param name="empleado">Vista de modelo de entrada para actualizar empleados</param>
        /// <returns>Vista de modelo del empleado creado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ActualizarEmpleado")]
        public async Task<IActionResult> ActualizarEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(await _service.ActualizarEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)));
        }

        /// <summary>
        /// EliminarEmpleado
        /// </summary>
        /// <param name="empleado">Vista modelo para eliminacion de empleados</param>
        /// <returns>Vista modelo del empleado eliminado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("EliminarEmpleado")]
        public async Task<IActionResult> EliminarEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(await _service.EliminarEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)));
        }

        /// <summary>
        /// ObtenerEmpleado
        /// </summary>
        /// <param name="empleado">Vista modelo del empleado solicitado</param>
        /// <returns>Vista del modelo petido</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerEmpleado")]
        public async Task<IActionResult> ObtenerEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(await _service.ObtenerEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)));
        }

        /// <summary>
        /// ObtenerEmpleados
        /// </summary>
        /// <param name="paginacion">Modelo de paginacion empleados</param>
        /// <returns>Lista de vistas de modelo solicitadas segundo la paginacion que envio</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [HttpPost]
        [Route("ObtenerEmpleados")]
        public async Task<IActionResult> ObtenerEmpleados(PaginacionViewModel paginacion)
        {
            return new JsonResult(await _service.ObtenerEmpleados(paginacion));
        }
    }
}