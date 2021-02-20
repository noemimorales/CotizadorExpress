using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Prenda
    {
        protected bool esPremium;
        protected double precioDePrenda;
        protected int cantidadElegida;
        private double precioCalculado;
        private string nombre;
        protected double precioFinal;

        public double PrecioDePrenda { get => precioDePrenda; set => precioDePrenda = value; }
        public bool EsPremium { get => esPremium; set => esPremium = value; }
        public int CantidadElegida { get => cantidadElegida; set => cantidadElegida = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        protected double PrecioCalculado { get => precioCalculado; set => precioCalculado = value; }
        public double PrecioFinal { get => precioFinal; set => precioFinal = value; }

        public virtual double CalcularPrecio()
        {
            double ValorPrenda;
            PrecioCalculado = CantidadElegida * PrecioDePrenda;
            if (EsPremium)
            {
                ValorPrenda = PrecioCalculado * 1.3; //RN 6- Si la calidad de la prenda es Premium: el precio aumenta en un 30%.
            }
            else
            {
                ValorPrenda = PrecioCalculado;
            }

            return ValorPrenda;
        }

        public virtual void PrendaNombre() {}
    }
}
