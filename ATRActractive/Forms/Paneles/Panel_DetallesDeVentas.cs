using ATRActractive.Forms.Paneles.Pedidos;
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
    public partial class Panel_DetallesDeVentas : Form
    {
        private CN_Venta cnVenta = new CN_Venta();

        private CN_Pedido cnPedido = new CN_Pedido();

        private Pedido pedido = new Pedido();

        private bool tipoPedido;

        public Pedido Pedido { get => pedido; set => pedido = value; }

        public bool TipoPedido { get => tipoPedido; set => tipoPedido = value; }

        public Panel_DetallesDeVentas()
        {
            InitializeComponent();
        }

        private void Panel_DetallesDeVentas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cargarVentas();
        }

        private void cargarVentas()
        {

            lblFecha.Text =   DateTime.Parse(pedido.Fecha).ToShortDateString();

            lblHora.Text = pedido.Hora;

            lblNumero.Text = pedido.NumeroPedido;

            lblTipoVenta.Text = pedido.TipoPedido;

            lblFormaDePago.Text = pedido.TipoPago;

            lblReferenciaDePago.Text = pedido.ReferenciaPago;

            lblTotal.Text = "$ "+ pedido.Total.ToString();

            lblNombreCliente.Text = pedido.Cliente.Apellido + " " + pedido.Cliente.Nombre;

            lblDireccionCliente.Text = pedido.Cliente.Direccion;

            lblTelefonoCliente.Text = pedido.Cliente.Telefono;

            lblCelularCliente.Text = pedido.Cliente.Celular;

            lblVendedor.Text = pedido.Usuario.getNombre();

            tablaArticulos.DataSource = cnPedido.mostrarArticulo(pedido.NumeroPedido);
        }

        private void Panel_DetallesDeVentas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Panel_Estado estadoVenta = new Panel_Estado();

            estadoVenta.Id_pedido = pedido.NumeroPedido;

            estadoVenta.Id_cliente = pedido.Cliente.Id_cliente;

            if (tipoPedido) // SI es Venta 
            {
                estadoVenta.EstadoVenta = true;
            }
            else
            {
                estadoVenta.EstadoPedido = true;
            }

            estadoVenta.ShowDialog();

            this.Dispose();

        }
    }
}
