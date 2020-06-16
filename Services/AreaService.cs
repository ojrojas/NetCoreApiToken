using System.Collections.Generic;
using System.Threading.Tasks;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Repository.Interfaces;
using RappiApi.Services.Interfaces;

namespace RappiApi.Services
{
    public class AreaServices : IAreaService
    {
        private readonly IAreaRepository _repository;
        public AreaServices(IAreaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ActualizarArea(AreaViewModel areaViewmodel)
        {
            return await _repository.ActualizarAreaAsync(
                areaViewmodel.AreaViewModelToArea(areaViewmodel));
        }

        public async Task<int> ContarAreas()
        {
            return await _repository.ContarAreasAsync();
        }

        public async Task<AreaViewModel> CrearArea(AreaViewModel areaViewModel)
        {
            return await _repository.CrearAreaAsync(
                areaViewModel.AreaViewModelToArea(areaViewModel));
        }

        public async Task<int> EliminarArea(AreaViewModel areaViewModel)
        {
            return await _repository.EliminarAreaAsync(
                areaViewModel.AreaViewModelToArea(areaViewModel));
        }

        public async Task<AreaViewModel> ObtenerArea(AreaViewModel areaViewModel)
        {
            return await _repository.ObtenerAreaAsync(
                areaViewModel.AreaViewModelToArea(areaViewModel));
        }

        public async Task<IReadOnlyList<AreaViewModel>> ObtenerAreas(PaginacionViewModel paginacion = null)
        {
            return await _repository.ObtenerAreasAsync(paginacion);
        }
    }
}