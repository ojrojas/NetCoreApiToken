using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    /// <summary>
    /// ISubAreaService, interface que expone los metodos de SubAreaService
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public interface ISubAreaService
    {
        /// <summary>
        /// CrearSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo para crear el registro</param>
        /// <returns>Vista de modelo creado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<SubAreaViewModel> CrearSubArea(SubAreaViewModel subArea);

        /// <summary>
        /// ActualizarSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada para actualizar subarea</param>
        /// <returns>Entero que notifica si se actualizo el registro</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ActualizarSubArea(SubAreaViewModel subArea);

        /// <summary>
        /// EliminarSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada para eliminar subarea</param>
        /// <returns>Entero que notifica si se elminar el registro</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> EliminarSubArea(SubAreaViewModel subArea);

        /// <summary>
        /// ObtenerSubArea
        /// </summary>
        /// <param name="subArea">Vista modelo entrada para obtener subarea</param>
        /// <returns>Datos del modelo de solicitado</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<SubAreaViewModel> ObtenerSubArea(SubAreaViewModel subArea);

        /// <summary>
        /// ObtenerSubAreas
        /// </summary>
        /// <param name="subArea">Vista modelo subarea</param>
        /// <returns>Lista vista modelo datos de SubAreas</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreas(PaginacionViewModel paginacion);

        /// <summary>
        /// ObtenerSubAreasByAreaId
        /// </summary>
        /// <param name="subArea">Vista modelo entrada subarea</param>
        /// <returns>Lista vista modelo SubAreas</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasByAreaId(AreaViewModel area);

        /// <summary>
        /// ContarSubAreas
        /// </summary>
        /// <returns>Entero que notifica la cantidad de registros</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        Task<int> ContarSubAreas();

    }
}