using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Cotizacion
    {
        private int id;
        private string fechaYHora;
        Vendedor vendedor;
        Prenda prenda;
        private int cantidadDeUnidades;
        private double resultadoCotizacion;

        public int Id { get => id; set => id = value; }
        public string FechaYHora { get => fechaYHora; set => fechaYHora = value; }
        public int CantidadDeUnidades { get => cantidadDeUnidades; set => cantidadDeUnidades = value; }
        public double ResultadoCotizacion { get => resultadoCotizacion; set => resultadoCotizacion = value; }
        internal Vendedor Vendedor { get => vendedor; set => vendedor = value; }
        internal Prenda Prenda { get => prenda; set => prenda = value; }

        public Cotizacion(int cantidadDeUnidades, Vendedor vendedor, Prenda prenda)
        {
            CantidadDeUnidades = cantidadDeUnidades;
            Vendedor = vendedor;
            Prenda = prenda;
            FechaYHora = DateTime.Now.ToString();
        }

        public void RealizarCotizacion()
        {
            ResultadoCotizacion = Prenda.CalcularPrecio();
            ConexionBD conexionBD = new ConexionBD();
            conexionBD.Insertar(this);
        }
    }
}
