using System.Globalization;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Querys
{
    public class QueryArea
    {
         public string CrearAreaQuery(Area area)
        {
            string query = 
            $"insert into Area(Id,Nombre,Codigo)" + 
            $"values ('{area.Id}'," +
            $"'{area.Nombre}'," +
             $"{area.Codigo})";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ActualizarAreaQuery(Area area)
        {
            string query = $"update Area set Nombre= '{area.Nombre}'," +
             $"Codigo={area.Codigo} where Id = '{area.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string EliminarAreaQuery(Area area)
        {
            string query = $"delete from Area where Id = '{area.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ObtenerAreaQuery(Area area)
        {
            string query = $"select * from Area where Id='{area.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
        public string ObtenerAreasQuery(PaginacionViewModel paginacion =null)
        {
            if (paginacion == null)
            {
                string query = "select * from Area";
                return string.Format(
                    CultureInfo.CurrentCulture, query);
            }
            else
            {
                string query = $"select * from Area limit {paginacion.Pagina},{paginacion.TamanoPagina}";
                return string.Format(
                    CultureInfo.CurrentCulture, query);
            }
        }
        public string ContarAreasQuery()
        {
            string query = "select count(*) from Area";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
    }
}