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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IConfiguration _config;
         private readonly QueryEmpleado query = new QueryEmpleado();
        public EmpleadoRepository(IConfiguration config)
        {
            _config = config;
        }

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