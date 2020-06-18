namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// EmpleadoViewModel, Modelo empleado para la transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class EmpleadoViewModel : BaseEntity
    {
        /// <summary>
        /// TypeIdentification, propiedad TypeIdentification para la transaccion
        /// </summary>
        /// <value>TypeIdentification</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int TypeIdentification { get; set; }

        /// <summary>
        /// IdentificationNumber, propiedad IdentificationNumber para la transaccion
        /// </summary>
        /// <value>IdentificationNumber</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Name, propiedad Name para la transaccion
        /// </summary>
        /// <value>Name</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Name { get; set; }

        /// <summary>
        /// SecondName, propiedad SecondName para la transaccion
        /// </summary>
        /// <value>SecondName</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SecondName { get; set; }

        /// <summary>
        /// SurName, propiedad SurName para la transaccion
        /// </summary>
        /// <value>SurName</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SurName { get; set; }

        /// <summary>
        /// SecondSurname, propiedad SecondSurname para la transaccion
        /// </summary>
        /// <value>SecondSurname</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SecondSurname { get; set; }

        /// <summary>
        /// SubArea, propiedad SubArea para la transaccion
        /// </summary>
        /// <value>SubArea</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public SubArea SubArea { get; set; }

        /// <summary>
        /// SubAreaId, propiedad SubAreaId para la transaccion
        /// </summary>
        /// <value>SubAreaId</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SubAreaId { get; set; }

        /// <summary>
        /// Convertidos de modelos de EmpleadoViewModel a Empleado
        /// </summary>
        /// <param name="viewModel">EmpleadoViewModel</param>
        /// <returns>Devuelve un empleado</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        public Empleado EmpleadoViewModelToEmpleado(EmpleadoViewModel viewModel)
        {
            return new Empleado
            {
                Id = viewModel.Id,
                TipoIdentificacion = viewModel.TypeIdentification,
                NumeroIDentitificacion = viewModel.IdentificationNumber,
                Nombre = viewModel.Name,
                SegundoNombre = viewModel.SecondName,
                Apellido = viewModel.SurName,
                SegundoApellido = viewModel.SecondSurname,
                SubAreaId = viewModel.SubAreaId,
            };
        }

        /// <summary>
        /// Convertidos de modelos de Empleado a EmpleadoViewModel
        /// </summary>
        /// <param name="empleado">Empleado</param>
        /// <returns>Devuelve un EmpleadoViewModel</returns>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>09/06/2020</date>
        public EmpleadoViewModel EmpleadoToEmpleadoViewModel(Empleado empleado)
        {
            return new EmpleadoViewModel
            {
                Id = empleado.Id,
                TypeIdentification = empleado.TipoIdentificacion,
                IdentificationNumber = empleado.NumeroIDentitificacion,
                Name = empleado.Nombre,
                SecondName = empleado.SegundoNombre,
                SurName = empleado.Apellido,
                SecondSurname = empleado.SegundoApellido,
                SubAreaId = empleado.SubAreaId,
            };
        }
    }
}