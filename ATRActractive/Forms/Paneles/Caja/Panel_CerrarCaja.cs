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

namespace ATRActractive.Forms.Paneles.Caja
{
    public partial class Panel_CerrarCaja : Form
    {
        private CN_Caja caja = new CN_Caja();

        private bool cierreCaja;

        private Usuario usuario;

        public Panel_CerrarCaja()
        {
            InitializeComponent();
        }

        public bool CierreCaja { get => cierreCaja; set => cierreCaja = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            caja.cerrarCaja(usuario.getID_USUARIO(),txtEfectivoCaja.Text,txtDebitoCaja.Text,txtCreditoCaja.Text,txtCBU.Text,usuario.getIdCaja(),txtMP.Text);

            cierreCaja = true;

            this.Dispose();
        }

        private void Panel_CerrarCaja_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            string[] detallesDelDia = caja.detallesDelDia(usuario.getID_USUARIO(), usuario.getIdCaja());

            lblEfectivo.Text = detallesDelDia[0];

            txtEfectivoCaja.Text = detallesDelDia[0];

            lblCredito.Text = detallesDelDia[1];

            txtCreditoCaja.Text = detallesDelDia[1];

            lblDebito.Text = detallesDelDia[2];

            txtDebitoCaja.Text = detallesDelDia[2];

            lblCBU.Text = detallesDelDia[3];

            txtCBU.Text = detallesDelDia[3];

            txtMP.Text = detallesDelDia[4];

            lblMercadoPago.Text = detallesDelDia[4];
        }

        private void Panel_CerrarCaja_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtEfectivoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtEfectivoCaja.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCreditoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCreditoCaja.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtDebitoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtDebitoCaja.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCBU_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCBU.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
