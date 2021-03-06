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
    public class SubAreaRepository : ISubAreaRepository
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
        private readonly QuerySubArea query = new QuerySubArea();

        /// <summary>
        /// Constructor de SubAreaRepository
        /// </summary>
        /// <param name="config">Interface de configuracion</param>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public SubAreaRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// ActualizarSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ActualizarSubAreaAsync(SubArea Subarea)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ActualizarSubAreaQuery(Subarea), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// ContarSubAreasAsync
        /// </summary>
        /// <returns>Cantidad existente en base de datos</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ContarSubAreasAsync()
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ContarSubAreasQuery(), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return reader.GetInt32(0);
                }
                return default(int);
            }
        }

        /// <summary>
        /// CrearSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<SubAreaViewModel> CrearSubAreaAsync(SubArea Subarea)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                var guid = Guid.NewGuid().ToString();
                Subarea.Id = guid;
                SqliteCommand comando = new SqliteCommand(
                    query.CrearSubAreaQuery(Subarea), connection);
                var resultado = await comando.ExecuteNonQueryAsync();
                if (resultado > default(int))
                    return new SubAreaViewModel().SubAreaToSubAreaViewModel(Subarea);
                return null;
            }
        }

        /// <summary>
        /// EliminarSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        public async Task<int> EliminarSubAreaAsync(SubArea Subarea)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.EliminarSubAreaQuery(Subarea), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// ObtenerSubAreaAsync
        /// </summary>
        /// <param name="SubArea">Entidad SubArea</param>
        /// <returns>Vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<SubAreaViewModel> ObtenerSubAreaAsync(SubArea Subarea)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerSubAreaQuery(Subarea), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var subareaViewModel = new SubAreaViewModel();
                while (reader.Read())
                {
                    subareaViewModel.Id = reader.GetString(0);
                    subareaViewModel.Name = reader.GetString(1);
                    subareaViewModel.Code = reader.GetInt32(2);
                    subareaViewModel.AreaId = reader.GetString(3);
                }

                return subareaViewModel;
            }
        }

        /// <summary>
        /// ObtenerSubAreasAsync
        /// </summary>
        /// <param name="PaginacionViewModel">Entidad PaginacionViewModel</param>
        /// <returns>Lista vista modelo SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasAsync(PaginacionViewModel paginacion)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerSubAreasQuery(paginacion), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var subareaViewModel = new List<SubAreaViewModel>();
                while (reader.Read())
                {
                    subareaViewModel.Add(new SubAreaViewModel
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Code = reader.GetInt32(2),
                        AreaId = reader.GetString(3)
                    });
                }

                return subareaViewModel;
            }
        }

        /// <summary>
        /// ObtenerSubAreasByAreaIdAsync
        /// </summary>
        /// <param name="Area">Modelo vista AreaViewModel</param>
        /// <returns>Lista vista modelos de SubAreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasByAreaIdAsync(AreaViewModel area)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerSubAreasByAreasIdQuery(area), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var subareaViewModel = new List<SubAreaViewModel>();
                while (reader.Read())
                {
                    subareaViewModel.Add(new SubAreaViewModel
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Code = reader.GetInt32(2),
                        AreaId = reader.GetString(3)
                    });
                }

                return subareaViewModel;
            }
        }
    }
}