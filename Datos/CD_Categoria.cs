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
    public class CD_Categoria
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public DataTable mostrar()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_TIPOARTICULO,DESCRIPCION FROM TIPOARTICULO ORDER BY ID_TIPOARTICULO DESC";
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

        public DataTable mostrarTarjetas()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_TARJETA,DESCRIPCION FROM TARJETA where NOT (ID_TARJETA='15' OR ID_TARJETA='16') ORDER BY ID_TARJETA ";
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

        public DataTable mostrarTipoTarjetas()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_TIPOPAGO,DESCRIPCION FROM PAGO_TIPO WHERE ID_TIPOPAGO='1' OR ID_TIPOPAGO='2' ORDER BY ID_TIPOPAGO";
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
            DataTable dt = mostrar();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["DESCRIPCION"]));
            }
            return stringCol;
        }

        public AutoCompleteStringCollection LoadAutoCompleteTarjetas()
        {
            DataTable dt = mostrarTarjetas();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["DESCRIPCION"]));
            }
            return stringCol;
        }

        public AutoCompleteStringCollection LoadAutoCompleteTipoTarjetas()
        {
            DataTable dt = mostrarTipoTarjetas();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["DESCRIPCION"]));
            }
            return stringCol;
        }

        public void insertar(string descripcion)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO TIPOARTICULO (DESCRIPCION) VALUES ('" + descripcion + "')";
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

        public string eliminar(string id)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "DELETE FROM TIPOARTICULO WHERE ID_TIPOARTICULO ='" + id + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Categoría eliminada con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Categoría imposible de eliminar , se encuentra en uso";
            }
        }
     
    }
}
