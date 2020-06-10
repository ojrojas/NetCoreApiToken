using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<EmpleadoViewModel> CrearEmpleadoAsync(Empleado empleado);
        Task<int> ActualizarEmpleadoAsync(Empleado empleado);
        Task<int> EliminarEmpleadoAsync(Empleado empleado);
        Task<EmpleadoViewModel> ObtenerEmpleadoAsync(Empleado empleado);
        Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleadosAsync();
        Task<int> ContarEmpleadosAsync();
    }
}