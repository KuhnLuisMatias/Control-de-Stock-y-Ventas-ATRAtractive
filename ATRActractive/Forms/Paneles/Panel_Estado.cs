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

namespace ATRActractive.Forms.Paneles.Pedidos
{
    public partial class Panel_Estado : Form
    {
        private CN_Estado estado = new CN_Estado();

        private string id_pedido,id_cliente;

        private bool estadoVenta,estadoPedido;

        public string Id_pedido { get => id_pedido; set => id_pedido = value; }

        public string Id_cliente { get => id_cliente; set => id_cliente = value; }

        public bool EstadoVenta { get => estadoVenta; set => estadoVenta = value; }

        public bool EstadoPedido { get => estadoPedido; set => estadoPedido = value; }

        public Panel_Estado()
        {
            InitializeComponent();
        }

        private void Panel_Estado_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            if (estadoVenta)
            {
                cargarEstadosVenta();
            }
            else if (estadoPedido)
            {
                cargarEstadosPedido();
            }
            else
            {
                cargarEstados();
            }
        }

        private void cargarEstadosPedido()
        {
            comboEstado.DataSource = estado.estadoPedidoVendido();
            comboEstado.DisplayMember = "DESCRIPCION";
            comboEstado.ValueMember = "ID_ESTADO";
            comboEstado.AutoCompleteCustomSource = estado.LoadAutoComplete();
            comboEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void cargarEstados()
        {
            comboEstado.DataSource = estado.estadoPedido();
            comboEstado.DisplayMember = "DESCRIPCION";
            comboEstado.ValueMember = "ID_ESTADO";
            comboEstado.AutoCompleteCustomSource = estado.LoadAutoComplete();
            comboEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void cargarEstadosVenta()
        {
            comboEstado.DataSource = estado.estadoVenta();
            comboEstado.DisplayMember = "DESCRIPCION";
            comboEstado.ValueMember = "ID_ESTADO";
            comboEstado.AutoCompleteCustomSource = estado.LoadAutoComplete();
            comboEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Panel_Estado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            estado.modificarEstado(Id_pedido, Id_cliente, comboEstado.SelectedValue.ToString());

            this.Dispose();
        }
    }
}
