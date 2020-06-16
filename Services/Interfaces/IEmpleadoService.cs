using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    /// <summary>
    /// Interface, que expone los metodos de EmpleadoService
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>06/09/2020</date>
    public interface IEmpleadoService
    {
        /// <summary>
        /// CrearEmpleado
        /// </summary>
        /// <param name="empleado">Entidad entrada para crear empleado</param>
        /// <returns>Vista modelo del empleado creado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<EmpleadoViewModel> CrearEmpleado(Empleado empleado);

        /// <summary>
        /// ActualizarEmpleado
        /// </summary>
        /// <param name="empleado">Entidad entrada para crear empleado</param>
        /// <returns>Entro que notifica si se actualizo o no el registro </returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<int> ActualizarEmpleado(Empleado empleado);

        /// <summary>
        /// EliminarEmpleado
        /// </summary>
        /// <param name="empleado">Entidad entrada para crear empleado</param>
        /// <returns>Entro que notifica si se elimino o no el registro </returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<int> EliminarEmpleado(Empleado empleado);

         /// <summary>
        /// ObtenerEmpleado
        /// </summary>
        /// <param name="empleado">Entidad entrada para crear empleado</param>
        /// <returns>Lista vista modelo de empleados</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<EmpleadoViewModel> ObtenerEmpleado(Empleado empleado);

          /// <summary>
        /// ObtenerEmpleados
        /// </summary>
        /// <param name="paginacion">Entidad entrada la paginacion</param>
        /// <returns>Lista vista modelo del empleado solicitado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleados(PaginacionViewModel paginacion);

          /// <summary>
        /// ContarEmpleados
        /// </summary>
        /// <returns>Catnidad de registro existentes</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<int> ContarEmpleados();

        /// <summary>
        /// ObtenerEmpleado
        /// </summary>
        /// <param name="filtro">Filtro busqueda de registro</param>
        /// <returns>Lista vista modelo de empleados</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>06/09/2020</date>
        Task<IReadOnlyList<EmpleadoViewModel>> BuscarEmpleados(string filtro);
    }
}