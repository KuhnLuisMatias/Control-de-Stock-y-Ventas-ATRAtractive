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

namespace ATRActractive.Forms
{
    public partial class Panel_BuscarArticulo : Form
    {
        private CN_Articulo articulo = new CN_Articulo();

        private Articulo articulo2 = new Articulo();

        private bool selected;

        public bool Selected { get => selected; set => selected = value; }

        public Articulo Articulo2 { get => articulo2; set => articulo2 = value; }

        public Panel_BuscarArticulo()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Panel_BuscarArticulo_Load(object sender, EventArgs e)
        {
            articulo2 = new Articulo();

            tablaArticulos.Columns[0].Width = 60;
            tablaArticulos.Columns[1].Width = 300;
            tablaArticulos.Columns[2].Width = 70;
            tablaArticulos.Columns[3].Width = 70;
            tablaArticulos.Columns[4].Width = 130;
        }

        private void tablaArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    this.Dispose();
                }
            }
        }

        private void tablaArticulos_KeyDown(object sender, KeyEventArgs e)
        {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    Selected = true;

                    articulo2 = new Articulo();

                    Articulo2.Codigo = tablaArticulos.CurrentRow.Cells[0].Value.ToString();

                    Articulo2.Descripcion = tablaArticulos.CurrentRow.Cells[1].Value.ToString();

                    Articulo2.Precio = float.Parse(tablaArticulos.CurrentRow.Cells[2].Value.ToString());
                }
        }

        private void Panel_BuscarArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Panel_BuscarArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Selected = false;

                this.Dispose();
            }
        }

        public void filtrarProducto(string codigo)
        {
           tablaArticulos.DataSource = articulo.filtrarProducto(codigo);
        }

        private void dataListadoProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                Selected = true;

                articulo2 = new Articulo();

                Articulo2.Codigo = tablaArticulos.CurrentRow.Cells[0].Value.ToString();

                Articulo2.Descripcion = tablaArticulos.CurrentRow.Cells[1].Value.ToString();

                Articulo2.Precio = float.Parse(tablaArticulos.CurrentRow.Cells[2].Value.ToString());

                this.Dispose();
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
        }
    }
}
