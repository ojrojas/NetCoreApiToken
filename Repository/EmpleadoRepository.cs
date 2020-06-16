using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using RappiApi.Models;
using RappiApi.Models.ViewModels;
using RappiApi.Querys;
using RappiApi.Repository.Interfaces;

namespace RappiApi.Repository
{
    /// <summary>
    /// EmpleadoRepository, clase que implementa la interface IEmpleadoRepository
    /// </summary>
    /// <autor>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class EmpleadoRepository : IEmpleadoRepository
    {
        /// <summary>
        /// Interface, que expone la configuracion de appsettings.json
        /// </summary>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly IConfiguration _config;

        /// <summary>
        /// QueryArea, clase que devuelve la simulacion de procedimientos almacenados
        /// </summary>
        /// <returns>Query en string para las acciones de ado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        private readonly QueryEmpleado query = new QueryEmpleado();

        /// <summary>
        /// Constructor de EmpleadoRepository
        /// </summary>
        /// <param name="config">Interface de configuracion</param>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public EmpleadoRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// ActualizarEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Entero notifica si se actualizo o no el empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ActualizarEmpleadoAsync(Empleado empleado)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ActualizarEmpleadoQuery(empleado), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="filtro">Filtro para busqueda en base datos de empleados</param>
        /// <returns>Lista vista modelos EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<IReadOnlyList<EmpleadoViewModel>> BuscarEmpleados(string filtro)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerEmpleadoPorIdentitficacionONombresQuery(filtro), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var empleadoViewModel = new List<EmpleadoViewModel>();
                while (reader.Read())
                {
                    empleadoViewModel.Add(new EmpleadoViewModel
                    {
                        Id = reader.GetString(0),
                        TypeIdentification = reader.GetInt32(1),
                        IdentificationNumber = reader.GetString(2),
                        Name = reader.GetString(3),
                        SecondName = reader.GetString(4),
                        SurName = reader.GetString(5),
                        SecondSurname = reader.GetString(6),
                        SubAreaId = reader.GetString(7)
                    });

                }

                return empleadoViewModel;
            }
        }

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <returns>Entero, cantidad de registro existente de empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ContarEmpleadosAsync()
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ContarEmpleadosQuery(), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return reader.GetInt32(0);
                }
                return default(int);
            }
        }

        /// <summary>
        /// CrearEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Vista modelo EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<EmpleadoViewModel> CrearEmpleadoAsync(Empleado empleado)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                var guid = Guid.NewGuid().ToString();
                empleado.Id = guid;
                SqliteCommand comando = new SqliteCommand(
                    query.CrearEmpleadoQuery(empleado), connection);
                var resultado = await comando.ExecuteNonQueryAsync();
                if (resultado > default(int))
                    return new EmpleadoViewModel().EmpleadoToEmpleadoViewModel(empleado);
                return null;
            }
        }

        /// <summary>
        /// EliminarEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Entero notifica si se actualizo o no el empleado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> EliminarEmpleadoAsync(Empleado empleado)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.EliminarEmpleadoQuery(empleado), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// ObtenerEmpleadoAsync
        /// </summary>
        /// <param name="empleado">Entidad Empleado</param>
        /// <returns>Vista modelo empleado solicitado</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<EmpleadoViewModel> ObtenerEmpleadoAsync(Empleado empleado)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerEmpleadoQuery(empleado), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var empleadoViewModel = new EmpleadoViewModel();
                while (reader.Read())
                {
                    empleadoViewModel.Id = reader.GetString(0);
                    empleadoViewModel.TypeIdentification = reader.GetInt32(1);
                    empleadoViewModel.IdentificationNumber = reader.GetString(2);
                    empleadoViewModel.Name = reader.GetString(3);
                    empleadoViewModel.SecondName = reader.GetString(4);
                    empleadoViewModel.SurName = reader.GetString(5);
                    empleadoViewModel.SecondSurname = reader.GetString(6);
                    empleadoViewModel.SubAreaId = reader.GetString(7);

                }

                return empleadoViewModel;
            }
        }

        /// <summary>
        /// ObtenerEmpleadosAsync
        /// </summary>
        /// <param name="paginacion">Entidad de paginacion</param>
        /// <returns>Lista de vistas modelo EmpleadoViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<IReadOnlyList<EmpleadoViewModel>> ObtenerEmpleadosAsync(PaginacionViewModel paginacion)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerEmpleadosQuery(paginacion), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var empleadoViewModel = new List<EmpleadoViewModel>();
                while (reader.Read())
                {
                    empleadoViewModel.Add(new EmpleadoViewModel
                    {
                        Id = reader.GetString(0),
                        TypeIdentification = reader.GetInt32(1),
                        IdentificationNumber = reader.GetString(2),
                        Name = reader.GetString(3),
                        SecondName = reader.GetString(4),
                        SurName = reader.GetString(5),
                        SecondSurname = reader.GetString(6),
                        SubAreaId = reader.GetString(7)
                    });
                }

                return empleadoViewModel;
            }
        }
    }
}