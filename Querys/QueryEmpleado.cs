using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using RappiApi.Data;
using RappiApi.Models;
using RappiApi.Models.ViewModels;

namespace RappiApi.Querys
{
    public class QueryEmpleado
    {
        public string CrearEmpleadoQuery(Empleado empleado)
        {
            string query = 
            $"insert into Empleado(Id,TipoIdentificacion,NumeroIDentitificacion, Nombre, " + 
            "SegundoNombre, Apellido, SegundoApellido, SubAreaId)" + 
            $"values ('{empleado.Id}'," +
            $"{empleado.TipoIdentificacion}," +
             $"'{empleado.NumeroIDentitificacion}'," +
              $"'{empleado.Nombre}'," +
               $"'{empleado.SegundoNombre}'," +
                $"'{empleado.Apellido}'," +
                 $"'{empleado.SegundoApellido}'," +
                  $"'{empleado.SubAreaId}')";

            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string ActualizarEmpleadoQuery(Empleado empleado)
        {
            string query = $"update Empleado set TipoIdentificacion= {empleado.TipoIdentificacion}," +
             $"NumeroIDentitificacion='{empleado.NumeroIDentitificacion}'," +
             $"Nombre='{empleado.Nombre}'," +
              $"SegundoNombre='{empleado.SegundoNombre}'," +
               $"Apellido='{empleado.Apellido}'," +
                $"SegundoApellido='{empleado.SegundoApellido}'," +
                 $"SubAreaId='{empleado.SubAreaId}' where Id = '{empleado.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }

        public string EliminarEmpleadoQuery(Empleado empleado)
        {
            string query = $"delete from Empleado where Id = '{empleado.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }


        public string ObtenerEmpleadoQuery(Empleado empleado)
        {
            string query = $"select * from Empleado where Id='{empleado.Id}'";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
        public string ObtenerEmpleadosQuery(PaginacionViewModel paginacion = null)
        {
            if(paginacion == null)
            {
                string query = "select * from Empleado";
            return string.Format(
                CultureInfo.CurrentCulture, query);
            }
            else
            {
                string query = $"select * from Empleado limit {paginacion.Pagina},{paginacion.TamanoPagina}";
            return string.Format(
                CultureInfo.CurrentCulture, query);
            }
            
        }
        public string ContarEmpleadosQuery()
        {
            string query = "select count(*) from Empleado";
            return string.Format(
                CultureInfo.CurrentCulture, query);
        }
    }
}