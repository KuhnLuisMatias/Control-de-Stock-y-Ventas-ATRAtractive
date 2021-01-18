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

namespace ATRActractive.Forms.Paneles.Ventas
{
    public partial class Panel_Ventas : Form
    {
        private CN_Venta cnVenta = new CN_Venta();

        private CN_Pedido cnPedido = new CN_Pedido();

        private CN_Vendedores cnVendedores = new CN_Vendedores();

        private Planilla_Cierre reportePlanilla;

        private Pedido pedido;

        private string desde, hasta, vendedor;

        private string[] detalleDelDia;

        public Panel_Ventas()
        {
            InitializeComponent();
        }

        private void cargarVendedores()
        {
            comboVendedor.DataSource = cnVendedores.mostrarVendedores();

            comboVendedor.DisplayMember = "NOMBRE";

            comboVendedor.ValueMember = "ID_USUARIO";
        }

        private void cargarTipoVentas()
        {
            comboTipoVenta.DataSource = cnVenta.mostrarTipoVentas();

            comboTipoVenta.DisplayMember = "DESCRIPCION";

            comboTipoVenta.ValueMember = "ID_TIPO";
        }

        private void cargarDetallesDelDia()
        {
            desde = String.Format("{0:yyyy-MM-dd}", fechaDesde.Value);

            hasta = String.Format("{0:yyyy-MM-dd}", fechaHasta.Value);

            vendedor = comboVendedor.SelectedValue.ToString();

            string tipoVenta = comboTipoVenta.SelectedValue.ToString();

            detalleDelDia = cnVenta.detallesDelDia(desde, hasta, vendedor,tipoVenta);

            tablaVentas.DataSource = cnVenta.mostrarVentasRealizadas(desde, hasta, vendedor, tipoVenta);

            lblVentas.Text = detalleDelDia[0];

            lblPedidos.Text = detalleDelDia[1];

            lblProductos.Text = detalleDelDia[2];

            lblTotal.Text = detalleDelDia[3];
        }

        private void Panel_Ventas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            fechaHasta.MinDate = fechaDesde.Value;

            cargarVendedores();

            cargarTipoVentas();

            cargarDetallesDelDia();

            tablaVentas.Columns[0].Width = 70;

            tablaVentas.Columns[1].Width = 70;

            tablaVentas.Columns[2].Width = 70;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarDetallesDelDia();
        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {
            fechaHasta.MinDate = fechaDesde.Value;
        }

        private void Panel_Ventas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void tablaVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Color red = Color.FromArgb(255, 143, 0);

            #region Columna Nombres
            if (this.tablaVentas.Columns[e.ColumnIndex].Name == "Vendedor")

                try
                {

                    if (e.Value.GetType() != typeof(DBNull))

                    {
                        if (e.Value != DBNull.Value)
                        {

                            if (e.Value.ToString().Equals("Fer"))
                            {
                                e.CellStyle.ForeColor = Color.Blue;
                            }

                            if (e.Value.ToString().Equals("Gaby"))
                            {
                                e.CellStyle.ForeColor = Color.Crimson;
                            }


                        }
                    }


                }

                catch (NullReferenceException)
                {

                }
            #endregion

        }

        private void tablaVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaVentas.Rows.Count != 0 && tablaVentas.Rows != null)
            {
                string[] datos = new string[14];

                datos = cnPedido.detallesPedido(tablaVentas.CurrentRow.Cells[3].Value.ToString());

                pedido = new Pedido();

                pedido.Fecha = datos[0];

                pedido.Hora = datos[1];

                pedido.NumeroPedido = datos[2];

                pedido.TipoPedido = datos[3];

                pedido.TipoPago = datos[4];

                pedido.ReferenciaPago = datos[5];

                pedido.Total = float.Parse(datos[6]);

                pedido.Usuario.setNombre(datos[7]);

                pedido.Cliente.Nombre = datos[8];

                pedido.Cliente.Apellido = datos[9];

                pedido.Cliente.Direccion = datos[10];

                pedido.Cliente.Telefono = datos[11];

                pedido.Cliente.Celular = datos[12];

                pedido.Cliente.Id_cliente = datos[13];

                Panel_DetallesDeVentas pDetalles = new Panel_DetallesDeVentas();

                if (tablaVentas.CurrentRow.Cells[6].Value.ToString().Equals("Venta"))
                {
                    pDetalles.TipoPedido = true;
                }
                
                pDetalles.Pedido = pedido;
                
                pDetalles.ShowDialog();

                cargarDetallesDelDia();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (tablaVentas.Rows.Count != 0 && tablaVentas.Rows != null)
            {
                DialogResult resultado;
                resultado = MessageBox.Show("¿ Desea imprimir informe ?", "Atención", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    reportePlanilla = new Planilla_Cierre();

                    reportePlanilla.FechaDesde = String.Format("{0:dd-MM-yyyy}", fechaDesde.Value); 

                    reportePlanilla.FechaHasta = String.Format("{0:dd-MM-yyyy}", fechaHasta.Value);

                    reportePlanilla.Vendedor = comboVendedor.Text;

                    reportePlanilla.Hora = DateTime.Now.ToString("h:mm:ss tt");

                    string[] total = cnVenta.detallesReporte(desde, hasta, vendedor);

                    reportePlanilla.VentasRealizadas = detalleDelDia[0];

                    reportePlanilla.PedidosRealizados = detalleDelDia[1];

                    reportePlanilla.TotalVendidoEfectivo = total[0];

                    reportePlanilla.TotalVendidoCredito = total[1];

                    reportePlanilla.TotalVendidoDebito = total[2];

                    reportePlanilla.TotalVendidoCBU = total[3];

                    reportePlanilla.TotalVendidoMercadoPago = total[4];

                    GenerarFactura();
                }
            }
        }

        private void GenerarFactura()
        {
            LocalReport rdlc = new LocalReport();

            rdlc.ReportPath = Path.Combine(Application.StartupPath, "Planilla_CierreCaja.rdlc");

            Impresion imp = new Impresion();

            imp.ReportePlanilla = reportePlanilla;

            imp.Imprime(rdlc);
        }
    }
}
