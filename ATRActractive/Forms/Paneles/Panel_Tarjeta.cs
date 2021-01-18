using Negocio;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATRActractive.Forms.Paneles
{
    public partial class Panel_Tarjeta : Form
    {
        private CN_Categoria cnCategoria = new CN_Categoria();

        private CN_Venta cnVenta = new CN_Venta();

        private Venta venta = new Venta();

        private bool ventaTarjeta;

        public Panel_Tarjeta()
        {
            InitializeComponent();
        }

        public Venta Venta { get => venta; set => venta = value; }

        public bool VentaTarjeta { get => ventaTarjeta; set => ventaTarjeta = value; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtReferencia.TextLength > 0 && txtCuotas.TextLength >0)
            {
                ventaTarjeta = true;

                cnVenta.insertarVenta(Venta.Usuario.getID_USUARIO(), Venta.Total.ToString(), Venta.Usuario.getIdCaja());

                cnVenta.insertarDetalle(Venta.Articulos, Venta.Usuario.getID_USUARIO());

                cnVenta.insertarPagoDetalle(comboTarjeta.SelectedValue.ToString(), txtCuotas.Text, txtReferencia.Text, txtImporte.Text, cnVenta.obtenerIDVenta(venta.Usuario.getID_USUARIO()), comboTipo.SelectedValue.ToString());

                cnVenta.descontarStock(Venta.Articulos);

                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Panel_Tarjeta_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            comboTarjeta.DataSource = cnCategoria.mostrarTarjetas();

            comboTipo.DataSource = cnCategoria.mostrarTipoTarjetas();

            comboTipo.DisplayMember = "DESCRIPCION";

            comboTarjeta.DisplayMember = "DESCRIPCION";

            comboTipo.ValueMember = "ID_TIPOPAGO";

            comboTarjeta.ValueMember = "ID_TARJETA";

            comboTipo.AutoCompleteCustomSource = cnCategoria.LoadAutoCompleteTipoTarjetas();

            comboTarjeta.AutoCompleteCustomSource = cnCategoria.LoadAutoCompleteTarjetas();

            comboTarjeta.AutoCompleteMode = AutoCompleteMode.Suggest;

            comboTipo.AutoCompleteMode = AutoCompleteMode.Suggest;

            comboTarjeta.AutoCompleteSource = AutoCompleteSource.CustomSource;

            comboTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtImporte.Text = venta.Total.ToString();

            lblImporte.Text = "MercadoPago +5% \n$" + (venta.Total + (venta.Total * 0.05)).ToString();
        }

        private void txtCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCuotas.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtImporte.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Panel_Tarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
