using System.Globalization;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Querys
{
    public class QuerySubArea
    {
        public string CrearSubAreaQuery(SubArea subarea)
        {
            string query =
            $"insert into SubArea(Id,Nombre,Codigo,AreaId)" +
            $"values ('{subarea.Id}'," +
            $"'{subarea.Nombre}'," +
             $"{subarea.Codigo}," +
             $"'{subarea.AreaId}')";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ActualizarSubAreaQuery(SubArea subarea)
        {
            string query = $"update SubArea set Nombre= '{subarea.Nombre}'," +
             $"Codigo={subarea.Codigo}, AreaId = '{subarea.AreaId}' where Id = '{subarea.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string EliminarSubAreaQuery(SubArea subarea)
        {
            string query = $"delete from SubArea where Id = '{subarea.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ObtenerSubAreaQuery(SubArea subarea)
        {
            string query = $"select * from SubArea where Id='{subarea.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
        public string ObtenerSubAreasQuery(PaginacionViewModel paginacion = null)
        {
            if (paginacion.TamanoPagina == 0)
            {
                string query = "select * from SubArea";
                return string.Format(
                    CultureInfo.CurrentCulture, query);
            }
            else
            {
                string query = $"select * from SubArea limit {paginacion.Pagina},{paginacion.TamanoPagina}";
                return string.Format(
                    CultureInfo.CurrentCulture, query);
            }

        }
        public string ContarSubAreasQuery()
        {
            string query = "select count(*) from SubArea";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ObtenerSubAreasByAreasIdQuery(AreaViewModel area)
        {
            string query = $"select * from SubArea where AreaId = '{area.Id}'";
                return string.Format(
                    CultureInfo.CurrentCulture, query);
        }
    }
}