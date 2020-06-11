using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    public interface ISubAreaService
    {
        Task<SubAreaViewModel> CrearSubArea(SubAreaViewModel subArea);
        Task<int> ActualizarSubArea(SubAreaViewModel subArea);
        Task<int> EliminarSubArea(SubAreaViewModel subArea);
        Task<SubAreaViewModel> ObtenerSubArea(SubAreaViewModel subArea);
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreas(PaginacionViewModel paginacion);
        Task<int> ContarSubAreas();
    }
}