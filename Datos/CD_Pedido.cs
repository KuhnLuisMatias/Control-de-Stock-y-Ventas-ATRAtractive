using ATRActractive;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Pedido
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public string insertarPedido(string usuario, string persona, string fecha, string estado, string precio, string idCaja)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PEDIDO (ID_PEDIDO, ID_USUARIO, ID_PERSONA, FECHA_PEDIDO, ID_ESTADO,PRECIO_ENVIO, PRECIO_TOTAL,ID_TIPO,ID_CAJA)VALUES(NULL,'" + usuario + "', '" + persona + "', '" + fecha + "', '" + estado + "',NULL,'" + precio + "','1','" + idCaja + "')";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "\t Pedido \n\n\t Número # " + obtenerIDPedido(usuario) + " \n\n\t Registrado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "No es posible registrar pedido";
            }


        }

        public string obtenerIDPedido(string usuario)
        {
            string numeroPedido = "";

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "select max(id_pedido) from PEDIDO where ID_usuario='" + usuario + "' and ID_TIPO='1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    numeroPedido = fb_datareader.GetString(0);
                }
                cmd = null;
                conexion.Close();
                return numeroPedido;
            }
            catch (Exception)
            {
                conexion.Close();
                return "No hay registros del pedido a registrar";
            }
        }

        public DataTable filtrarAsignados(string codigo)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT p.ID_PEDIDO,n.Apellido,n.NOMBRE,n.direccion,n.telefono,n.celular,p.fecha_PEDIDO,p.hora,n.ID_PERSONA,p.precio_total FROM PEDIDO p " +
                    "INNER JOIN PERSONA n ON p.ID_PERSONA = n.ID_PERSONA" +
                    " where p.id_estado='6' and p.ID_PEDIDO='"+codigo+"'";

                //(p.fecha_ENVIO='" + DateTime.Now.ToString("yyyy-MM-dd") + "') and

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fbDataReader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fbDataReader);

                dt.Columns[0].ColumnName = "Pedido";

                dt.Columns[1].ColumnName = "Apellido";

                dt.Columns[2].ColumnName = "Nombre";

                dt.Columns[3].ColumnName = "Direccion";

                dt.Columns[4].ColumnName = "Telefono";

                dt.Columns[5].ColumnName = "Celular";

                dt.Columns[6].ColumnName = "Fecha";

                dt.Columns[7].ColumnName = "Hora";

                dt.Columns[9].ColumnName = "Total";

                cmd = null;

                conexion.Close();

                return dt;
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
        }

        public void insertarDetalle(string pedido, string codigo, string cantidad)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO DETALLE_PEDIDO(ID_DETALLE, CANTIDAD, ID_PEDIDO, CODIGO)VALUES(NULL,'" + cantidad + "','" + pedido + "','" + codigo + "')";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public void asignarCadete(string usuario, string id_pedido, string fecha,string cadeteEnvio)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE PEDIDO SET ID_ESTADO='6',fecha_envio='" + fecha + "' ,ID_CADETE = '" + usuario + "',PRECIO_ENVIO='"+cadeteEnvio+"' WHERE ID_PEDIDO = '" + id_pedido + "' and ID_TIPO='1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                descontarStock(id_pedido);
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

        }

        public void descontarStock(string id_pedido)
        {
            DataTable dt = new DataTable();
            string codigo;
            decimal cantidad;

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia =
                    "SELECT a.CODIGO,dp.CANTIDAD FROM PEDIDO p " +
                    "INNER JOIN DETALLE_PEDIDO dp ON dp.ID_PEDIDO = p.ID_PEDIDO " +
                    "INNER JOIN ARTICULO a ON dp.CODIGO=a.CODIGO where p.ID_PEDIDO='" + id_pedido + "' and p.ID_TIPO='1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                dt.Load(fbDataReader);
                cmd = null;
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

            foreach (DataRow row in dt.Rows)
            {
                codigo = row[0].ToString();
                cantidad = decimal.Parse(row[1].ToString());
                descontarStockParte2(codigo, cantidad);
            }

        }

        public void descontarStockParte2(string codigo, decimal cantidad)
        {
            decimal stock = 0;
            // Obtener Producto
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT CANTIDAD FROM ARTICULO a WHERE CODIGO = '" + codigo + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    stock = int.Parse(fb_datareader.GetString(0));
                }
                cmd = null;
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
            }

            // Descontar el Stock & Actualizar tabla

            stock = stock - cantidad;

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE ARTICULO SET CANTIDAD = '" + stock + "' WHERE CODIGO = '" + codigo + "'";
                Console.WriteLine(sentencia);
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
            }

        }

        public void cancelarPedido(string id_pedido,string id_Cliente)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE PEDIDO SET ID_ESTADO='9' where ID_PEDIDO='" + id_pedido + "' and id_persona='" + id_Cliente + "'";
                Console.WriteLine(sentencia);
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                
            }
            catch (Exception)
            {
                conexion.Close();
            }

        }

        public DataTable filtrar(string codigo)
        {

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT p.ID_PEDIDO,n.Apellido,n.NOMBRE,n.ID_PERSONA,p.precio_total,p.fecha_pedido FROM PEDIDO p " +
                    "INNER JOIN PERSONA n ON p.ID_PERSONA = n.ID_PERSONA where p.id_estado='2' and p.ID_TIPO='1' and p.ID_PEDIDO='" + codigo + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "Pedido";
                dt.Columns[1].ColumnName = "Apellido";
                dt.Columns[2].ColumnName = "Nombre";
                dt.Columns[3].ColumnName = "ID_Persona";
                dt.Columns[4].ColumnName = "Total";
                dt.Columns[5].ColumnName = "Fecha";
                cmd = null;
                conexion.Close();
                return dt;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

        }

        public DataTable mostrar(string usuario)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT p.ID_PEDIDO,n.Apellido,n.NOMBRE,n.ID_PERSONA,p.precio_total,p.fecha_pedido FROM PEDIDO p " +
                    "INNER JOIN PERSONA n ON p.ID_PERSONA = n.ID_PERSONA where p.id_estado='2' and p.ID_TIPO='1' and p.ID_USUARIO='"+usuario+"'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "Pedido";
                dt.Columns[1].ColumnName = "Apellido";
                dt.Columns[2].ColumnName = "Nombre";
                dt.Columns[3].ColumnName = "ID_Persona";
                dt.Columns[4].ColumnName = "Total";
                dt.Columns[5].ColumnName = "Fecha";
                cmd = null;
                conexion.Close();
                return dt;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

        }

        public DataTable mostrarArticulos(string id_pedido)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia =
                    "SELECT a.CODIGO,a.DESCRIPCION,dp.CANTIDAD FROM PEDIDO p " +
                    "INNER JOIN DETALLE_PEDIDO dp ON dp.ID_PEDIDO = p.ID_PEDIDO " +
                    "INNER JOIN ARTICULO a ON dp.CODIGO=a.CODIGO where p.ID_PEDIDO='" + id_pedido + "'";// and p.ID_TIPO='1'
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                cmd = null;
                conexion.Close();
                return dt;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable mostrarCliente(string id_cliente)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "select nombre,apellido,direccion,telefono,celular from persona where id_persona='" + id_cliente + "' and id_tipo='1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                cmd = null;
                conexion.Close();
                return dt;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public DataTable mostrarAsignados(string usuario)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT p.ID_PEDIDO,n.Apellido,n.NOMBRE,n.direccion,n.telefono,n.celular,p.fecha_ENVIO,p.hora,n.ID_PERSONA,p.precio_total FROM PEDIDO p " +
                    "INNER JOIN PERSONA n ON p.ID_PERSONA = n.ID_PERSONA" +
                    " where p.id_estado='6' and p.ID_USUARIO='"+usuario+"' order by p.ID_PEDIDO";
                
                //(p.fecha_ENVIO='" + DateTime.Now.ToString("yyyy-MM-dd") + "') and

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fbDataReader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fbDataReader);

                dt.Columns[0].ColumnName = "Pedido";

                dt.Columns[1].ColumnName = "Apellido";

                dt.Columns[2].ColumnName = "Nombre";

                dt.Columns[3].ColumnName = "Direccion";

                dt.Columns[4].ColumnName = "Telefono";

                dt.Columns[5].ColumnName = "Celular";

                dt.Columns[6].ColumnName = "Fecha Envío";

                dt.Columns[7].ColumnName = "Hora";

                dt.Columns[9].ColumnName = "Total";

                cmd = null;
                conexion.Close();
                return dt;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }

        }

        public string actualizarEstadoPedido(string idPedido, string monto,string idUsuario,string idCaja)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "UPDATE PEDIDO SET ID_ESTADO='1',ID_USUARIO='"+idUsuario+"',ID_CAJA='"+idCaja+"',FECHA_PEDIDO = CURRENT_DATE WHERE ID_PEDIDO = '" + idPedido + "' and ID_TIPO='1' and ID_ESTADO='6'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                cmd.ExecuteNonQuery();

                cmd = null;

                conexion.Close();

                insertarPagoDetalleEfectivo(idPedido, monto);

                return "Pedido Vendido con éxito.";
            }
            catch (Exception)
            {
                conexion.Close();

                return "Problemas con la venta del pedido";

                throw;
            }
        }

        public void insertarPagoDetalleEfectivo(string idPedido, string monto)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "INSERT INTO PAGO_DETALLE (MONTO,ID_PEDIDO) VALUES ('" + monto + "','" + idPedido + "')";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                cmd.ExecuteNonQuery();

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
        }

        public string actualizarEstadoPedidoTarjeta(string idPedido, string tarjeta, string cuotas, string referencia, string importe, string tipoPago,string idCaja)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "UPDATE PEDIDO SET ID_ESTADO='1',ID_CAJA='"+idCaja+"' WHERE ID_PEDIDO = '" + idPedido + "' and ID_TIPO='1' and ID_ESTADO='6'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                cmd.ExecuteNonQuery();

                cmd = null;

                conexion.Close();

                insertarPagoDetalleTarjetaCBU(idPedido, tarjeta, cuotas, referencia, importe, tipoPago);

                return "Pedido Vendido con éxito.";
            }
            catch (Exception)
            {
                conexion.Close();

                return "Problemas con la venta del pedido";

                throw;
            }
        }

        public void insertarPagoDetalleTarjetaCBU(string idPedido, string tarjeta, string cuotas, string referencia, string importe, string tipoPago)
        {

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "INSERT INTO PAGO_DETALLE (MONTO,ID_PEDIDO,ID_TARJETA,CUOTAS,NUM_REFERENCIA,ID_TIPOPAGO) VALUES ('" + importe + "','" + idPedido + "','" + tarjeta + "','" + cuotas + "','" + referencia + "','" + tipoPago + "')";

                Console.WriteLine(sentencia+"cosme");

                FbCommand cmd = new FbCommand(sentencia, conexion);

                cmd.ExecuteNonQuery();

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
        }

        public string[] detallesDelPedido(string idPedido)
        {
            string[] datos = new string[14];
                     
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                sentencia = "SELECT p.FECHA_PEDIDO,p.HORA,p.ID_PEDIDO,tp.DESCRIPCION,pt.DESCRIPCION,pd.NUM_REFERENCIA,p.PRECIO_TOTAL,per.NOMBRE,per2.NOMBRE,per2.APELLIDO,per2.DIRECCION,per2.TELEFONO,per2.CELULAR,per2.ID_PERSONA FROM PEDIDO p INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA per ON per.ID_PERSONA = u.ID_PERSONA INNER JOIN TIPO_PEDIDO tp ON p.ID_TIPO = tp.ID_TIPO INNER JOIN PAGO_DETALLE pd on pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN Persona per2 On per2.ID_PERSONA = p.ID_PERSONA WHERE p.ID_PEDIDO = '"+idPedido+"'";

                conexion.Open();

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[0] = fb_datareader.GetString(0);

                    datos[1] = fb_datareader.GetString(1);

                    datos[2] = fb_datareader.GetString(2);

                    datos[3] = fb_datareader.GetString(3);

                    datos[4] = fb_datareader.GetString(4);

                    datos[5] = fb_datareader.GetString(5);

                    if (datos[5] == "")
                    {
                        datos[5] = "Efectivo";
                    }

                    datos[6] = fb_datareader.GetString(6);

                    datos[7] = fb_datareader.GetString(7);

                    datos[8] = fb_datareader.GetString(8);

                    datos[9] = fb_datareader.GetString(9);

                    datos[10] = fb_datareader.GetString(10);

                    datos[11] = fb_datareader.GetString(11);

                    if (datos[11] == "0" || datos[11] =="")
                    {
                        datos[11] = "Sin Asignar";
                    }

                    datos[12] = fb_datareader.GetString(12);

                    if (datos[12] == "0" || datos[12] =="")
                    {
                        datos[12] = "Sin Asignar";
                    }

                    datos[13] = fb_datareader.GetString(13);
                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }

            return datos;
        }
    }
}
