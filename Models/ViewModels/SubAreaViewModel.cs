namespace RappiApi.Models.ViewModels
{
    public class SubAreaViewModel : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Area Area { get; set; }
        public string AreaId { get; set; }

        public SubAreaViewModel SubAreaToSubAreaViewModel(SubArea subArea)
        {
            return new SubAreaViewModel {
                Id = subArea.Id,
                Name = subArea.Nombre,
                Code = subArea.Codigo, 
                AreaId = subArea.AreaId
            };
        }

         public SubArea SubAreaViewModelToSubArea(SubAreaViewModel subAreaViewModel)
        {
            return new SubArea {
                Id = subAreaViewModel.Id,
                Nombre = subAreaViewModel.Name,
                Codigo = subAreaViewModel.Code, 
                AreaId = subAreaViewModel.AreaId
            };
        }

    }
}