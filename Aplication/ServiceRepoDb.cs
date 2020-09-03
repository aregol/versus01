using Aplication.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ServiceRepoDb: IService
    {
        private readonly IConfiguration _config;

        public ServiceRepoDb(IConfiguration config)
        {
            _config = config;
            SqlServerBootstrap.Initialize();
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("dbConnection"));
            }
        }

        public async Task<Tabla> Add(Tabla entity)
        {
            using (var connection = Connection)
            {
                var identity = await connection.InsertAsync(entity);
                entity.Id = (int)identity;
            }
            return entity;
        }

        public async Task AddMany(List<Tabla> entityList)
        {
            using (var connection = Connection)
            {
                var insertedRows = await connection.BulkInsertAsync(entityList);
                //var result = await connection.InsertAllAsync(entityList);
            }
        }
    }
}