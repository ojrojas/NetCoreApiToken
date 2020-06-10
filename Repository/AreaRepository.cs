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
    public class AreaRepository : IAreaRepository
    {
        private readonly IConfiguration _config;
        private readonly QueryArea query =  new QueryArea();

        public AreaRepository(IConfiguration config)
        {
            _config = config;
        }
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

        public async Task<IReadOnlyList<AreaViewModel>> ObtenerAreasAsync()
        {
           using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerAreasQuery(), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var areaViewModel = new List<AreaViewModel>();
                while (reader.Read())
                {
                    areaViewModel.Add(new AreaViewModel
                    {
                        Id = reader.GetString(0),
                        Name= reader.GetString(1),
                        Code = reader.GetInt32(2),
                    });
                }

                return areaViewModel;
            }
        }
    }
}