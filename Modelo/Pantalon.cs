using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Pantalon: Prenda
    {
        private bool esChupin;


        public static int stockPantalonChupin;
        public static int stockPantalonNormal;

        public bool EsChupin { get => esChupin; set => esChupin = value; }

        public override double CalcularPrecio()
        {
            PrecioCalculado = base.CalcularPrecio();
            PrecioFinal = PrecioCalculado;
            if (EsChupin)
            {
                PrecioFinal = PrecioCalculado * 0.88;//RN 4 - Si el pantalón es chupín, el precio se rebaja en un 12 %.
            }
            return PrecioFinal;
        }

        public override void PrendaNombre()
        {
            if (EsChupin)
            {
                this.Nombre = "Pantalón chupín";
            }
            else
            {
                this.Nombre = "Pantalón común";
            }
        }
    }

}
