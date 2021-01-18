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
    public partial class Panel_Retirar : Form
    {
        private Usuario usuario = new Usuario();

        private CN_Caja cnCaja = new CN_Caja();

        private bool movimientoSeleccionado;

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Panel_Retirar()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Panel_Retirar_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cargarMovimientos();
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            if (txtRazon.Text == string.Empty)
            {
                errorIcono.Clear();

                errorIcono.SetError(txtRazon, "Ingrese Razón de extracción");

                txtRazon.Focus();
            }
            else if (txtMonto.Text == string.Empty)
            {
                errorIcono.Clear();

                errorIcono.SetError(txtMonto, "Ingrese Monto");

                txtMonto.Focus();
            }
            else {
                cnCaja.extraerDeCaja(usuario.getID_USUARIO(), usuario.getIdCaja(), txtMonto.Text, txtRazon.Text);

                cargarMovimientos();

                txtMonto.Text = "";
                txtRazon.Text = "";
            }
        }

        private void tablaMovimientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tablaMovimientos.Rows.Count != 0 && tablaMovimientos.Rows != null)
            {
                if (movimientoSeleccionado)
                {
                    DialogResult resultado;

                    if (e.KeyChar == (char)Keys.Back)
                    {
                        resultado = MessageBox.Show("¿ Esta seguro que cancelar el movimiento : " + tablaMovimientos.CurrentRow.Cells[2].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);

                        if (resultado == DialogResult.Yes)
                        {
                            cnCaja.eliminarMovimiento(usuario.getID_USUARIO(),usuario.getIdCaja(),tablaMovimientos.CurrentRow.Cells[4].Value.ToString());

                            cargarMovimientos();
                        }

                        movimientoSeleccionado = false;
                    }
                }
            }
        }

        private void tablaMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaMovimientos.Rows.Count != 0 && tablaMovimientos.Rows != null)
            {
                movimientoSeleccionado = true;
            }
        }

        private void cargarMovimientos()
        {
            tablaMovimientos.DataSource = cnCaja.movimientosCaja(usuario.getID_USUARIO(), usuario.getIdCaja());

            tablaMovimientos.Columns[4].Visible = false;
        }

        private void Panel_Retirar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
