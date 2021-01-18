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
    public class CN_Venta
    {
        private CD_Venta venta = new CD_Venta();

        string sentencia = "";

        public void insertarVenta(string usuario,string precio,string idCaja)
        {
            venta.insertarVenta(usuario,precio,idCaja);
        }

        public void insertarDetalle(List<Articulo> articulos, string usuario)
        {
            foreach (Articulo aux in articulos)
            {
                venta.insertarDetalle(venta.obtenerIDVenta(usuario), aux.Codigo, aux.Cantidad.ToString());
            }
        }

        public void descontarStock(List<Articulo> articulos)
        {
            foreach(Articulo aux in articulos)
            {
                venta.descontarStock(aux.Codigo,aux.Cantidad);
            }
        }

        public void insertarPagoDetalle(string tarjeta, string cuotas, string referencia, string monto, string pedido,string tipo_pago)
        {
            venta.insertarPagoDetalle(tarjeta,cuotas,referencia,monto,pedido,tipo_pago);
        }

        public void insertarPagoDetalleEfectivo(string monto, string pedido)
        {
            venta.insertarPagoDetalleEfectivo(monto, pedido);
        }

        public void insertarPagoDetalleCBU(string referencia,string total,string idVenta,string tipoTransferencia)
        {
            venta.insertarPagoDetalleCBU(referencia, total, idVenta,tipoTransferencia);
        }

        public string obtenerIDVenta(string usuario)
        {
            return venta.obtenerIDVenta(usuario);
        }

        public string[] detallesDelDia(string desde,string hasta, string usuario,string tipoVenta)
        {
            return venta.detallesDelDia(desde,hasta,usuario,tipoVenta);
        }

        public string[] detallesReporte(string desde, string hasta, string usuario)
        {
            return venta.detallesReporte(desde,hasta,usuario);
        }

        public DataTable mostrarTipoVentas()
        {
            return venta.mostrarTipoVentas();
        }

        public DataTable mostrarVentasRealizadas(string desde, string hasta, string usuario, string tipoVenta)
        {
            switch (int.Parse(tipoVenta))
            {
                case 0:

                    if (int.Parse(usuario) == 3)
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '" + tipoVenta + "' and p.ID_ESTADO='1'";
                    }
                    else
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO = '" + usuario + "' and p.ID_TIPO = '" + tipoVenta + "' and p.ID_ESTADO='1'";
                    }


                    break;

                case 1:

                    if (int.Parse(usuario) == 3)
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '" + tipoVenta + "' and p.ID_ESTADO='1'";
                    }
                    else
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO = '" + usuario + "' and p.ID_TIPO = '" + tipoVenta + "' and p.ID_ESTADO='1'";
                    }
                    break;

                case 2:

                    if (int.Parse(usuario) == 3)
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_ESTADO='1'";
                    }
                    else
                    {
                        sentencia = "SELECT p.FECHA_ENVIO,p.HORA,pr.NOMBRE,p.ID_PEDIDO,pt.DESCRIPCION,p.PRECIO_TOTAL,tp.DESCRIPCION FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON tp.ID_TIPO = p.ID_TIPO where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO = '" + usuario + "' and p.ID_ESTADO='1'";
                    }
                    break;
            }


            return venta.mostrarVentasRealizadas(sentencia);

        }



    }
}
