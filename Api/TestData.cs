using Aplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class TestData
    {
        private Tabla _single;
        private List<Tabla> _many;
        public TestData()
        {
            LoadData();
        }

        private void LoadData()
        {
            _single = new Tabla
            {
                Texto = "Texto",
                Fecha = DateTime.UtcNow,
                Moneda = 1,
                Boleano = true,
                FechaHora = DateTime.UtcNow,
                Guid = Guid.NewGuid()
            };

            _many = new List<Tabla>();
            for (int i = 1; i <= 1000; i++)
            {
                var single = new Tabla
                {
                    Texto = "Texto-" + i.ToString(),
                    Fecha = DateTime.UtcNow,
                    Moneda = 1,
                    Boleano = true,
                    FechaHora = DateTime.UtcNow,
                    Guid = Guid.NewGuid()
                };

                _many.Add(single);
            }

        }

        public Tabla Single()
        {
            _single.Id = 0;
            return _single;
        }

        public List<Tabla> Many()
        {
            _many.ForEach(data => data.Id = 0);

            return _many;
        }
    }
}