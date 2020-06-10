using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;

namespace RappiApi.Services.Interfaces
{
    public interface ISubAreaService
    {
        Task<SubArea> CrearSubArea(SubArea subArea);
        Task<int> ActualizarSubArea(SubArea subArea);
        Task<int> EliminarSubArea(SubArea subArea);
        Task<SubArea> ObtenerSubArea(SubArea subArea);
        Task<IReadOnlyList<SubArea>> ObtenerSubAreas();
        Task<int> ContarSubAreas();
    }
}