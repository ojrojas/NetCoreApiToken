namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// AreaViewModel, modelo de transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>09/06/2020</date>
    public class AreaViewModel : BaseEntity
    {
        /// <summary>
        /// Name, propiedad utiliza para vista de modelo transaccion
        /// </summary>
        /// <value>Nombre del area</value>
        /// <author>Oscar Julian Rojas </author>
        /// <date>09/06/2020</date>
        public string Name { get; set; }
         /// <summary>
        /// Code, propiedad utiliza para vista de modelo transaccion
        /// </summary>
        /// <value>Codigo del area</value>
        /// <author>Oscar Julian Rojas </author>
        /// <date>09/06/2020</date>
        public int Code { get; set; }

        /// <summary>
        /// AreaToAreaViewModel, 
        /// funcion que mapea las areas a areasViewModel
        /// </summary>
        /// <param name="area">Area a mapear a AreaViewModel</param>
        /// <returns>Vista de modelo Area</returns>
       /// <author>Oscar Julian Rojas </author>
        /// <date>09/06/2020</date>
        public AreaViewModel AreaToAreaViewModel(Area area)
        {
            return new AreaViewModel
            {
                Id = area.Id,
                Name = area.Nombre,
                Code = area.Codigo
            };
        }

        /// <summary>
        /// AreaViewModelToArea, 
        /// funcion que mapea las areasViewModel a Areas
        /// </summary>
        /// <param name="area">AreaViewModel a mapear a Areas</param>
        /// <returns>Vista de modelo AreaViewModel</returns>
        /// <author>Oscar Julian Rojas </author>
        /// <date>09/06/2020</date>
        public Area AreaViewModelToArea(AreaViewModel areaViewModel)
        {
            return new Area
            {
                Id = areaViewModel.Id,
                Nombre = areaViewModel.Name,
                Codigo = areaViewModel.Code
            };
        }
    }
}