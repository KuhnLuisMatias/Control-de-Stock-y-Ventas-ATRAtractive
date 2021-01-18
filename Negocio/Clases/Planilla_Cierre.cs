using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Planilla_Cierre
    {
        private string fechaDesde;

        private string fechaHasta;

        private string hora;

        private string vendedor;

        private string ventasRealizadas;

        private string pedidosRealizados;

        private string totalVendidoEfectivo;

        private string totalVendidoDebito;

        private string totalVendidoCredito;

        private string totalVendidoCBU;

        private string totalVendidoMercadoPago;

        public string FechaDesde { get => fechaDesde; set => fechaDesde = value; }

        public string FechaHasta { get => fechaHasta; set => fechaHasta = value; }

        public string Hora { get => hora; set => hora = value; }

        public string Vendedor { get => vendedor; set => vendedor = value; }

        public string VentasRealizadas { get => ventasRealizadas; set => ventasRealizadas = value; }

        public string PedidosRealizados { get => pedidosRealizados; set => pedidosRealizados = value; }

        public string TotalVendidoEfectivo { get => totalVendidoEfectivo; set => totalVendidoEfectivo = value; }

        public string TotalVendidoDebito { get => totalVendidoDebito; set => totalVendidoDebito = value; }

        public string TotalVendidoCredito { get => totalVendidoCredito; set => totalVendidoCredito = value; }

        public string TotalVendidoCBU { get => totalVendidoCBU; set => totalVendidoCBU = value; }

        public string TotalVendidoMercadoPago { get => totalVendidoMercadoPago; set => totalVendidoMercadoPago = value; }
    }

}
