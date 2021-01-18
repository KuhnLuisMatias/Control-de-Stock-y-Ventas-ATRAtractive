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
    public partial class Panel_Descuento : Form
    {
        private string monto;

        private int bandera;

        public Panel_Descuento()
        {
            InitializeComponent();
        }

        public string Monto { get => monto; set => monto = value; }

        public int Bandera { get => bandera; set => bandera = value; }

        private void Panel_Descuento_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPorcentaje.Text != "")
            {
                bandera = 1;

                monto = txtPorcentaje.Text;

                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
            
        }


        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPorcentaje.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Panel_Descuento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            if (txtPorcentaje.Text != "")
            {
                if (decimal.Parse(txtPorcentaje.Text) >= 0 && decimal.Parse(txtPorcentaje.Text) <= 100)
                {

                }
                else
                {
                    MessageBox.Show("Ingrese valor de un rango de 0 a 100", "Atención");

                    txtPorcentaje.Text = "";
                }
            }
        }
    }
}
