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
    public class CD_Venta
    {
        private FbConnection conexion = new FbConnection();
        
        private string sentencia;

        public void insertarVenta(string usuario,string precio,string idCaja)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PEDIDO (ID_USUARIO,ID_ESTADO,PRECIO_TOTAL,ID_CAJA)VALUES('" + usuario + "','1','" + precio + "','"+idCaja+"')";
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

        public void insertarDetalle(string id_venta,string codigo, string cantidad)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO DETALLE_PEDIDO(ID_DETALLE, CANTIDAD, ID_PEDIDO, CODIGO)VALUES(NULL,'" + cantidad + "','" +id_venta + "','" + codigo + "')";
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

        public void insertarPagoDetalleCBU(string referencia, string total, string idVenta,string tipoTransferencia)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "INSERT INTO PAGO_DETALLE (NUM_REFERENCIA, MONTO,ID_PEDIDO,ID_TIPOPAGO) VALUES ('" + referencia + "','" + total + "','" + idVenta + "','"+tipoTransferencia+"')";

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

        public void insertarPagoDetalle(string tarjeta,string cuotas,string referencia,string monto,string pedido,string tipo_pago)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PAGO_DETALLE (ID_TARJETA, CUOTAS, NUM_REFERENCIA, MONTO,ID_PEDIDO,ID_TIPOPAGO) VALUES ('"+tarjeta+"','"+cuotas+"','"+referencia+"','"+monto+"','"+pedido+"','"+tipo_pago+"')";
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

        public void insertarPagoDetalleEfectivo(string monto, string pedido)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PAGO_DETALLE (MONTO,ID_PEDIDO) VALUES ('"+ monto + "','" + pedido + "')";
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
        
        public void descontarStock(string codigo,decimal cantidad)
        {
           decimal stock = 0;
            // Obtener Producto
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT CANTIDAD FROM ARTICULO a WHERE CODIGO = '"+codigo+"'";
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
                sentencia = "UPDATE ARTICULO SET CANTIDAD = '"+stock+"' WHERE CODIGO = '"+codigo+"'";
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

        public string obtenerIDVenta(string usuario)
        {
            string numeroVenta = "";

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "select max(id_pedido) from PEDIDO where ID_usuario='" + usuario + "' and ID_TIPO='0'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    numeroVenta = fb_datareader.GetString(0);
                }
                cmd = null;
                conexion.Close();
                return numeroVenta;
            }
            catch (Exception)
            {
                conexion.Close();
                return "No hay registros de la venta a registrar";
            }
        }

        public string[] detallesDelDia(string desde,string hasta,string usuario,string tipoVenta)
        {
            string[] datos = new string[4];

            #region Ventas Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '0' and p.ID_USUARIO='" + usuario+"' and p.id_estado='1'";
                    break;

                    case 2:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '0' and p.ID_USUARIO='"+usuario+ "'  and p.id_estado='1'";
                        break;

                    case 3:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '0'  and p.id_estado='1'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[0] = fb_datareader.GetString(0);

                    if (datos[0] == "")
                    {
                        datos[0] = "0";
                    }

                }


                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Pedidos Realizados
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '1' and p.ID_USUARIO='" + usuario + "' and p.id_estado='1'";
                        break;

                    case 2:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '1' and p.ID_USUARIO='" + usuario + "' and p.id_estado='1'";
                        break;

                    case 3:
                        sentencia = "SELECT count(p.ID_PEDIDO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_TIPO = '1' and p.id_estado='1'";
                        break;
                }
                

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[1] = fb_datareader.GetString(0);

                    if (datos[1] == "")
                    {
                        datos[1] = "0";
                    }

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
            #endregion

            #region Cantidad Productos
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                            sentencia = "SELECT sum(dp.CANTIDAD) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN DETALLE_PEDIDO dp on dp.ID_PEDIDO = p.ID_PEDIDO where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1'";
                        break;

                    case 2:
                            sentencia = "SELECT sum(dp.CANTIDAD) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN DETALLE_PEDIDO dp on dp.ID_PEDIDO = p.ID_PEDIDO where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1'";
                        break;

                    case 3:
                            sentencia = "SELECT sum(dp.CANTIDAD) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA INNER JOIN DETALLE_PEDIDO dp on dp.ID_PEDIDO = p.ID_PEDIDO where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();


                if (fb_datareader.Read())
                {
                    datos[2] = fb_datareader.GetString(0);

                    if (datos[2] == "")
                    {
                        datos[2] = "0";
                    }

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Total Vendido
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                            sentencia = "SELECT sum(p.PRECIO_TOTAL) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where(p.fecha_pedido >= '"+desde+"' and p.fecha_pedido <= '"+hasta+"') and p.ID_USUARIO = '"+usuario+ "'  and p.id_estado='1'";
                        break;

                    case 2:
                            sentencia = "SELECT sum(p.PRECIO_TOTAL) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.ID_USUARIO = '" + usuario + "'  and p.id_estado='1'";
                        break;

                    case 3:
                            sentencia = "SELECT sum(p.PRECIO_TOTAL) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where(p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[3] = fb_datareader.GetString(0);

                    if (datos[3] == "")
                    {
                        datos[3] = "0";
                    }
                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            return datos;
        }

        public DataTable mostrarTipoVentas()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT ID_TIPO,DESCRIPCION FROM TIPO_PEDIDO";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                dt.Rows.Add(2, "Todos");

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

        public DataTable mostrarVentasRealizadas(string sentenciaAux)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                sentencia = sentenciaAux;

                conexion.Open();

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fbDataReader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fbDataReader);

                dt.Columns[0].ColumnName = "Fecha";

                dt.Columns[1].ColumnName = "Hora";

                dt.Columns[2].ColumnName = "Vendedor";

                dt.Columns[3].ColumnName = "No. de Venta";

                dt.Columns[4].ColumnName = "Forma de Pago";

                dt.Columns[5].ColumnName = "Total";

                dt.Columns[6].ColumnName = "Tipo de Venta";

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

        public string[] detallesReporte(string desde, string hasta, string usuario)
        {
            string[] datos = new string[5];

            #region Total Ventas Efectivo
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "' and p.id_estado='1' and pd.id_tipopago='0'";
                        break;

                    case 2:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1' and pd.id_tipopago='0'";
                        break;

                    case 3:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1' and pd.id_tipopago='0'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[0] = fb_datareader.GetString(0);

                    if (datos[0] == "")
                    {
                        datos[0] = "0";
                    }

                }


                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Total Ventas Credito
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "' and p.id_estado='1' and pd.id_tipopago='1'";
                        break;

                    case 2:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1' and pd.id_tipopago='1'";
                        break;

                    case 3:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1' and pd.id_tipopago='1'";
                        break;
                }


                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[1] = fb_datareader.GetString(0);

                    if (datos[1] == "")
                    {
                        datos[1] = "0";
                    }

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
            #endregion

            #region Total Ventas Debito
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "' and p.id_estado='1' and pd.id_tipopago='2'";
                        break;

                    case 2:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1' and pd.id_tipopago='2'";
                        break;

                    case 3:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1' and pd.id_tipopago='2'";
                        break;
                }


                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();


                if (fb_datareader.Read())
                {
                    datos[2] = fb_datareader.GetString(0);

                    if (datos[2] == "")
                    {
                        datos[2] = "0";
                    }

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Total Transferancias CBU
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "' and p.id_estado='1' and pd.id_tipopago='3'";
                        break;

                    case 2:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1' and pd.id_tipopago='3'";
                        break;

                    case 3:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1' and pd.id_tipopago='3'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[3] = fb_datareader.GetString(0);

                    if (datos[3] == "")
                    {
                        datos[3] = "0";
                    }
                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Total Transferencias MercadoPago
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                switch (int.Parse(usuario))
                {
                    case 1:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "' and p.id_estado='1' and pd.id_tipopago='4'";
                        break;

                    case 2:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "')  and p.ID_USUARIO='" + usuario + "'  and p.id_estado='1' and pd.id_tipopago='4'";
                        break;

                    case 3:
                        sentencia = "SELECT sum(pd.MONTO) FROM PEDIDO p INNER JOIN PAGO_DETALLE pd ON pd.ID_PEDIDO = p.ID_PEDIDO INNER JOIN PAGO_TIPO pt ON pt.ID_TIPOPAGO = pd.ID_TIPOPAGO INNER JOIN USUARIO u ON u.ID_USUARIO = p.ID_USUARIO INNER JOIN PERSONA pr ON pr.ID_PERSONA = u.ID_PERSONA where (p.fecha_pedido >= '" + desde + "' and p.fecha_pedido <= '" + hasta + "') and p.id_estado='1' and pd.id_tipopago='4'";
                        break;
                }

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    datos[4] = fb_datareader.GetString(0);

                    if (datos[4] == "")
                    {
                        datos[4] = "0";
                    }
                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            return datos;
        }
    }
}
