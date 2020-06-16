using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    /// <summary>
    /// ISubAreaRepository, interface declareacion de metodos SubAreaRepository
    /// </summary>
    /// <autor>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public interface ISubAreaRepository
    {

        /// <summary>
        /// CrearSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<SubAreaViewModel> CrearSubAreaAsync(SubArea SubArea);

        /// <summary>
        /// ActualizarSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ActualizarSubAreaAsync(SubArea SubArea);

        /// <summary>
        /// EliminarSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> EliminarSubAreaAsync(SubArea SubArea);

        /// <summary>
        /// ObtenerSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<SubAreaViewModel> ObtenerSubAreaAsync(SubArea SubArea);

        /// <summary>
        /// ObtenerSubAreasAsync
        /// </summary>
        /// <param name="PaginacionViewModel">Entidad PaginacionViewModel</param>
        /// <returns>Lista vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasAsync(PaginacionViewModel paginacion);

        /// <summary>
        /// ObtenerSubAreasByAreaIdAsync
        /// </summary>
        /// <param name="Area">Modelo vista AreaViewModel</param>
        /// <returns>Lista vista modelos de SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasByAreaIdAsync(AreaViewModel area);

        /// <summary>
        /// ContarSubAreasAsync
        /// </summary>
        /// <returns>Cantidad existente en base de datos</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ContarSubAreasAsync();
    }
}