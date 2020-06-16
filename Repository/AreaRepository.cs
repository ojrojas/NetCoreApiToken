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
    /// AreaRepository, implementacion metodos IAreRepository
    /// </summary>
    /// <autor>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class AreaRepository : IAreaRepository
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
        private readonly QueryArea query = new QueryArea();

        /// <summary>
        /// Constructor de AreaRepository
        /// </summary>
        /// <param name="config">Interface de configuracion</param>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public AreaRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// ActualizarAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ActualizarAreaAsync(Area area)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ActualizarAreaQuery(area), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Cantidad existente en base de datos</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> ContarAreasAsync()
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ContarAreasQuery(), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return reader.GetInt32(0);
                }
                return default(int);
            }
        }

        /// <summary>
        /// CrearAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<AreaViewModel> CrearAreaAsync(Area area)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                var guid = Guid.NewGuid().ToString();
                area.Id = guid;
                SqliteCommand comando = new SqliteCommand(
                    query.CrearAreaQuery(area), connection);
                var resultado = await comando.ExecuteNonQueryAsync();
                if (resultado > default(int))
                    return new AreaViewModel().AreaToAreaViewModel(area);
                return null;
            }
        }

        /// <summary>
        /// EliminarAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Entero validador ejecucion</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<int> EliminarAreaAsync(Area area)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.EliminarAreaQuery(area), connection);
                return await comando.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// ObtenerAreaAsync
        /// </summary>
        /// <param name="Area">Entidad Area</param>
        /// <returns>Vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<AreaViewModel> ObtenerAreaAsync(Area area)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerAreaQuery(area), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var areaViewModel = new AreaViewModel();
                while (reader.Read())
                {
                    areaViewModel.Id = reader.GetString(0);
                    areaViewModel.Name = reader.GetString(1);
                    areaViewModel.Code = reader.GetInt32(2);
                }

                return areaViewModel;
            }
        }

        /// <summary>
        /// ObtenerAreasAsync
        /// </summary>
        /// <param name="PaginacionViewModel">Entidad PaginacionViewModel</param>
        /// <returns>Lista vista modelo AreaViewModel</returns>
        /// <autor>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public async Task<IReadOnlyList<AreaViewModel>> ObtenerAreasAsync(PaginacionViewModel paginacion)
        {
            using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerAreasQuery(paginacion), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var areaViewModel = new List<AreaViewModel>();
                while (reader.Read())
                {
                    areaViewModel.Add(new AreaViewModel
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Code = reader.GetInt32(2),
                    });
                }

                return areaViewModel;
            }
        }
    }
}