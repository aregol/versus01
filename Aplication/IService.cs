using Aplication.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public interface IService
    {
        public Task<Tabla> Add(Tabla entity);

        public Task AddMany(List<Tabla> entityList);
    }
}
