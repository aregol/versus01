using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aplication.Data
{
    [Table("Tabla")]
    public class Tabla
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Moneda { get; set; }
        public bool Boleano { get; set; }
        public DateTime FechaHora { get; set; }
        public Guid Guid { get; set; }
    }
}
