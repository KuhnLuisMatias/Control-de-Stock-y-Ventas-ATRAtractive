using Negocio.Clases;
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
    public partial class Panel_Articulo : Form
    {
        private CN_Articulo cnArticulo = new CN_Articulo();

        private Usuario usuario = new Usuario();

        private bool articuloSeleccionado;

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Panel_Articulo()
        {
            InitializeComponent();
        }

        private void Panel_Articulo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            mostrarArticulos();

            tablaArticulos.Columns[5].Visible = false;

            tablaArticulos.Columns[0].Width = 70;
            tablaArticulos.Columns[1].Width = 300;
            tablaArticulos.Columns[2].Width = 70;
            tablaArticulos.Columns[3].Width = 70;
            tablaArticulos.Columns[4].Width = 70;
            tablaArticulos.Columns[6].Width = 70;
            tablaArticulos.Columns[7].Width = 70;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                if (articuloSeleccionado)
                {
                    ABM_Articulo abm = new ABM_Articulo();

                    abm.Usuario = usuario;

                    abm.Bandera = true;

                    abm.Codigo = tablaArticulos.CurrentRow.Cells[0].Value.ToString();

                    abm.Descripcion = tablaArticulos.CurrentRow.Cells[1].Value.ToString();

                    abm.Precio_compra = tablaArticulos.CurrentRow.Cells[2].Value.ToString();

                    abm.Precio_venta = tablaArticulos.CurrentRow.Cells[3].Value.ToString();

                    abm.Cantidad = tablaArticulos.CurrentRow.Cells[4].Value.ToString();

                    abm.Id_tipo = tablaArticulos.CurrentRow.Cells[5].Value.ToString();

                    abm.ShowDialog();

                    mostrarArticulos();

                    articuloSeleccionado = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ABM_Articulo abmArticulo = new ABM_Articulo();

            abmArticulo.Usuario = usuario;

            abmArticulo.ShowDialog();

            mostrarArticulos();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                if (articuloSeleccionado)
                {
                    DialogResult resultado;

                    resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaArticulos.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(cnArticulo.eliminar(tablaArticulos.CurrentRow.Cells[0].Value.ToString()));

                        mostrarArticulos();
                    }
                    articuloSeleccionado = false;
                }
            }
        }

        private void mostrarArticulos()
        {
            tablaArticulos.DataSource = cnArticulo.mostrar();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            tablaArticulos.DataSource = cnArticulo.filtrarProducto2(txtBusqueda.Text);
        }

        private void Panel_Articulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void tablaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                articuloSeleccionado = true;
            }
        }

        private void tablaArticulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                articuloSeleccionado = true;
            }
        }

        private void tablaArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Color red = Color.FromArgb(255, 143, 0);
            #region Columna Verde
            if (this.tablaArticulos.Columns[e.ColumnIndex].Name == "Stock Disponible")

                try
                {

                    if (e.Value.GetType() != typeof(DBNull))

                    {
                        if (e.Value != DBNull.Value)
                        {

                            if (Double.Parse(e.Value.ToString()) >= 6)
                            {
                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.BackColor = Color.GreenYellow;
                            }

                            if (Double.Parse(e.Value.ToString()) <= 3)
                            {
                                e.CellStyle.ForeColor = Color.White;
                                e.CellStyle.BackColor = Color.Crimson;
                            }

                            if (Double.Parse(e.Value.ToString()) > 3 && Double.Parse(e.Value.ToString()) < 6)
                            {
                                e.CellStyle.ForeColor = Color.White;
                                e.CellStyle.BackColor = red;
                            }

                        }
                    }


                }

                catch (NullReferenceException)
                {

                }
            #endregion


            #region Columna Nombres
            if (this.tablaArticulos.Columns[e.ColumnIndex].Name == "Vendedor")

                try
                {

                    if (e.Value.GetType() != typeof(DBNull))

                    {
                        if (e.Value != DBNull.Value)
                        {

                            if (e.Value.ToString().Equals("Fer"))
                            {
                                e.CellStyle.ForeColor = Color.Blue;
                            }

                            if (e.Value.ToString().Equals("Gaby"))
                            {
                                e.CellStyle.ForeColor = Color.Crimson;
                            }


                        }
                    }


                }

                catch (NullReferenceException)
                {

                }
            #endregion
        }
    }
}
