namespace RappiApi.Models
{
    public class Empleado : BaseEntity
    {
        public int TipoIdentificacion { get; set; }
        public string NumeroIDentitificacion { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public SubArea SubArea { get; set; }
        public string SubAreaId { get; set; }

    }
}