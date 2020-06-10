namespace RappiApi.Models.ViewModels
{
    public class AreaViewModel : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public AreaViewModel AreaToAreaViewModel(Area area)
        {
            return new AreaViewModel {
                Id=area.Id,
                Name = area.Nombre,
                Code = area.Codigo
            };
        }

        public Area AreaViewModelToArea(AreaViewModel areaViewModel)
        {
            return new Area {
                Id= areaViewModel.Id,
                Nombre = areaViewModel.Name, 
                Codigo = areaViewModel.Code
            };
        }
    }
}