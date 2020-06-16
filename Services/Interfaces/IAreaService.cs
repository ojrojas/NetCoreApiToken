using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    /// <summary>
    /// IAreaService, Interface que expone los metodos del servicio AreaService
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>09/06/2020</date>
    public interface IAreaService
    {
        /// <summary>
        /// CrearArea
        /// </summary>
        /// <param name="areaViewModel">Vista modelo entrada para crear areas</param>
        /// <returns>Vista modelo de la area creada</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<AreaViewModel> CrearArea(AreaViewModel areaViewModel);

        /// <summary>
        /// ActualizarArea
        /// </summary>
        /// <param name="areaViewModel">Vista modelo entrada para actualizar registro</param>
        /// <returns>Entro que notifica si se actualizo o no el registro</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<int> ActualizarArea(AreaViewModel areaViewModel);

        /// <summary>
        /// EliminarArea
        /// </summary>
        /// <param name="areaViewModel">Vista modelo entrada para eliominar registro</param>
        /// <returns>Entro que notifica si se elimino o no el registro</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<int> EliminarArea(AreaViewModel areaViewModel);

        /// <summary>
        /// ObtenerArea
        /// </summary>
        /// <param name="areaViewModel">Vista modelo entrada para crear areas</param>
        /// <returns>Vista modelo del area solicitada</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<AreaViewModel> ObtenerArea(AreaViewModel areaViewModel);

        /// <summary>
        /// ObtenerAreas
        /// </summary>
        /// <param name="paginacion">Paginacion solicitada</param>
        /// <returns>Lista vista modelo del area</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<AreaViewModel>> ObtenerAreas(PaginacionViewModel paginacion = null);

        /// <summary>
        /// ContarAreas
        /// </summary>
        /// <returns>Lista vista modelo del area</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        Task<int> ContarAreas();
    }
}