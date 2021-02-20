using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Controlador
    {
        public string CalcularResultado(double precio, int cantidad, string tipoDePrenda, bool esPremium, bool esMangaCorta, bool esCuelloMao,bool esChupin,Vendedor vendedor)
        {
            string resultado="";
            Cotizacion cotizacion;
            switch (tipoDePrenda)
            {
                case "Camisa":
                    Camisa camisa = new Camisa();
                    camisa.EsCuelloMao = esCuelloMao;
                    camisa.EsMangaCorta = esMangaCorta;
                    camisa.EsPremium = esPremium;
                    camisa.PrecioDePrenda = precio;
                    camisa.CantidadElegida = cantidad;
                    camisa.PrendaNombre();
                    cotizacion = new Cotizacion(cantidad, vendedor, camisa);
                    cotizacion.RealizarCotizacion();
                    resultado= cotizacion.ResultadoCotizacion.ToString();
                    break;
                case "Pantalón":
                    Pantalon pantalon = new Pantalon();
                    pantalon.EsChupin = esChupin;
                    pantalon.EsPremium = esPremium;
                    pantalon.PrecioDePrenda = precio;
                    pantalon.CantidadElegida = cantidad;
                    pantalon.PrendaNombre();
                    cotizacion = new Cotizacion(cantidad, vendedor, pantalon);
                    cotizacion.RealizarCotizacion();
                    resultado= cotizacion.ResultadoCotizacion.ToString();
                    break;
            }
            return resultado;
        }
    }
}
