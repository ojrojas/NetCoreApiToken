namespace RappiApi.Models
{
    public class SubArea : BaseEntity
    {
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public Area Area { get; set; }
        public string AreaId { get; set; }
    }
}