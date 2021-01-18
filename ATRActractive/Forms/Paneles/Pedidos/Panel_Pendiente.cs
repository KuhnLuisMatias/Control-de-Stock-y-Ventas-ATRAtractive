using ATRActractive.Forms.Planillas;
using Microsoft.Reporting.WinForms;
using Negocio;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATRActractive.Forms.Paneles.Pedidos
{
    public partial class Panel_Pendiente : Form
    {
        private CN_Pedido pedido = new CN_Pedido();

        private CN_Cliente cnCliente = new CN_Cliente();

        private CN_Cadete cadete = new CN_Cadete();

        private Usuario usuario = new Usuario();

        private Planilla_Pedido reportePlanilla = new Planilla_Pedido();

        private bool pedidoSeleccionado;

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Panel_Pendiente()
        {
            InitializeComponent();
        }

        private void Panel_Pendiente_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cargarComboCadetesDisponibles();

            cargarPedidosPendientes();
        }

        private void cargarComboCadetesDisponibles()
        {
            comboCadete.DataSource = cadete.mostrarCadete();
            comboCadete.DisplayMember = "Nombre";
            comboCadete.ValueMember = "ID_PERSONA";

            comboCadete.AutoCompleteCustomSource = cadete.LoadAutoComplete();
            comboCadete.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCadete.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void tablaPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaPedidos.Rows.Count != 0 && tablaPedidos.Rows != null)
            {
                pedidoSeleccionado = true;
                cargarDatosdelPedido();
                cargarDatosdelCliente();
            }
        }

        private void cargarPedidosPendientes()
        {
            tablaPedidos.DataSource = pedido.mostrarPedido(Usuario.getID_USUARIO());
            tablaPedidos.Columns[3].Visible = false;
            tablaPedidos.Columns[4].Visible = false;
            tablaArticulos.DataSource = null;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            lblTotal.Text = "Total $";
        }

        private void cargarDatosdelCliente()
        {
            foreach (DataRow row in pedido.mostrarCliente(tablaPedidos.CurrentRow.Cells[3].Value.ToString()).Rows)
            {
                txtNombre.Text = row[0].ToString();
                txtApellido.Text = row[1].ToString();
                txtDireccion.Text = row[2].ToString();
                txtTelefono.Text = row[3].ToString();
                txtCelular.Text = row[4].ToString();
            }
            lblTotal.Text = "Total $ " + tablaPedidos.CurrentRow.Cells[4].Value.ToString();
        }

        private void cargarDatosdelPedido()
        {
            tablaArticulos.DataSource = pedido.mostrarArticulo(tablaPedidos.CurrentRow.Cells[0].Value.ToString());
        }

        private void imprimirComprobante()
        {
            if (tablaPedidos.Rows.Count != 0 && tablaPedidos.Rows != null)
            {
                DialogResult resultado;
                resultado = MessageBox.Show("¿ Desea imprimir comprobante de pedido ?", "Atención", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    Articulo articulo = new Articulo();

                    reportePlanilla.NumeroPedido = tablaPedidos.CurrentRow.Cells[0].Value.ToString();

                    reportePlanilla.Apellido = txtApellido.Text;

                    reportePlanilla.Nombre = txtNombre.Text;

                    reportePlanilla.Direccion = txtDireccion.Text;

                    reportePlanilla.Telefono = txtTelefono.Text;

                    reportePlanilla.Celular = txtCelular.Text;

                    reportePlanilla.NombreCadete = comboCadete.Text;

                    reportePlanilla.FechaEnvio = String.Format("{0:dd-MM-yyyy}",DateTime.Now);

                    reportePlanilla.PrecioEnvio = txtPrecioEnvio.Text;

                    reportePlanilla.Articulos.Clear();

                    foreach (DataRow row in pedido.mostrarArticulo(tablaPedidos.CurrentRow.Cells[0].Value.ToString()).Rows)
                    {
                        articulo = new Articulo();

                        articulo.Codigo = row[0].ToString();

                        articulo.Descripcion = row[1].ToString();

                        articulo.Cantidad = int.Parse(row[2].ToString());

                        reportePlanilla.Articulos.Add(articulo);
                    }

                    LocalReport rdlc = new LocalReport();

                    rdlc.ReportPath = Path.Combine(Application.StartupPath, "Planilla_Pedido.rdlc");

                    Impresion_Pedido imp = new Impresion_Pedido();

                    imp.ReportePlanilla = reportePlanilla;

                    imp.DatosArticulosPlanilla = reportePlanilla.Articulos;

                    imp.Imprime(rdlc);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tablaPedidos.Rows.Count != 0 && tablaPedidos.Rows != null && !string.IsNullOrEmpty(comboCadete.Text))
            {
                if (pedidoSeleccionado)
                {
                    if (txtPrecioEnvio.Text == string.Empty)
                    {
                        errorIcono.Clear();
                        errorIcono.SetError(txtPrecioEnvio, "Ingrese Precio envío");
                        txtPrecioEnvio.Focus();
                    }

                    else {
                        
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");

                    pedido.asignarCadete(comboCadete.SelectedValue.ToString(), tablaPedidos.CurrentRow.Cells[0].Value.ToString(), fecha,txtPrecioEnvio.Text);

                    imprimirComprobante();

                    cargarPedidosPendientes();

                    pedidoSeleccionado = false;
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (tablaPedidos.Rows.Count != 0 && tablaPedidos.Rows != null)
            {
                DialogResult resultado;
                resultado = MessageBox.Show("¿ Esta seguro que desea Cancelar el pedido ?"
                    + "\n\n\t Pedido # " + tablaPedidos.CurrentRow.Cells[0].Value.ToString()
                    + "\n\n\t Nombre : " + tablaPedidos.CurrentRow.Cells[1].Value.ToString()
                    + " " + tablaPedidos.CurrentRow.Cells[2].Value.ToString()
                    + "\n\n\t Fecha : " + DateTime.Parse(tablaPedidos.CurrentRow.Cells[5].Value.ToString()).ToShortDateString()
                    , "Atención", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    pedido.cancelarPedido(tablaPedidos.CurrentRow.Cells[0].Value.ToString(), tablaPedidos.CurrentRow.Cells[3].Value.ToString());
                    cargarPedidosPendientes();
                    pedidoSeleccionado = false;
                }
            }
        }

        private void Panel_Pendiente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            cargarPedidosPendientes();

            if (txtCodigo.TextLength > 0)
            {
                tablaPedidos.DataSource = pedido.filtrar(txtCodigo.Text);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCodigo.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void tablaPedidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaPedidos.Rows.Count != 0 && tablaPedidos.Rows != null)
            {
                pedidoSeleccionado = true;
                cargarDatosdelPedido();
                cargarDatosdelCliente();
            }
        }

        private void txtPrecioEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPrecioEnvio.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
