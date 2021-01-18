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
    public partial class Panel_Categoria : Form
    {
        CN_Categoria cn = new CN_Categoria();

        private bool categoriaSeleccionado;

        public Panel_Categoria()
        {
            InitializeComponent();
        }

        private void Panel_Categoria_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            cargarCategorias();
        }

        private void cargarCategorias()
        {
            tablaCategoria.DataSource = cn.mostrar();
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 295;
            tablaCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaCategoria.EditMode = DataGridViewEditMode.EditProgrammatically;
            tablaCategoria.RowHeadersVisible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.Rows.Count != 0 && tablaCategoria.Rows != null)
            {
                if (categoriaSeleccionado)
                {
                    DialogResult resultado;
                    resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaCategoria.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(cn.eliminar(tablaCategoria.CurrentRow.Cells[0].Value.ToString()), "Atención");
                        cargarCategorias();
                    }
                    categoriaSeleccionado = false;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cn.insertar(txtCategoria.Text);
            cargarCategorias();
            txtCategoria.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Panel_Categoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void tablaCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCategoria.Rows.Count != 0 && tablaCategoria.Rows != null)
            {
                categoriaSeleccionado = true;
            }
        }

        private void tablaCategoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaCategoria.Rows.Count != 0 && tablaCategoria.Rows != null)
            {
                categoriaSeleccionado = true;
            }
        }
    }
}
