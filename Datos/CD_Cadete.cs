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
    public class CD_Cadete
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public DataTable mostrar()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR,PATENTE FROM PERSONA WHERE ID_TIPO ='2' ORDER BY ID_PERSONA";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Apellido";
                dt.Columns[2].ColumnName = "Nombre";
                dt.Columns[3].ColumnName = "Dirección";
                dt.Columns[4].ColumnName = "Teléfono";
                dt.Columns[5].ColumnName = "Celular";
                dt.Columns[6].ColumnName = "Patente";
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

        public DataTable cargarComboCadete()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE FROM PERSONA WHERE ID_TIPO ='2' ORDER BY ID_PERSONA";
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

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = cargarComboCadete();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["NOMBRE"]));
            }
            return stringCol;
        }

        public string insertar(string nombre, string apellido, string direccion, string telefono, string celular, string patente)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PERSONA (ID_PERSONA, NOMBRE, APELLIDO, DIRECCION, TELEFONO, CELULAR,PATENTE, ID_TIPO)VALUES(NULL,'" + nombre + "','" + apellido + "','" + direccion + "','" + telefono + "','" + celular + "','" + patente + "','2')";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Cadete registrado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Imposible registrar cadete";
            }
           
        }

        public string modificar(string id, string nombre, string apellido, string direccion, string telefono, string celular, string patente)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE PERSONA SET NOMBRE = '" + nombre + "', APELLIDO = '" + apellido + "', DIRECCION = '" + direccion + "', TELEFONO = '" + telefono + "', CELULAR = '" + celular + "', PATENTE = '" + patente + "' WHERE ID_PERSONA = '" + id + "' AND ID_TIPO = '2'";
                Console.WriteLine(sentencia);
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Cadete modificado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Cadete imposible de modificar";
            }
        }

        public string eliminar(string id)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "DELETE FROM PERSONA WHERE ID_PERSONA = '" + id + "' AND ID_TIPO = '2'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Cadete eliminado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Cadete imposible de eliminar";
            }
        }
    }
}
