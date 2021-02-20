using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Vendedor
    {
        private int codigoDeVendedor;
        private string nombre;
        private string apellido;

        public int CodigoDeVendedor { get => codigoDeVendedor; set => codigoDeVendedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}
