using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Aplication.Data
{
    public class DataDummy
    {
        public DataTable DummyTable(List<Tabla> entityList)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Texto", typeof(string)));
            table.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Moneda", typeof(decimal)));
            table.Columns.Add(new DataColumn("Boleano", typeof(bool)));
            table.Columns.Add(new DataColumn("FechaHora", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));

            foreach (var r in entityList)
            {
                DataRow row = table.NewRow();
                row["Texto"] = r.Texto;
                row["Fecha"] = r.Fecha;
                row["Moneda"] = r.Moneda;
                row["Boleano"] = r.Boleano;
                row["FechaHora"] = r.FechaHora;
                row["Guid"] = r.Guid;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
