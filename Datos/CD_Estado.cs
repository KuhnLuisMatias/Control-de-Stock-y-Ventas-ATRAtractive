using ATRActractive;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class CD_Estado
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public DataTable estadoPedido()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_ESTADO,DESCRIPCION FROM ESTADO  where ID_ESTADO='2' OR ID_ESTADO='9' ORDER BY ID_ESTADO";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fb_datareader);
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

        public DataTable tipoTransferencia()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT ID_TIPOPAGO,DESCRIPCION FROM PAGO_TIPO where ID_TIPOPAGO='3' OR ID_TIPOPAGO='4' ORDER BY ID_TIPoPAGO";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

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

        public DataTable estadoPedidoVendido()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT ID_ESTADO,DESCRIPCION FROM ESTADO  where ID_ESTADO='9' ORDER BY ID_ESTADO";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

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

        public DataTable estadoVenta()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT ID_ESTADO,DESCRIPCION FROM ESTADO  where ID_ESTADO='9'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();
                
                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

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

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = estadoPedido();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["DESCRIPCION"]));
            }
            return stringCol;
        }

        public void modificarEstado(string id_pedido, string id_Cliente, string id_estado)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "UPDATE PEDIDO SET ID_ESTADO='"+id_estado+"' where ID_PEDIDO='"+id_pedido+"' and id_persona='"+id_Cliente+"'";
                Console.WriteLine(sentencia);

                FbCommand cmd = new FbCommand(sentencia, conexion);

                cmd.ExecuteNonQuery();

                cmd = null;

                conexion.Close();

               
                if (decimal.Parse(id_estado) == 2 || decimal.Parse(id_estado) == 9)
                {
                    restaurarStock(id_pedido);
                }
            }
            catch (Exception)
            {
                conexion.Close();
            }

        }

        public void restaurarStock(string id_pedido)
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
                    "INNER JOIN ARTICULO a ON dp.CODIGO=a.CODIGO where p.ID_PEDIDO='" + id_pedido + "'";
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

                restaurarStockParte2(codigo, cantidad);
            }

        }

        public void restaurarStockParte2(string codigo, decimal cantidad)
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

            // Aumenta el Stock & Actualizar tabla

            stock = stock + cantidad;

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

    }
}
