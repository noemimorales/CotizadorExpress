using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorExpress
{
    class Camisa: Prenda
    {
        private bool esMangaCorta;
        private bool esCuelloMao;

        public static int stockCamisaCortaMao;
        public static int stockCamisaCortaNormal;
        public static int stockCamisaLargaMao;
        public static int stockCamisaLargaNormal;

        public bool EsMangaCorta { get => esMangaCorta; set => esMangaCorta = value; }
        public bool EsCuelloMao { get => esCuelloMao; set => esCuelloMao = value; }

        public override double CalcularPrecio()
        {
            PrecioCalculado = base.CalcularPrecio();
            PrecioFinal = PrecioCalculado;
            //RN 3- Si la camisa es de manga corta y cuello mao, deben aplicarse las dos reglas anteriores (en el orden establecido).
            if (EsMangaCorta)
            {
                PrecioFinal = PrecioCalculado * 0.9; //RN 1- Si la camisa es de tipo manga corta, el precio se rebaja en un 10%.
            }
            if(EsCuelloMao)
            {
                PrecioFinal = PrecioCalculado * 1.03; //RN 2 - Si la camisa tiene cuello mao, el precio aumenta en un 3 %.
            }
            return PrecioFinal;
        }

        public override void PrendaNombre()
        {
            if (EsMangaCorta && EsCuelloMao)
            {
                this.Nombre = "Camisa manga corta cuello mao";
            }
            else if (!EsMangaCorta && !EsCuelloMao)
            {
                this.Nombre = "Camisa manga larga";
            }
            else if (EsMangaCorta && !EsCuelloMao)
            {
                this.Nombre = "Camisa manga corta";
            }
            else if (EsCuelloMao && !EsMangaCorta)
            {
                this.Nombre = "Camisa manga larga cuello mao";
            }
        }
    }
}
