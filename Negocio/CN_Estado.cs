using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class CN_Estado
    {
        CD_Estado estado = new CD_Estado();

        public DataTable estadoPedido()
        {
            return estado.estadoPedido();
        }

        public DataTable estadoPedidoVendido()
        {
            return estado.estadoPedidoVendido();
        }

        public DataTable estadoVenta()
        {
            return estado.estadoVenta();
        }

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            return estado.LoadAutoComplete();
        }

        public DataTable tipoTransferencia()
        {
            return estado.tipoTransferencia();
        }

        public void modificarEstado(string id_pedido, string id_cliente, string id_Estado)
        {
            estado.modificarEstado(id_pedido,id_cliente,id_Estado);
        }

    }
}
