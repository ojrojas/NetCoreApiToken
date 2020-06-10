using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Repository.Interfaces;
using RappiApi.Services.Interfaces;

namespace RappiApi.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        public EmpleadoService(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public Task<int> ActualizarEmpleado(Empleado empleado)
        {
           return _repository.ActualizarEmpleadoAsync(empleado);
        }

        public Task<int> ContarEmpleados()
        {
            return _repository.ContarEmpleadosAsync();
        }

        public Task<EmpleadoViewModel> CrearEmpleado(Empleado empleado)
        {
            return _repository.CrearEmpleadoAsync(empleado);
        }

        public Task<int> EliminarEmpleado(Empleado empleado)
        {
            return _repository.EliminarEmpleadoAsync(empleado);
        }

        public Task<EmpleadoViewModel> ObtenerEmpleado(Empleado empleado)
        {
            return _repository.ObtenerEmpleadoAsync(empleado);
        }

        public Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleados()
        {
            return _repository.ObtenerEmpleadosAsync();
        }
    }
}