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
    public class CD_Cliente
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public void insertar(string nombre, string apellido, string direccion, string telefono, string celular,string usuario)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO PERSONA (ID_PERSONA, NOMBRE, APELLIDO, DIRECCION, TELEFONO, CELULAR,PATENTE, ID_TIPO,ID_USUARIO)VALUES(NULL,'" + nombre + "','" + apellido + "','" + direccion + "','" + telefono + "','" + celular + "',NULL,'1','"+usuario+"')";
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

        public string modificar(string id, string nombre, string apellido, string direccion, string telefono, string celular)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE PERSONA SET NOMBRE = '" + nombre + "', APELLIDO = '" + apellido + "', DIRECCION = '" + direccion + "', TELEFONO = '" + telefono + "', CELULAR = '" + celular + "' WHERE ID_PERSONA = '" + id + "' AND ID_TIPO = '1'";
                Console.WriteLine(sentencia);
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Cliente modificado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Cliente imposible de modificar";
            }
        }

        public string obtenerIDCliente(string usuario)
        {
            string datos="";

            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT max(ID_PERSONA) FROM PERSONA WHERE ID_TIPO = '1' and ID_USUARIO = '"+usuario+"'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();
                if (fb_datareader.Read())
                {
                    datos = fb_datareader.GetString(0);
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

        public string eliminar(string id)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "DELETE FROM PERSONA WHERE ID_PERSONA = '" + id + "' AND ID_TIPO = '1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Cliente eliminado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Cliente imposible de eliminar";
            }
        }

        public DataTable mostrar()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE ID_TIPO ='1' and ID_PERSONA > '0'";
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

        public DataTable filtrar(int opcion,string texto)
        {
            switch (opcion)
            {
                case 1:
                    sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE (UPPER(APELLIDO)like UPPER(APELLIDO) like UPPER('%"+texto+"') OR UPPER(APELLIDO) like UPPER('%"+texto+"%') OR UPPER(APELLIDO) like UPPER('"+texto+ "%') ) AND ID_TIPO ='1' ORDER BY APELLIDO";
                    break;

                case 2:
                    sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE (UPPER(NOMBRE)like UPPER(NOMBRE) like UPPER('%" + texto + "') OR UPPER(NOMBRE) like UPPER('%" + texto + "%') OR UPPER(NOMBRE) like UPPER('" + texto + "%')) and ID_TIPO ='1' ORDER BY APELLIDO";
                    break;

                case 3:
                    sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE (UPPER(TELEFONO)like UPPER(TELEFONO) like UPPER('%" + texto + "') OR UPPER(TELEFONO) like UPPER('%" + texto + "%') OR UPPER(TELEFONO) like UPPER('" + texto + "%')) and ID_TIPO ='1' ORDER BY APELLIDO";
                    break;

                case 4:
                    sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE (UPPER(CELULAR)like UPPER(CELULAR) like UPPER('%" + texto + "') OR UPPER(CELULAR) like UPPER('%" + texto + "%') OR UPPER(CELULAR) like UPPER('" + texto + "%') )and ID_TIPO ='1' ORDER BY APELLIDO";
                    break;

                case 5:
                    sentencia = "SELECT ID_PERSONA,APELLIDO,NOMBRE,DIRECCION,TELEFONO,CELULAR FROM PERSONA WHERE (UPPER(DIRECCION)like UPPER(DIRECCION) like UPPER('%" + texto + "') OR UPPER(DIRECCION) like UPPER('%" + texto + "%') OR UPPER(DIRECCION) like UPPER('" + texto + "%')) and ID_TIPO ='1' ORDER BY APELLIDO";
                    break;
            }
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
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
    }
}
