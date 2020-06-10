using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    public interface IAreaRepository
    {

        Task<AreaViewModel> CrearAreaAsync(Area Area);
        Task<int> ActualizarAreaAsync(Area Area);
        Task<int> EliminarAreaAsync(Area Area);
        Task<AreaViewModel> ObtenerAreaAsync(Area Area);
        Task<IReadOnlyList<AreaViewModel>> ObtenerAreasAsync();
        Task<int> ContarAreasAsync();
    }
}