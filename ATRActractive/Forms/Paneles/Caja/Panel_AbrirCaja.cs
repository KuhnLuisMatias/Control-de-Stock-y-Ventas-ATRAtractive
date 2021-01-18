using Negocio;
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
    public partial class Panel_AbrirCaja : Form
    {
        private CN_Caja caja = new CN_Caja();

        private string idUsuario;

        private bool estadoCaja;

        public Panel_AbrirCaja()
        {
            InitializeComponent();
        }

        public bool EstadoCaja { get => estadoCaja; set => estadoCaja = value; }

        public string IdUsuario { get => idUsuario; set => idUsuario = value; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMonto.TextLength > 0)
            {
                caja.abrirCaja(IdUsuario, txtMonto.Text);

                estadoCaja = true;

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Debe ingresar un monto", "Atención");
            }
        }

        private void Panel_AbrirCaja_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Panel_AbrirCaja_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
