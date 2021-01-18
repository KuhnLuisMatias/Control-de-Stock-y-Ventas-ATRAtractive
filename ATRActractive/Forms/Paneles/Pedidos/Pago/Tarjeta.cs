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

namespace ATRActractive.Forms.Paneles.Pedidos.Pago
{
    public partial class Tarjeta : Form
    {
        private CN_Categoria cnCategoria = new CN_Categoria();

        private CN_Pedido cnPedido = new CN_Pedido();

        private Usuario usuario = new Usuario();

        private bool banderaTarjeta;

        private string idPedido;

        private string importe;

        public string IdPedido { get => idPedido; set => idPedido = value; }

        public bool BanderaTarjeta { get => banderaTarjeta; set => banderaTarjeta = value; }

        public string Importe { get => importe; set => importe = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Tarjeta()
        {
            InitializeComponent();
        }

        private void Tarjeta_Load(object sender, EventArgs e)
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

            txtImporte.Text = importe;

            float imp = float.Parse(importe);

            lblRecargo.Text = "MercadoPago +5% \n$" + ((imp) + ( imp* 0.05)).ToString();

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtReferencia.TextLength > 0 && txtCuotas.TextLength>0)
            {
                BanderaTarjeta = true;

                string tarjeta = comboTarjeta.SelectedValue.ToString();

                string cuotas = txtCuotas.Text;

                string referencia = txtReferencia.Text;

                string tipoPago = comboTipo.SelectedValue.ToString();

                MessageBox.Show(cnPedido.actualizarEstadoPedidoTarjetaCBU(IdPedido, tarjeta, cuotas, referencia, importe, tipoPago, usuario.getIdCaja()));

                this.Dispose();
            }
        }
    }
}
