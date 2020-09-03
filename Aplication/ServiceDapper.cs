using Aplication.Data;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ServiceDapper : IService
    {
        private readonly IConfiguration _config;

        public ServiceDapper(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
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
                entity.Id = identity;
            }

            return entity;
        }

        public async Task AddMany(List<Tabla> entityList)
        {
            using (var connection = Connection)
            {
                connection.Open();
                var result = await connection.InsertAsync(entityList);
            }
        }
    }
}
