using Aplication.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ServiceDapperSp : IService
    {
        private readonly IConfiguration _config;

        public ServiceDapperSp(IConfiguration config)
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
            var parameters = new DynamicParameters();
            parameters.Add("@Texto", entity.Texto);
            parameters.Add("@Fecha", entity.Fecha);
            parameters.Add("@Moneda", entity.Moneda);
            parameters.Add("@Boleano", entity.Boleano);
            parameters.Add("@FechaHora", entity.FechaHora);
            parameters.Add("@Guid", entity.Guid);

            parameters.Add("@Id", null, DbType.Int32, ParameterDirection.Output);

            using (var connection = Connection)
            {
                await connection.ExecuteAsync("usp_Insert", parameters, commandType: CommandType.StoredProcedure);
                entity.Id = parameters.Get<int>("@Id");
            }
            return entity;
        }

        public async Task AddMany(List<Tabla> entityList)
        {
            var data = new DataDummy();
            var table = data.DummyTable(entityList);

            using (var connection = Connection)
            {
                //connection.Open();
                await connection.ExecuteAsync("usp_InsertTvp", new { Records = table.AsTableValuedParameter("TvpRecords") }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}