using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<EmpleadoViewModel> CrearEmpleado(Empleado empleado);
        Task<int> ActualizarEmpleado(Empleado empleado);
        Task<int> EliminarEmpleado(Empleado empleado);
        Task<EmpleadoViewModel> ObtenerEmpleado(Empleado empleado);
        Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleados();
        Task<int> ContarEmpleados();
    }
}