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
    public class CD_Caja
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public void abrirCaja(string usuario, string efectivo)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO CAJA (ID_USUARIO, APERTURA, ID_ESTADO) VALUES ('" + usuario + "', '" + efectivo + "', '3')";
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

        public void cerrarCaja(string usuario, string efectivo, string debito, string credito, string cbu, string idCaja,string mercadoPago)
        {
            #region UltimoID
            /*
                        try
                        {
                            conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                            conexion.Open();
                            sentencia = "SELECT max(ID_CAJA) FROM CAJA WHERE ID_USUARIO = '"+usuario+"' AND ID_ESTADO = '3'";
                            FbCommand cmd = new FbCommand(sentencia, conexion);
                            FbDataReader fb_datareader = cmd.ExecuteReader();
                            if (fb_datareader.Read())
                            {
                                id_caja = fb_datareader.GetString(0);
                            }
                            cmd = null;
                            conexion.Close();
                        }
                        catch (Exception)
                        {
                            conexion.Close();
                            throw;
                        }
            */
            #endregion

            decimal cierre = decimal.Parse(efectivo) + decimal.Parse(debito) + decimal.Parse(credito) + decimal.Parse(cbu);

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "UPDATE CAJA SET CIERRE = '" + cierre + "', HORA_CIERRE = CURRENT_TIME, FECHA_CIERRE = CURRENT_DATE , ID_ESTADO = '4', EFECTIVO = '" + efectivo + "', DEBITO = '" + debito + "', CREDITO = '" + credito + "', CBU = '" + cbu + "',mercadopago='"+mercadoPago+"' WHERE ID_CAJA = '" + idCaja + "' AND ID_USUARIO = '" + usuario + "' AND ID_ESTADO = '3'";

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

        public void eliminarMovimiento(string idUsuario, string idCaja, string idMovimiento)
        {

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "DELETE FROM MOVIMIENTOS_CAJA a WHERE ID_MOVIMIENTO = '" + idMovimiento + "' AND ID_CAJA = '" + idCaja + "' AND ID_USUARIO = '" + idUsuario + "'";

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

        public DataTable movimientoCaja(string usuario, string idCaja)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT FECHA,HORA,DESCRIPCION,MONTO,ID_MOVIMIENTO FROM MOVIMIENTOS_CAJA  WHERE ID_CAJA = '" + idCaja + "' AND ID_USUARIO = '" + usuario + "'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fbDataReader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fbDataReader);

                dt.Columns[0].ColumnName = "Fecha";

                dt.Columns[1].ColumnName = "Hora";

                dt.Columns[2].ColumnName = "Razón";

                dt.Columns[3].ColumnName = "Monto";

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

        public void extraerDeCaja(string usuario, string idCaja, string monto, string razon)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "INSERT INTO MOVIMIENTOS_CAJA (ID_CAJA, DESCRIPCION, MONTO,ID_USUARIO) VALUES('" + idCaja + "','" + razon + "','" + monto + "','" + usuario + "')";

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

        public int estadoUltimaCaja(string usuario)
        {
            int estado = 0;

            string id_caja = "";

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT max(ID_CAJA) FROM CAJA WHERE ID_USUARIO = '" + usuario + "'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {

                    id_caja = fb_datareader.GetString(0);

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {

                conexion.Close();

                throw;
            }

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT ID_ESTADO FROM CAJA WHERE ID_USUARIO = '" + usuario + "' and ID_CAJA='" + id_caja + "'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {

                    estado = int.Parse(fb_datareader.GetString(0));

                }

                cmd = null;

                conexion.Close();

                return estado;
            }
            catch (Exception)
            {
                conexion.Close();

                return estado;

                throw;
            }
        }

        public string ultimoIDCaja(string usuario)
        {
            string idCaja = "";

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT max(ID_CAJA) FROM CAJA WHERE ID_USUARIO = '" + usuario + "' and ID_ESTADO='3'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {

                    idCaja = fb_datareader.GetString(0);

                }

                cmd = null;

                conexion.Close();
            }
            catch (Exception)
            {

                conexion.Close();

                throw;
            }

            return idCaja;
        }

        public string[] detallesDelDia(string usuario, string idCaja)
        {
            string[] datos = new string[5];

            decimal efectivoAperturaCaja=0, efectivoMovimientos=0, efectivoTotal=0,efectivoVentas=0;

            #region Apertura de Caja
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select APERTURA from CAJA where ID_USUARIO = '" + usuario + "' and id_CAJA='" + idCaja + "'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                if (fb_datareader.Read())
                {
                    efectivoAperturaCaja = decimal.Parse(fb_datareader.GetString(0));
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

            #region Movimientos de Caja Realizados
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(MONTO)from MOVIMIENTOS_CAJA mc inner join CAJA c on mc.ID_CAJA = c.ID_CAJA inner join USUARIO u on u.ID_USUARIO = mc.ID_USUARIO where u.ID_USUARIO = '" + usuario + "' and c.id_caja = '" + idCaja + "'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        efectivoMovimientos = 0;
                    }
                    else
                    {
                        efectivoMovimientos = decimal.Parse(row[0].ToString());
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

            #region Ventas con efectivo Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(pd.MONTO)from pedido p inner join PAGO_DETALLE pd on p.ID_PEDIDO = pd.ID_PEDIDO inner join PAGO_TIPO pt on pt.ID_TIPOPAGO = pd.ID_TIPOPAGO inner join USUARIO u on u.ID_USUARIO = p.id_USUARIO where pt.ID_TIPOPAGO = '0' and u.ID_USUARIO = '" + usuario + "' and p.id_caja='" + idCaja + "' and p.id_estado='1'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                cmd = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        efectivoVentas = 0;
                    }
                    else
                    {
                        efectivoVentas = decimal.Parse(row[0].ToString());
                    }
                }

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Ventas con Credito Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(pd.MONTO)from pedido p inner join PAGO_DETALLE pd on p.ID_PEDIDO = pd.ID_PEDIDO inner join PAGO_TIPO pt on pt.ID_TIPOPAGO = pd.ID_TIPOPAGO inner join USUARIO u on u.ID_USUARIO = p.id_USUARIO where pt.ID_TIPOPAGO = '1' and u.ID_USUARIO = '" + usuario + "' and p.id_caja = '" + idCaja + "'  and p.id_estado='1' and NOT (ID_TARJETA='15' OR ID_TARJETA='16')";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                cmd = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        datos[1] = "0";
                    }
                    else
                    {
                        datos[1] = row[0].ToString();
                    }
                }

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
            #endregion

            #region Ventas con Debito Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(pd.MONTO)from pedido p inner join PAGO_DETALLE pd on p.ID_PEDIDO = pd.ID_PEDIDO inner join PAGO_TIPO pt on pt.ID_TIPOPAGO = pd.ID_TIPOPAGO inner join USUARIO u on u.ID_USUARIO = p.id_USUARIO where pt.ID_TIPOPAGO = '2' and u.ID_USUARIO = '" + usuario + "'  and p.id_caja='" + idCaja + "'  and p.id_estado='1' and NOT (ID_TARJETA='15' OR ID_TARJETA='16')";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                cmd = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        datos[2] = "0";
                    }
                    else
                    {
                        datos[2] = row[0].ToString();
                    }
                }

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Ventas con Transferencias Bancarias Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(pd.MONTO)from pedido p inner join PAGO_DETALLE pd on p.ID_PEDIDO = pd.ID_PEDIDO inner join PAGO_TIPO pt on pt.ID_TIPOPAGO = pd.ID_TIPOPAGO inner join USUARIO u on u.ID_USUARIO = p.id_USUARIO where pt.ID_TIPOPAGO = '3' and u.ID_USUARIO = '" + usuario + "' and p.id_caja='" + idCaja + "'  and p.id_estado='1'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                cmd = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        datos[3] = "0";
                    }
                    else
                    {
                        datos[3] = row[0].ToString();
                    }
                }

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();

                throw;
            }
            #endregion

            #region Ventas con Transferencias MercadoLibre Realizadas
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "select sum(pd.MONTO)from pedido p inner join PAGO_DETALLE pd on p.ID_PEDIDO = pd.ID_PEDIDO inner join PAGO_TIPO pt on pt.ID_TIPOPAGO = pd.ID_TIPOPAGO inner join USUARIO u on u.ID_USUARIO = p.id_USUARIO where pt.ID_TIPOPAGO = '4' and u.ID_USUARIO = '" + usuario + "' and p.id_caja='" + idCaja + "'  and p.id_estado='1'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();


                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                cmd = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == DBNull.Value)
                    {
                        datos[4] = "0";
                    }
                    else
                    {
                        datos[4] = row[0].ToString();
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

            efectivoTotal = efectivoAperturaCaja + efectivoVentas - efectivoMovimientos;

            if (efectivoTotal == 0)
            {
                datos[0] = "0";
            }
            else
            {
                datos[0] = efectivoTotal.ToString();
            }

            return datos;
        }
    }
}
