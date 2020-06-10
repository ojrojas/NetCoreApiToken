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
        private readonly IConfiguration _config;
        private readonly QuerySubArea query =  new QuerySubArea();

        public SubAreaRepository(IConfiguration config)
        {
            _config = config;
        }
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

        public async Task<IReadOnlyList<SubAreaViewModel>> ObtenerSubAreasAsync()
        {
           using (var connection = new SqliteConnection(_config["SqliteConnections"]))
            {
                await connection.OpenAsync();
                SqliteCommand comando = new SqliteCommand(
                    query.ObtenerSubAreasQuery(), connection);
                SqliteDataReader reader = await comando.ExecuteReaderAsync();
                var subareaViewModel = new List<SubAreaViewModel>();
                while (reader.Read())
                {
                    subareaViewModel.Add(new SubAreaViewModel
                    {
                        Id = reader.GetString(0),
                        Name= reader.GetString(1),
                        Code = reader.GetInt32(2),
                        AreaId = reader.GetString(3)
                    });
                }

                return subareaViewModel;
            }
        }
    }
}