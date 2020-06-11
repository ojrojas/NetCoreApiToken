using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    public interface IAreaService
    {
        Task<AreaViewModel> CrearArea(AreaViewModel areaViewModel);
        Task<int> ActualizarArea(AreaViewModel areaViewModel);
        Task<int> EliminarArea(AreaViewModel areaViewModel);
        Task<AreaViewModel> ObtenerArea(AreaViewModel areaViewModel);
        Task<IReadOnlyList<AreaViewModel>> ObtenerAreas(PaginacionViewModel paginacion = null);
        Task<int> ContarAreas();
    }
}