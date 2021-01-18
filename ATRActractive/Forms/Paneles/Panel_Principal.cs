using ATRActractive.Forms;
using ATRActractive.Forms.Paneles;
using ATRActractive.Forms.Paneles.Caja;
using ATRActractive.Forms.Paneles.Pedidos;
using ATRActractive.Forms.Paneles.Ventas;
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

namespace ATRActractive
{

    public partial class Panel_Principal : Form
    {
        private CN_Venta cnVenta = new CN_Venta();

        private CN_Caja cnCaja = new CN_Caja();

        private Usuario usuario = new Usuario();

        private Venta venta = new Venta();

        private bool articuloSeleccionado, banderaCaja;

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Venta Venta { get => venta; set => venta = value; }

        public Panel_Principal(string[] datos)
        {
            InitializeComponent();

            cargarUsuario(datos);

        }

        private void cargarUsuario(string[] datos)
        {
            usuario.setID_USUARIO(datos[0].ToString());

            usuario.setNombre(datos[1].ToString());

            lblUser.Text = Usuario.getNombre();
        }

        private void nuevaVenta()
        {
            lblTotal.Text = "Total : $ 0";

            lblDescuento.Text = "0";

            tablaArticulos.DataSource = Venta.tablaPresentacion();

            Venta = new Venta();

            Venta.Usuario = Usuario;

        }

        private void guardarVentaEfectivo()
        {
            cnVenta.insertarVenta(Venta.Usuario.getID_USUARIO(), Venta.Total.ToString(),Usuario.getIdCaja());

            cnVenta.insertarDetalle(Venta.Articulos, Venta.Usuario.getID_USUARIO());

            cnVenta.insertarPagoDetalleEfectivo(Venta.MontoEfectivo.ToString(), cnVenta.obtenerIDVenta(Venta.Usuario.getID_USUARIO()));

            cnVenta.descontarStock(Venta.Articulos);

            nuevaVenta();
        }

        private void abrirCaja()
        {
            Panel_AbrirCaja pAbrirCaja = new Panel_AbrirCaja();

            pAbrirCaja.IdUsuario = Usuario.getID_USUARIO();

            pAbrirCaja.ShowDialog();

            if (pAbrirCaja.EstadoCaja)
            {
                banderaCaja = true;

                btnCaja.Text = "Cerrar Caja";

                btnCaja.ForeColor = Color.Red;

                Usuario.setIdCaja(cnCaja.ultimoIDCaja(Usuario.getID_USUARIO()));
            }
        }

        private void cargarEstadoUltimaCaja()
        {
            banderaCaja = cnCaja.estadoUltimaCaja(Usuario.getID_USUARIO());

            if (banderaCaja)
            {
                btnCaja.Text = "Cerrar Caja";

                btnCaja.ForeColor = Color.Red;

                Usuario.setIdCaja(cnCaja.ultimoIDCaja(Usuario.getID_USUARIO()));
            }

        }

        private void Panel_Principal_Load(object sender, EventArgs e)
        {
            tablaArticulos.DataSource = Venta.tablaPresentacion();

            tablaArticulos.ReadOnly = false;

            tablaArticulos.Columns[0].Width = 46;

            tablaArticulos.Columns[0].ReadOnly = true;

            tablaArticulos.Columns[1].Width = 295;

            tablaArticulos.Columns[1].ReadOnly = true;

            tablaArticulos.Columns[2].Width = 60;

            tablaArticulos.Columns[2].ReadOnly = false;

            tablaArticulos.Columns[3].Width = 60;

            tablaArticulos.Columns[3].ReadOnly = true;

            tablaArticulos.Columns[4].Width = 70;

            tablaArticulos.Columns[4].ReadOnly = true;

            tablaArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tablaArticulos.RowHeadersVisible = false;

            nuevaVenta();

            Venta.Usuario = Usuario;

            cargarEstadoUltimaCaja();
        }

        private void verStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_Articulo pArticulo = new Panel_Articulo();

            pArticulo.Usuario = usuario;

            pArticulo.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_Categoria pCategoria = new Panel_Categoria();
            pCategoria.ShowDialog();
        }

        private void modificarCadetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_Cadete pCadete = new Panel_Cadete();
            pCadete.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_Cliente pCliente = new Panel_Cliente();
            pCliente.Usuario = Usuario.getID_USUARIO();
            pCliente.ShowDialog();
        }

        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                Panel_Pedido pedido = new Panel_Pedido();

                pedido.Usuario = Usuario;

                pedido.ShowDialog();
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void pendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                Panel_Pendiente pPendiente = new Panel_Pendiente();

                pPendiente.Usuario = usuario;

                pPendiente.ShowDialog();
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void entregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                Panel_Entregados pEntregados = new Panel_Entregados();

                pEntregados.Usuario = usuario;

                pEntregados.Show();
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Panel_BuscarArticulo buscar = new Panel_BuscarArticulo();

                buscar.filtrarProducto(txtCodigo.Text);

                buscar.ShowDialog();

                if (buscar.Selected)
                {
                    Venta.addArticulos(buscar.Articulo2);

                     tablaArticulos.DataSource = Venta.tablaArticulos();
                }

                lblTotal.Text = "Total : $ " + Venta.sumarListado().ToString();

                lblDescuento.Text = Venta.MontoPorcentaje.ToString();
            }
        }

        private void tablaArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                if (articuloSeleccionado)
                {
                    DialogResult resultado;
                    if (e.KeyChar == (char)Keys.Back)

                    {
                        resultado = MessageBox.Show("¿ Esta seguro que desea eliminar : " + tablaArticulos.CurrentRow.Cells[1].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
                        if (resultado == DialogResult.Yes)
                        {
                            Venta.eliminarArticulo(tablaArticulos.CurrentRow.Cells[0].Value.ToString());

                            tablaArticulos.DataSource = Venta.tablaArticulos();

                            lblTotal.Text = "Total : $ " + Venta.sumarListado().ToString();

                            lblDescuento.Text = Venta.MontoPorcentaje.ToString();
                        }
                    }
                    articuloSeleccionado = false;
                }
            }
        }

        private void tablaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                articuloSeleccionado = true;
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

                Venta.modificarArticulo(codigo, cantidad);

                tablaArticulos.DataSource = Venta.tablaArticulos();

                lblTotal.Text = "Total : $ " + Venta.sumarListado().ToString();

                lblDescuento.Text = Venta.MontoPorcentaje.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nuevaVenta();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    Panel_Vuelto pVuelto = new Panel_Vuelto();

                    pVuelto.Total = Venta.Total;

                    pVuelto.ShowDialog();

                    if (pVuelto.Venta)
                    {
                        Venta.MontoEfectivo = venta.Total;

                        guardarVentaEfectivo();
                    }
                }
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }

        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    Panel_Tarjeta pTarjeta = new Panel_Tarjeta();

                    pTarjeta.Venta.Usuario = Usuario;

                    pTarjeta.Venta = Venta;

                    pTarjeta.ShowDialog();

                    if (pTarjeta.VentaTarjeta)
                    {
                        nuevaVenta();
                    }
                }
            }
            else
            {
                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {

                DialogResult resultado;

                resultado = MessageBox.Show("\t     CAJA ABIERTA\n\t¿ Desea cerrar caja ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    Panel_CerrarCaja pCerrarCaja = new Panel_CerrarCaja();

                    pCerrarCaja.Usuario = usuario;

                    pCerrarCaja.ShowDialog();

                    if (pCerrarCaja.CierreCaja)
                    {
                        this.Dispose();
                    }
                }
                else
                { this.Dispose(); }
            }
            else
            { this.Dispose(); }
        }

        private void ventasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_Ventas pVentas = new Panel_Ventas();

            pVentas.ShowDialog();
        }

        private void btnCBU_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    Panel_CBU pCBU = new Panel_CBU();

                    pCBU.Usuario = usuario;

                    pCBU.Venta = venta;

                    pCBU.ShowDialog();

                    if (pCBU.VentaCBU)
                    {
                        nuevaVenta();
                    }
                }
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void tablaArticulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
            {
                articuloSeleccionado = true;
            }
        }

        private void retirarDineoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                Panel_Retirar pRetirar = new Panel_Retirar();

                pRetirar.Usuario = usuario;

                pRetirar.ShowDialog();
            }
            else
            {
                abrirCaja();
            }
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                if (tablaArticulos.Rows.Count != 0 && tablaArticulos.Rows != null)
                {
                    Panel_Descuento panel = new Panel_Descuento();

                    panel.ShowDialog();

                    if (panel.Bandera == 1)
                    {
                        Venta.DescuentooPorcentaje = float.Parse(panel.Monto);

                        Venta.sumarListado();

                        lblTotal.Text = "Total : $ " + Venta.sumarListado().ToString();

                        lblDescuento.Text = Venta.MontoPorcentaje.ToString();
                    }
                }
            }
            else
            {

                DialogResult resultado;

                resultado = MessageBox.Show("¿ Desea abrir caja para continuar la operación ?", "Atención", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    abrirCaja();
                }
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            if (banderaCaja)
            {
                Panel_CerrarCaja pCerrarCaja = new Panel_CerrarCaja();

                pCerrarCaja.Usuario = usuario;

                pCerrarCaja.ShowDialog();

                if (pCerrarCaja.CierreCaja)
                {
                    banderaCaja = false ;

                    btnCaja.Text = "Abrir Caja";

                    btnCaja.ForeColor = Color.Black;
                }

            }
            else
            {
                abrirCaja();
            }
        }
    }

}
