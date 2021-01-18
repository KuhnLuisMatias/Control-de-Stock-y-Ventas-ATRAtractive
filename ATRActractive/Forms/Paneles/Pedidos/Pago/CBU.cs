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

namespace ATRActractive.Forms.Paneles.Pedidos.Pago
{
    public partial class CBU : Form
    {
        private Usuario usuario = new Usuario();

        private CN_Pedido pedido = new CN_Pedido();

        private CN_Estado cnEstado = new CN_Estado();

        private bool pagoCBU;

        private string importe,idPedido;

        public bool PagoCBU { get => pagoCBU; set => pagoCBU = value; }

        public string Importe { get => importe; set => importe = value; }

        public string IdPedido { get => idPedido; set => idPedido = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public CBU()
        {
            InitializeComponent();
        }

        private void CBU_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cargarTiposTransferencias();

        }

        private void cargarTiposTransferencias()
        {
            comboTransferencia.DataSource = cnEstado.tipoTransferencia();

            comboTransferencia.DisplayMember = "DESCRIPCION";

            comboTransferencia.ValueMember = "ID_TIPOPAGO";
        }

        private void CBU_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTransferencia.TextLength > 0)
            {
                pagoCBU = true;

                pedido.actualizarEstadoPedidoTarjetaCBU(idPedido, "17", "0", txtTransferencia.Text, importe, comboTransferencia.SelectedValue.ToString(), usuario.getIdCaja());

                this.Dispose();
            }
        }
    }
}
