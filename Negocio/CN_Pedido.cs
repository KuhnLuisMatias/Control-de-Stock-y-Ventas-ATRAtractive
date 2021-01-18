using Datos;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class CN_Pedido
    {
        CD_Pedido pedido = new CD_Pedido();

        public DataTable mostrarPedido(string usuario)
        {
            return pedido.mostrar(usuario);
        }

        public DataTable mostrarArticulo(string id_pedido)
        {
            return pedido.mostrarArticulos(id_pedido);
        }

        public DataTable mostrarCliente(string id_cliente)
        {
            return pedido.mostrarCliente(id_cliente);
        }

        public DataTable mostrarAsignados(string usuario)
        {
            return pedido.mostrarAsignados(usuario);
        }

        public DataTable filtrar(string codigo)
        {
            return pedido.filtrar(codigo);
        }

        public DataTable filtrarAsignados(string codigo)
        {
            return pedido.filtrarAsignados(codigo);
        }

        public void insertarDetalle(List<Articulo> articulos, string usuario)
        {
            foreach (Articulo aux in articulos)
            {
                pedido.insertarDetalle(pedido.obtenerIDPedido(usuario), aux.Codigo, aux.Cantidad.ToString());
            }
        }

        public void asignarCadete(string usuario, string id_pedido, string fecha,string cadeteEnvio)
        {
            pedido.asignarCadete(usuario, id_pedido, fecha,cadeteEnvio);
        }

        public void cancelarPedido(string id_pedido, string id_Cliente)
        {
            pedido.cancelarPedido(id_pedido, id_Cliente);
        }

        public string insertarPedido(string usuario, string persona, string fecha, string estado, string precio, string idCaja)
        {
            return pedido.insertarPedido(usuario, persona, fecha, estado, precio, idCaja);
        }

        public string actualizarEstadoPedido(string idPedido,string monto,string idUsuario,string idCaja)
        {
            return pedido.actualizarEstadoPedido(idPedido,monto,idUsuario,idCaja);
        }

        public string actualizarEstadoPedidoTarjetaCBU(string idPedido,string tarjeta, string cuotas, string referencia, string importe, string tipoPago,string idCaja)
        {
            return pedido.actualizarEstadoPedidoTarjeta(idPedido,tarjeta, cuotas, referencia, importe, tipoPago,idCaja);
        }

        public string[] detallesPedido(string idPedido)
        {
            return pedido.detallesDelPedido(idPedido);
        }
    }
}
