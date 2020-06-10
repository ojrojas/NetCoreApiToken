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
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _service;
        public EmpleadosController(IEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ContarEmpleados")]
        public async Task<IActionResult> ContarEmpleados()
        {
            return new JsonResult(new { data = await _service.ContarEmpleados() });
        }

        [HttpPost]
        [Route("CrearEmpleado")]
        public async Task<IActionResult> CrearEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(
                new { data = await _service.CrearEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)) });
        }

        [HttpPost]
        [Route("ActualizarEmpleado")]
        public async Task<IActionResult> ActualizarEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(
                new { data = await _service.ActualizarEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)) });
        }

         [HttpPost]
        [Route("EliminarEmpleado")]
        public async Task<IActionResult> EliminarEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(
                new { data = await _service.EliminarEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)) });
        }

         [HttpPost]
        [Route("ObtenerEmpleado")]
        public async Task<IActionResult> ObtenerEmpleado(EmpleadoViewModel empleado)
        {
            return new JsonResult(
                new { data = await _service.ObtenerEmpleado(
                    empleado.EmpleadoViewModelToEmpleado(empleado)) });
        }


         [HttpPost]
        [Route("ObtenerEmpleados")]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            return new JsonResult(
                new { data = await _service.ObtenerEmpleados() });
        }
    }
}