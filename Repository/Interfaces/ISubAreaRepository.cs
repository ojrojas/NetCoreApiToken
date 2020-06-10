using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Repository.Interfaces
{
    public interface ISubAreaRepository
    {

        Task<SubAreaViewModel> CrearSubAreaAsync(SubArea SubArea);
        Task<int> ActualizarSubAreaAsync(SubArea SubArea);
        Task<int> EliminarSubAreaAsync(SubArea SubArea);
        Task<SubAreaViewModel> ObtenerSubAreaAsync(SubArea SubArea);
        Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasAsync();
        Task<int> ContarSubAreasAsync();
    }
}