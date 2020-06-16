using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    /// <summary>
    /// IEmpleadoRepository, interface declareacion de metodos EmpleadoRepository
    /// </summary>
    /// <autor>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public interface IEmpleadoRepository
    {
        /// <summary>
        /// CrearEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Vista modelo EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<EmpleadoViewModel> CrearEmpleadoAsync(Empleado empleado);

        /// <summary>
        /// ActualizarEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Entero notifica si se actualizo o no el empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ActualizarEmpleadoAsync(Empleado empleado);

        /// <summary>
        /// EliminarEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Entero notifica si se actualizo o no el empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> EliminarEmpleadoAsync(Empleado empleado);

        /// <summary>
        /// ObtenerEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Vista modelo empleado solicitado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<EmpleadoViewModel> ObtenerEmpleadoAsync(Empleado empleado);

        /// <summary>
        /// ObtenerEmpleadosAsync
        /// </summary>
        /// <param name="paginacion">Entidad de paginacion</param>
        /// <returns>Lista de vistas modelo EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleadosAsync(PaginacionViewModel paginacion);

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <returns>Entero, cantidad de registro existente de empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ContarEmpleadosAsync();

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="filtro">Filtro para busqueda en base datos de empleados</param>
        /// <returns>Lista vista modelos EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<EmpleadoViewModel>> BuscarEmpleados(string filtro);
    }
}