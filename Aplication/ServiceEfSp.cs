using Aplication.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ServiceEfSp : IService
    {
        private readonly DemoContext _context;

        public ServiceEfSp(DemoContext context)
        {
            _context = context;
        }

        public async Task<Tabla> Add(Tabla entity)
        {
            var param1 = new SqlParameter("@Texto", entity.Texto);
            var param2 = new SqlParameter("@Fecha", entity.Fecha);
            var param3 = new SqlParameter("@Moneda", entity.Moneda);
            var param4 = new SqlParameter("@Boleano", entity.Boleano);
            var param5 = new SqlParameter("@FechaHora", entity.FechaHora);
            var param6 = new SqlParameter("@Guid", entity.Guid);

            var param7 = new SqlParameter("@Id", SqlDbType.Int) { Direction = ParameterDirection.Output };
            param7.Value = 0;

            await _context.Database.ExecuteSqlRawAsync(
                "exec usp_Insert @Texto, @Fecha, @Moneda, @Boleano, @FechaHora, @Guid, @Id out"
                , param1
                , param2
                , param3
                , param4
                , param5
                , param6
                , param7);

            entity.Id = (int)param7.Value;
            return entity;
        }


        public async Task AddMany(List<Tabla> entityList)
        {
            var data = new DataDummy();
            var table = data.DummyTable(entityList);

            var param = new SqlParameter("@Records", table)
            {
                TypeName = "TvpRecords",
                SqlDbType = SqlDbType.Structured
            };

            await _context.Database.ExecuteSqlRawAsync("exec usp_InsertTvp @Records", param);
        }

    }
}