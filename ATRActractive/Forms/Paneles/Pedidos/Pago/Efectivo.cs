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
    public partial class Efectivo : Form
    {
        private string idPedido;

        private decimal total;

        private bool efectivoIngresado;

        public Efectivo()
        {
            InitializeComponent();
        }

        public string IdPedido { get => idPedido; set => idPedido = value; }

        public decimal Total { get => total; set => total = value; }

        public bool EfectivoIngresado { get => efectivoIngresado; set => efectivoIngresado = value; }

        private void Efectivo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            lblTotal.Text = "Total $ "+ total.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                decimal vuelto = 0;

                vuelto = -1 * (total - decimal.Parse(textBox1.Text));

                lblVuelto.Text = "Vuelto $ " + vuelto.ToString();
            }
            else
            {
                lblVuelto.Text = "Vuelto $ 0";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            EfectivoIngresado = true;

            this.Dispose();
        }

        private void Efectivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
