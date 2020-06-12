namespace RappiApi.Models.ViewModels
{
    public class EmpleadoViewModel : BaseEntity
    {
        public int TypeIdentification { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string SurName { get; set; }
        public string SecondSurname { get; set; }
        public SubArea SubArea { get; set; }
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
            return new Empleado {
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
            return new EmpleadoViewModel {
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