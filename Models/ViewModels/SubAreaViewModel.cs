namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// SubAreaViewModel, Modelo empleado para la transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>09/06/2020</date>
    public class SubAreaViewModel : BaseEntity
    {
        /// <summary>
        /// Name, propiedad Name para la transaccion
        /// </summary>
        /// <value>Name</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Name { get; set; }

        /// <summary>
        /// Code, propiedad Code para la transaccion
        /// </summary>
        /// <value>Code</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int Code { get; set; }

        /// <summary>
        /// Area, propiedad Area para la transaccion
        /// </summary>
        /// <value>Area</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public Area Area { get; set; }

        /// <summary>
        /// AreaId, propiedad AreaId para la transaccion
        /// </summary>
        /// <value>AreaId</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string AreaId { get; set; }

        /// <summary>
        /// SubAreaToSubAreaViewModel, funcion que mapea los datos
        /// </summary>
        /// <param name="subArea">SubArea que mapeara a SubAreaViewModel</param>
        /// <returns>Vista de modelo SubAreaViewModel</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public SubAreaViewModel SubAreaToSubAreaViewModel(SubArea subArea)
        {
            return new SubAreaViewModel
            {
                Id = subArea.Id,
                Name = subArea.Nombre,
                Code = subArea.Codigo,
                AreaId = subArea.AreaId
            };
        }

        /// <summary>
        /// SubAreaToSubAreaViewModel, funcion que mapea los datos
        /// </summary>
        /// <param name="subArea">SubArea que mapeara a SubAreaViewModel</param>
        /// <returns>Vista de modelo SubAreaViewModel</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public SubArea SubAreaViewModelToSubArea(SubAreaViewModel subAreaViewModel)
        {
            return new SubArea
            {
                Id = subAreaViewModel.Id,
                Nombre = subAreaViewModel.Name,
                Codigo = subAreaViewModel.Code,
                AreaId = subAreaViewModel.AreaId
            };
        }
    }
}