using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    /// <summary>
    /// IAreaRepository, interface declareacion de metodos AreRepository
    /// </summary>
    /// <autor>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public interface IAreaRepository
    {
        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<AreaViewModel> CrearAreaAsync(Area Area);

        /// <summary>
        /// ActualizarAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ActualizarAreaAsync(Area Area);

        /// <summary>
        /// EliminarAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> EliminarAreaAsync(Area Area);

        /// <summary>
        /// ObtenerAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<AreaViewModel> ObtenerAreaAsync(Area Area);

        /// <summary>
        /// ObtenerAreasAsync
        /// </summary>
        /// <param name="PaginacionViewModel">Entidad PaginacionViewModel</param>
        /// <returns>Lista vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<AreaViewModel>> ObtenerAreasAsync(PaginacionViewModel paginacion);

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Cantidad existente en base de datos</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ContarAreasAsync();
    }
}