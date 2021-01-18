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
    public partial class Panel_Vuelto : Form
    {
        private bool venta;

        private float total, vuelto,monto;
        
        public Panel_Vuelto()
        {
            InitializeComponent();
        }

        public bool Venta { get => venta; set => venta = value; }

        public float Total { get => total; set => total = value; }

        public float Vuelto { get => vuelto; set => vuelto = value; }

        public float Monto { get => monto; set => monto = value; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            venta = true;
            this.Dispose();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtMonto.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Panel_Vuelto_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Panel_Vuelto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.TextLength > 0)
            {
                monto = float.Parse(txtMonto.Text);
                Vuelto = -1 * (Total - monto);
                lblVuelto.Text = "Vuelto $ " + Vuelto.ToString();
            }
            else
            {
                lblVuelto.Text = "Vuelto $ 0";
            }
        }
    }
}
