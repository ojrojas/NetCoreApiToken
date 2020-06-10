using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;

namespace RappiApi.Services.Interfaces
{
    public interface IAreaService
    {
        Task<Area> CrearArea(Area area);
        Task<int> ActualizarArea(Area area);
        Task<int> EliminarArea(Area area);
        Task<Area> ObtenerArea(Area area);
        Task<IReadOnlyList<Area>> ObtenerAreas();
        Task<int> ContarAreas();
    }
}