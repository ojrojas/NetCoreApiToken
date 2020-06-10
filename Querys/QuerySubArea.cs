using System.Globalization;
using RappiApi.Models;

namespace RappiApi.Querys
{
    public class QuerySubArea
    {
        public string CrearSubAreaQuery(SubArea subarea)
        {
            string query =
            $"insert into SubArea(Id,Nombre,Codigo)" +
            $"values ('{subarea.Id}'," +
            $"'{subarea.Nombre}'," +
             $"{subarea.Codigo})";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ActualizarSubAreaQuery(SubArea subarea)
        {
            string query = $"update SubArea set Nombre= '{subarea.Nombre}'," +
             $"Codigo={subarea.Codigo} where Id = '{subarea.Id}'";
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
        public string ObtenerSubAreasQuery()
        {
            string query = "select * from SubArea";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
        public string ContarSubAreasQuery()
        {
            string query = "select count(*) from SubArea";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
    }
}