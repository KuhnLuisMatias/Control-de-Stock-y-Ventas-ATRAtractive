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
    public partial class ABM_Articulo : Form
    {
        CN_Articulo articulo = new CN_Articulo();

        CN_Categoria categoria = new CN_Categoria();

        Usuario usuario = new Usuario();

        private string codigo, descripcion, precio_compra, precio_venta, cantidad, id_tipo;

        private bool bandera;
              
        public ABM_Articulo()
        {
            InitializeComponent();
        }

        public bool Bandera { get => bandera; set => bandera = value; }

        public string Codigo { get => codigo; set => codigo = value; }

        public string Descripcion { get => descripcion; set => descripcion = value; }

        public string Precio_compra { get => precio_compra; set => precio_compra = value; }

        public string Precio_venta { get => precio_venta; set => precio_venta = value; }

        public string Cantidad { get => cantidad; set => cantidad = value; }

        public string Id_tipo { get => id_tipo; set => id_tipo = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtStock.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void ABM_Articulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtPriceSold_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPriceSold.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPriceBuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPriceBuy.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtCode, "Ingrese Codigo");
                txtCode.Focus();
            }
            else if (txtDescription.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtDescription, "Ingrese Nombre");
                txtDescription.Focus();
            }
            else if (txtPriceBuy.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtPriceBuy, "Ingrese Precio de Compra");
                txtPriceBuy.Focus();
            }
            else if (txtPriceSold.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtPriceSold, "Ingrese Precio de Venta");
                txtPriceSold.Focus();
            }
            else if (txtStock.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtStock, "Ingrese Stock");
                txtStock.Focus();
            }
            else
            {
                if (bandera == true)
                {
                    MessageBox.Show(articulo.modificar(txtCode.Text, txtDescription.Text, txtPriceBuy.Text, txtPriceSold.Text, txtStock.Text, comboCategory.SelectedValue.ToString(),usuario.getID_USUARIO()), "Atención");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(articulo.insertar(txtCode.Text, txtDescription.Text, txtPriceBuy.Text, txtPriceSold.Text, txtStock.Text, comboCategory.SelectedValue.ToString(),usuario.getID_USUARIO()), "Atención");
                    txtCode.Text = "";
                    txtDescription.Text = "";
                    txtPriceBuy.Text = "";
                    txtPriceSold.Text = "";
                    txtStock.Text = "";
                }
            }
        }

        private void ABM_Articulo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            comboCategory.DataSource = categoria.mostrar();

            comboCategory.DisplayMember = "DESCRIPCION";

            comboCategory.ValueMember = "ID_TIPOARTICULO";

            comboCategory.AutoCompleteCustomSource = categoria.LoadAutoComplete();

            comboCategory.AutoCompleteMode = AutoCompleteMode.Suggest;

            comboCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (bandera == true)
            {
                txtCode.Enabled = false;

                btnSave.Text = "Modificar";

                txtCode.Text = Codigo;

                txtDescription.Text = Descripcion;

                txtPriceBuy.Text = Precio_compra;

                txtPriceSold.Text = Precio_venta;

                txtStock.Text = Cantidad;

                comboCategory.SelectedValue = Id_tipo;

                txtStock.ForeColor = Color.Red;

            }
        }
    }
}
