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
    public partial class Panel_CBU : Form
    {
        private Usuario usuario = new Usuario();

        private CN_Venta cnVenta = new CN_Venta();

        private CN_Estado cnEstado = new CN_Estado();

        private Venta venta = new Venta();

        private bool ventaCBU;

        public Panel_CBU()
        {
            InitializeComponent();
        }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public CN_Venta CnVenta { get => cnVenta; set => cnVenta = value; }

        public Venta Venta { get => venta; set => venta = value; }

        public bool VentaCBU { get => ventaCBU; set => ventaCBU = value; }

        private void Panel_CBU_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            cagarEstadosCBU();
        }

        private void cagarEstadosCBU()
        {
            comboTransferencia.DataSource = cnEstado.tipoTransferencia();

            comboTransferencia.DisplayMember = "DESCRIPCION";

            comboTransferencia.ValueMember = "ID_TIPOPAGO";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTransferencia.TextLength > 0)
            {
                VentaCBU = true;

                cnVenta.insertarVenta(Venta.Usuario.getID_USUARIO(), Venta.Total.ToString(), Venta.Usuario.getIdCaja());

                cnVenta.insertarDetalle(Venta.Articulos, Venta.Usuario.getID_USUARIO());

                cnVenta.insertarPagoDetalleCBU(txtTransferencia.Text, Venta.Total.ToString(), cnVenta.obtenerIDVenta(venta.Usuario.getID_USUARIO()),comboTransferencia.SelectedValue.ToString());

                cnVenta.descontarStock(Venta.Articulos);

                this.Dispose();
            }
        }

        private void Panel_CBU_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

    }
}
