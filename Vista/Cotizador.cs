using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CotizadorExpress
{
    public partial class Cotizador : Form
    {
        Vendedor vendedor;
        int stockTotal;

        public Cotizador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Camisa.stockCamisaCortaMao = 200;
            Camisa.stockCamisaCortaNormal = 300;
            Camisa.stockCamisaLargaMao = 150;
            Camisa.stockCamisaLargaNormal = 350;
            Pantalon.stockPantalonChupin = 1500;
            Pantalon.stockPantalonNormal = 500;


            TiendaDeRopa tienda = new TiendaDeRopa();
            tienda.Nombre = "La tienda";
            tienda.Direccion = "Calle Colón 123";
            lblNombreTienda.Text = tienda.Nombre;
            lblDireccionTienda.Text = tienda.Direccion;

            vendedor = new Vendedor();
            vendedor.CodigoDeVendedor = 123;
            vendedor.Nombre = "Noemí";
            vendedor.Apellido = "Morales";
            lblNombreApellidoVendedor.Text = vendedor.Nombre + " " + vendedor.Apellido;
            lblCodigoVendedor.Text = vendedor.CodigoDeVendedor.ToString();


            rdbtnCamisa.Checked = false;
            rdbtnPantalon.Checked = false;
            rdbtnPremium.Checked = false;
            rdbtnStandard.Checked = false;
            chbxChupin.Enabled = false;
            chbxCuello.Enabled = false;
            chbxManga.Enabled = false;

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Historial historial = new Historial();
            historial.Show();
        }

        private void rbtnCamisa_CheckedChanged(object sender, EventArgs e)
        {
            chbxCuello.Enabled = true;
            chbxManga.Enabled = true;
            chbxChupin.Enabled = false;
            ContarStockCamisa();
        }

        private void ContarStockCamisa()
        {
            if (chbxCuello.Checked && chbxManga.Checked)
            {
                stockTotal = Camisa.stockCamisaCortaMao;
            }
            else if (chbxCuello.Checked)
            {
                stockTotal = Camisa.stockCamisaLargaMao;
            }
            else if (chbxManga.Checked)
            {
                stockTotal = Camisa.stockCamisaCortaNormal;
            }
            else
            {
                stockTotal = Camisa.stockCamisaLargaNormal;
            }
            lblUnidadesDisponibles.Text = stockTotal.ToString();
        }
        private void rbtnPantalon_CheckedChanged(object sender, EventArgs e)
        {
            chbxChupin.Enabled = true;
            chbxCuello.Enabled = false;
            chbxManga.Enabled = false;

            if (chbxChupin.Checked)
            {
                stockTotal = Pantalon.stockPantalonChupin;
            }
            else
            {
                stockTotal = Pantalon.stockPantalonNormal;
            }
            lblUnidadesDisponibles.Text = stockTotal.ToString();
        }

        public bool ValidarRadioButton()
        {
            bool ok = true;
            //chequear los radiobutton
            if(!rdbtnCamisa.Checked && !rdbtnPantalon.Checked && !rdbtnPremium.Checked && !rdbtnStandard.Checked)
            {
                ok = false;
            }
            else if(!rdbtnCamisa.Checked && !rdbtnPantalon.Checked)
            {
                ok = false;
            }
            else if (!rdbtnPremium.Checked && !rdbtnStandard.Checked)
            {
                ok = false;
            }
            return ok;
        }

        public bool ValidarCampoInt(string campo)
        {
            bool ok = true;
            int entero;
            try
            {
                entero = int.Parse(campo);
            }
            catch (ArgumentNullException ae)
            {
                lblNotificacion.Text = "Campo cantidad vacío";
                ok = false;
            }
            catch (FormatException fe)
            {

                lblNotificacion.Text = "Formato de campo cantidad inválido";
                ok = false;
            }
            catch (OverflowException oe)
            {
                lblNotificacion.Text = "El campo cantidad excede la cantidad de caracteres";
                ok = false;
            }
            return ok;
        }

        public bool ValidarCampoDouble(string campo)
        {
            bool ok = true;
            double doble;
            try
            {
                doble = double.Parse(campo);
            }
            catch (ArgumentNullException ae)
            {
                lblNotificacion.Text = "Campo precio vacío";
                ok = false;
            }
            catch (FormatException fe)
            {

                lblNotificacion.Text = "Formato de campo precio inválido";
                ok = false;
            }
            catch (OverflowException oe)
            {
                lblNotificacion.Text = "El campo precio excede la cantidad de caracteres";
                ok = false;
            }
            return ok;
        }

        public bool ValidarCantidad()
        {
            bool ok = true;
            if(stockTotal < int.Parse(txtCantidad.Text))
            {
                ok = false;
            }
            return ok;
        }
        private void btnCotizar_Click(object sender, EventArgs e)
        {
            bool esPremium = false;
            string tipoDePrenda = "";
            bool esMangaCorta = false;
            bool esCuelloMao = false;
            bool esChupin = false;

            lblNotificacion.Visible = false;

            #region validaciones
            if (!ValidarRadioButton())
            {
                lblNotificacion.Visible = true;
                lblNotificacion.Text = "Debe seleccionar al menos una opción.";
                return;
            }
            if (!ValidarCampoInt(txtCantidad.Text))
            {
                lblNotificacion.Visible = true;
                return;
            }
            if (!ValidarCampoDouble(txtPrecio.Text))
            {
                lblNotificacion.Visible = true;
                return;
            }
            if (!ValidarCantidad())
            {
                lblNotificacion.Visible = true;
                lblNotificacion.Text = "No se puede realizar una cotización sobre una cantidad de stock no disponible.";
                return;
            }

            if (rdbtnPremium.Checked)
            {
                esPremium = true;
            }
            else if (rdbtnStandard.Checked)
            {
                esPremium = false;
            }

            if(rdbtnPantalon.Checked)
            {
                tipoDePrenda = "Pantalón";
                if(chbxChupin.Checked)
                {
                    esChupin = true;
                }
            }
            else if (rdbtnCamisa.Checked)
            {
                tipoDePrenda = "Camisa";
                if(chbxManga.Checked)
                {
                    esMangaCorta = true;
                }
                if(chbxCuello.Checked)
                {
                    esCuelloMao = true;
                }
            }

            #endregion

            Controlador controlador = new Controlador();
            lblCotizacion.Text = controlador.CalcularResultado(double.Parse(txtPrecio.Text), int.Parse(txtCantidad.Text), tipoDePrenda, esPremium, esMangaCorta, esCuelloMao, esChupin, vendedor);
        }

        private void chbxManga_CheckedChanged(object sender, EventArgs e)
        {
            ContarStockCamisa();
        }

        private void chbxChupin_CheckedChanged(object sender, EventArgs e)
        {
            stockTotal = chbxChupin.Checked ? Pantalon.stockPantalonChupin : Pantalon.stockPantalonNormal;
            lblUnidadesDisponibles.Text = stockTotal.ToString();

        }

        private void chbxCuello_CheckedChanged(object sender, EventArgs e)
        {
            ContarStockCamisa();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rdbtnCamisa.Checked = false;
            rdbtnPantalon.Checked = false;
            rdbtnPremium.Checked = false;
            rdbtnStandard.Checked = false;
            chbxChupin.Enabled = false;
            chbxChupin.Checked = false;
            chbxCuello.Enabled = false;
            chbxCuello.Checked = false;
            chbxManga.Enabled = false;
            chbxManga.Checked = false;
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            lblCotizacion.Text = "";
            lblUnidadesDisponibles.Text = "";
        }
    }
}
