using ATRActractive.Forms.Paneles;
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
    public partial class Panel_Pedido : Form
    {
        private CN_Pedido cnPedido = new CN_Pedido();

        private CN_Cliente cnCliente = new CN_Cliente();

        private Pedido pedido;

        private Usuario usuario;

        private bool buscarCliente, modificarCliente, banderaCampos;
  
        public Pedido Pedido { get => pedido; set => pedido = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Panel_Pedido()
        {
            InitializeComponent();
        }

        private void Panel_Pedido_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            dateFechaPedido.MinDate = DateTime.Now;

            nuevoPedido();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            Panel_BuscarCliente buscar = new Panel_BuscarCliente();

            buscar.ShowDialog();

            if (buscar.SelectedB)
            {
                buscarCliente = true;

                txtNombre.Text = buscar.Cliente2.Nombre;

                txtApellido.Text = buscar.Cliente2.Apellido;

                txtCelular.Text = buscar.Cliente2.Celular;

                txtDireccion.Text = buscar.Cliente2.Direccion;

                txtTelefono.Text = buscar.Cliente2.Telefono;

                Pedido.Cliente.Id_cliente = buscar.Cliente2.Id_cliente;

                lblIDCliente.Text = "Cliente #" + Pedido.Cliente.Id_cliente;

            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Panel_BuscarArticulo buscar = new Panel_BuscarArticulo();
                buscar.filtrarProducto(txtCodigo.Text);
                buscar.ShowDialog();

                if (buscar.Selected)
                {
                    Pedido.addArticulos(buscar.Articulo2);
                    tablaArticulos.DataSource = Pedido.tablaArticulos();
                }

                lblTotal.Text = Pedido.sumarListado().ToString();

                lblDescuento.Text = Pedido.MontoPorcentaje.ToString();
            }
        }

        private void tablaArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                DialogResult resultado;
                if (e.KeyChar == (char)Keys.Back)

                {
                    resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaArticulos.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        Pedido.eliminarArticulo(tablaArticulos.CurrentRow.Cells[0].Value.ToString());
                        tablaArticulos.DataSource = Pedido.tablaArticulos();
                        lblTotal.Text = Pedido.sumarListado().ToString();

                        lblDescuento.Text = Pedido.MontoPorcentaje.ToString();
                    }
                }
            }

        }

        private void tablaArticulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            int cantidad;
            if (tablaArticulos.Columns[e.ColumnIndex].Index == 2)
            {
                codigo = tablaArticulos.Rows[e.RowIndex].Cells[0].Value.ToString();
                cantidad = int.Parse(tablaArticulos.Rows[e.RowIndex].Cells[2].Value.ToString());
                Pedido.modificarArticulo(codigo, cantidad);
                tablaArticulos.DataSource = Pedido.tablaArticulos();
                lblTotal.Text = Pedido.sumarListado().ToString();
                lblDescuento.Text = Pedido.MontoPorcentaje.ToString();
            }
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                verificarCampos();

                if (banderaCampos) { guardarPedido(); }
            }
            else
            {
                MessageBox.Show("No es posible reserva de pedidos sin artículos , ni clientes","Atención");
            }

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (buscarCliente) modificarCliente = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (buscarCliente) modificarCliente = true;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (buscarCliente) modificarCliente = true;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (buscarCliente) modificarCliente = true;
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            if (buscarCliente) modificarCliente = true;
        }

        private void verificarCampos()
        {
            if (txtApellido.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtApellido, "Ingrese Apellido");
                txtApellido.Focus();
            }
            else if (txtNombre.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtNombre, "Ingrese Nombre");
                txtNombre.Focus();
            }
            else if (txtDireccion.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtDireccion, "Ingrese Dirección");
                txtDireccion.Focus();
            }
            else if (txtCelular.Text == string.Empty)
            {
                errorIcono.Clear();
                errorIcono.SetError(txtCelular, "Ingrese Celular");
                txtCelular.Focus();
            }
            else { banderaCampos = true; }
        }

        private void nuevoCliente()
        {
            cnCliente.insertar(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, Usuario.getID_USUARIO().ToString());

            Pedido.Cliente.Id_cliente = cnCliente.obtenerIDCliente(Usuario.getID_USUARIO().ToString());
        }

        private void insertarPedido()
        {
            MessageBox.Show(cnPedido.insertarPedido(Usuario.getID_USUARIO().ToString(), Pedido.Cliente.Id_cliente, Pedido.Fecha, "2", Pedido.Total.ToString(),Usuario.getIdCaja()), "Atención");

            cnPedido.insertarDetalle(Pedido.Articulos, Usuario.getID_USUARIO().ToString());

            
        }

        private void Panel_Pedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtTelefono.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCelular.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            Panel_Descuento panel = new Panel_Descuento();

            panel.ShowDialog();

            if (panel.Bandera == 1)
            {
                Pedido.DescuentooPorcentaje = float.Parse(panel.Monto);

                Pedido.sumarListado();

                lblTotal.Text = pedido.sumarListado().ToString();

                lblDescuento.Text = Pedido.MontoPorcentaje.ToString();
            }
        }

        private void nuevoPedido()
        {
            Pedido = new Pedido();

            txtNombre.Text = "";

            txtApellido.Text = "";

            txtDireccion.Text = "";

            txtTelefono.Text = "";

            txtCelular.Text = "";

            lblIDCliente.Text = "";

            lblTotal.Text = "0";

            lblDescuento.Text = "0";

            tablaArticulos.DataSource = Pedido.tablaPresentacion();

            tablaArticulos.ReadOnly = false;

            tablaArticulos.Columns[0].Width = 56;

            tablaArticulos.Columns[0].ReadOnly = true;

            tablaArticulos.Columns[1].Width = 285;

            tablaArticulos.Columns[1].ReadOnly = true;

            tablaArticulos.Columns[2].Width = 65;

            tablaArticulos.Columns[2].ReadOnly = false;

            tablaArticulos.Columns[3].Width = 60;

            tablaArticulos.Columns[3].ReadOnly = true;

            tablaArticulos.Columns[4].Width = 70;

            tablaArticulos.Columns[4].ReadOnly = true;

            tablaArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tablaArticulos.RowHeadersVisible = false;
        }

        private void guardarPedido()
        {
            Pedido.Fecha = String.Format("{0:yyyy-MM-dd}", dateFechaPedido.Value);

            Pedido.Usuario = Usuario;

            if (!buscarCliente)
            {
                nuevoCliente();

                insertarPedido();

                nuevoPedido();
            }
            else
            {
                buscarCliente = false;

                if (modificarCliente)
                {
                    cnCliente.modificar(Pedido.Cliente.Id_cliente, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text);

                    modificarCliente = false;
                }

                insertarPedido();

                nuevoPedido();
            }
        }
    }
}
