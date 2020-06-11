using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Repository.Interfaces;
using RappiApi.Services.Interfaces;

namespace RappiApi.Services
{
    public class SubAreaService : ISubAreaService
    {
        private readonly ISubAreaRepository _repository;
        public SubAreaService(ISubAreaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ActualizarSubArea(SubAreaViewModel SubAreaViewmodel)
        {
            return await  _repository.ActualizarSubAreaAsync(
                SubAreaViewmodel.SubAreaViewModelToSubArea(SubAreaViewmodel));
        }

        public async Task<int> ContarSubAreas()
        {
return await _repository.ContarSubAreasAsync();
        }

        public async Task<SubAreaViewModel> CrearSubArea(SubAreaViewModel SubAreaViewModel)
        {
            return await _repository.CrearSubAreaAsync(
                SubAreaViewModel.SubAreaViewModelToSubArea(SubAreaViewModel));
        }

        public async Task<int> EliminarSubArea(SubAreaViewModel SubAreaViewModel)
        {
            return await _repository.EliminarSubAreaAsync(
                SubAreaViewModel.SubAreaViewModelToSubArea(SubAreaViewModel));
        }

        public async Task<SubAreaViewModel> ObtenerSubArea(SubAreaViewModel SubAreaViewModel)
        {
            return await _repository.ObtenerSubAreaAsync(
                SubAreaViewModel.SubAreaViewModelToSubArea(SubAreaViewModel));
        }

        public  async Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreas(
            PaginacionViewModel paginacion){
            return await _repository.ObtenerSubAreasAsync(paginacion);
        }
    }
}