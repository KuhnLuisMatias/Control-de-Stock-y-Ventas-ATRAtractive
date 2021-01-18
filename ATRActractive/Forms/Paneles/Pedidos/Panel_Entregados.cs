using ATRActractive.Forms.Paneles.Pedidos.Pago;
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

namespace ATRActractive.Forms.Paneles.Pedidos
{
    public partial class Panel_Entregados : Form
    {
        private CN_Pedido pedido = new CN_Pedido();

        private Pedido p = new Pedido();

        private Usuario usuario = new Usuario();

        private bool pedidoSeleccionado;

        public bool PedidoSeleccionado { get => pedidoSeleccionado; set => pedidoSeleccionado = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Panel_Entregados()
        {
            InitializeComponent();
        }

        private void Pane_Entregados_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cargarPedidosAsignados();
        }

        private void cargarPedidosAsignados()
        {
            tablaArticulos.DataSource = null;

            tablaPedidosAsignados.DataSource = pedido.mostrarAsignados(usuario.getID_USUARIO());

            tablaPedidosAsignados.Columns[8].Visible = false;
        }

        private void tablaPedidosAsignados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                pedidoSeleccionado = true;

                tablaArticulos.DataSource = pedido.mostrarArticulo(tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                Panel_Estado pEstado = new Panel_Estado();

                pEstado.Id_cliente = tablaPedidosAsignados.CurrentRow.Cells[8].Value.ToString();

                pEstado.Id_pedido = tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString();

                pEstado.ShowDialog();

                cargarPedidosAsignados();

                tablaArticulos.DataSource = null;
            }
        }

        private void Panel_Entregados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                string idPedido = tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString();

                decimal total = decimal.Parse(tablaPedidosAsignados.CurrentRow.Cells[9].Value.ToString());

                if (pedidoSeleccionado)
                {
                    Efectivo efectivo = new Efectivo();

                    efectivo.IdPedido = idPedido;

                    efectivo.Total = total;

                    efectivo.ShowDialog();

                    if (efectivo.EfectivoIngresado)
                    {
                        pedido.actualizarEstadoPedido(idPedido,total.ToString(),usuario.getID_USUARIO(),usuario.getIdCaja());

                        cargarPedidosAsignados();
                    }
                    pedidoSeleccionado = false;
                }
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                string idPedido = tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString();

                string total = tablaPedidosAsignados.CurrentRow.Cells[9].Value.ToString();

                if (pedidoSeleccionado)
                {
                    Tarjeta tarjeta = new Tarjeta();

                    tarjeta.Importe = total;

                    tarjeta.IdPedido = idPedido;

                    tarjeta.Usuario = usuario;

                    tarjeta.ShowDialog();

                    if (tarjeta.BanderaTarjeta)
                    {
                        cargarPedidosAsignados();
                    }
                    PedidoSeleccionado = false;
                }
            }
        }

        private void btnCBU_Click(object sender, EventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                string idPedido = tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString();

                string total = tablaPedidosAsignados.CurrentRow.Cells[9].Value.ToString();

                if (pedidoSeleccionado)
                {
                    CBU cbu = new CBU();

                    cbu.IdPedido = idPedido;

                    cbu.Importe = total;

                    cbu.Usuario = usuario;

                    cbu.ShowDialog();

                    pedidoSeleccionado = false;

                    if (cbu.PagoCBU)
                    {
                        cargarPedidosAsignados();
                    }
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength > 0)
            {
                tablaPedidosAsignados.DataSource = pedido.filtrarAsignados(txtCodigo.Text);

                tablaPedidosAsignados.Columns[8].Visible = false;
            }
            else
            {
                cargarPedidosAsignados();
            }
        }

        private void tablaPedidosAsignados_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaPedidosAsignados.Rows.Count != 0 && tablaPedidosAsignados.Rows != null)
            {
                pedidoSeleccionado = true;

                tablaArticulos.DataSource = pedido.mostrarArticulo(tablaPedidosAsignados.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
