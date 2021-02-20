using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class ConexionBD
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/nmora/source/repos/CotizadorExpress/Cotizador.accdb");

        public ConexionBD()
        {
            con.Open();
        }

        public void Insertar(Cotizacion cotizacion)
        {
            using (OleDbCommand insertCommand = new OleDbCommand("INSERT INTO Cotizacion ([fechaYHora],[prenda],[cantidadDeUnidades],[resultadoCotizacion],[vendedor]) VALUES (?,?,?,?,?)", con))
            {

                insertCommand.Parameters.AddWithValue("@fechaYHora", cotizacion.FechaYHora);
                insertCommand.Parameters.AddWithValue("@prenda", cotizacion.Prenda.Nombre);
                insertCommand.Parameters.AddWithValue("@cantidadDeUnidades", cotizacion.CantidadDeUnidades);
                insertCommand.Parameters.AddWithValue("@resultadoCotizacion", cotizacion.ResultadoCotizacion);
                insertCommand.Parameters.AddWithValue("@vendedor", cotizacion.Vendedor.Nombre + " " + cotizacion.Vendedor.Apellido); 
                insertCommand.ExecuteNonQuery();
            }
        }
        
        public List<string> Leer()
        {
            var historial = new List<string>();
            using (OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM Cotizacion WHERE vendedor='Noemí Morales'", con))
            {
                DataTable tabla = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = selectCommand;
                adapter.Fill(tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    object IdValue = row["Id"];
                    object fechaYHoraValue = row["fechaYHora"];
                    object prendaValue = row["prenda"];
                    object cantidadDeUnidadesValue = row["cantidadDeUnidades"];
                    object resultadoCotizacionValue = row["resultadoCotizacion"];
                    object vendedorValue = row["vendedor"];
                    string cadena = "Id: " + IdValue + ", fecha: " + 
                        fechaYHoraValue.ToString() + 
                        ", vendedor: " + vendedorValue.ToString() 
                        + ", prenda: " + prendaValue + ", cantidad: " + 
                        cantidadDeUnidadesValue.ToString() + ", resultado: " + 
                        resultadoCotizacionValue.ToString();
                    historial.Add(cadena);
                }
            }
            return historial;
        }

    }
}
