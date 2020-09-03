using Aplication.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ServiceEf : IService
    {
        private readonly DemoContext _context;

        public ServiceEf(DemoContext context)
        {
            _context = context;
        }

        public async Task<Tabla> Add(Tabla entity)
        {
            await _context.Tabla.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddMany(List<Tabla> entityList)
        {
            await _context.Tabla.AddRangeAsync(entityList);
            await _context.SaveChangesAsync();
        }
    }
}
