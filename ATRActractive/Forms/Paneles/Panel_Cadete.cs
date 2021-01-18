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

namespace ATRActractive.Forms
{
    public partial class Panel_Cadete : Form
    {
        private CN_Cadete cadete = new CN_Cadete();

        private bool cadeteSeleccionado;

        public Panel_Cadete()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaCadetes.Rows.Count != 0 && tablaCadetes.Rows != null)
            {
                if (cadeteSeleccionado)
                {
                    ABM_Persona p = new ABM_Persona();
                    p.Tipo_persona = 2;
                    p.Modificar = true;
                    p.Id_persona = tablaCadetes.CurrentRow.Cells[0].Value.ToString();
                    p.Apellido = tablaCadetes.CurrentRow.Cells[1].Value.ToString();
                    p.Nombre = tablaCadetes.CurrentRow.Cells[2].Value.ToString();
                    p.Direccion = tablaCadetes.CurrentRow.Cells[3].Value.ToString();
                    p.Telefono = tablaCadetes.CurrentRow.Cells[4].Value.ToString();
                    p.Celular = tablaCadetes.CurrentRow.Cells[5].Value.ToString();
                    p.Patente = tablaCadetes.CurrentRow.Cells[6].Value.ToString();
                    p.ShowDialog();
                    mostrarCadetes();
                    cadeteSeleccionado = false;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCadetes.Rows.Count != 0 && tablaCadetes.Rows != null)
            {
                if (cadeteSeleccionado)
                {
                    DialogResult resultado;
            resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaCadetes.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(cadete.eliminar(tablaCadetes.CurrentRow.Cells[0].Value.ToString()), "Atención");
                mostrarCadetes();
            }
                    cadeteSeleccionado = false;
                }
            }
        }

        private void mostrarCadetes()
        {
            tablaCadetes.DataSource = cadete.mostrar();
        }

        private void Panel_Cadete_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            mostrarCadetes();
            tablaCadetes.Columns[0].Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ABM_Persona cadete = new ABM_Persona();
            cadete.Tipo_persona = 2;
            cadete.ShowDialog();
            mostrarCadetes();
        }

        private void Panel_Cadete_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void tablaCadetes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCadetes.Rows.Count != 0 && tablaCadetes.Rows != null)
            {
                cadeteSeleccionado = true;
            }
        }
    }
}
