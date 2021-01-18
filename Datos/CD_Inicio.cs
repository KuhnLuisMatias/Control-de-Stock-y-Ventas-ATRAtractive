using ATRActractive;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class CD_Inicio
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;
        
        public bool iniciarSesion(string user,string pass)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "select *from USUARIO u where u.NOMBRE='" + user + "' and u.CONTRASENA='" + pass + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();


                if (fb_datareader.Read())
                {
                    cmd = null;
                    conexion.Close();
                    return true;
                }
                else
                {
                    cmd = null;
                    conexion.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
           

        }

        public string[] retornarUsuario(string user, string pass)
        {
            string[] datos = new string[2];
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "select u.ID_USUARIO,p.NOMBRE from USUARIO u INNER JOIN PERSONA p ON u.ID_PERSONA = p.ID_PERSONA where u.NOMBRE='" + user + "' and u.CONTRASENA='" + pass + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fb_datareader = cmd.ExecuteReader();
                if (fb_datareader.Read())
                {
                    datos[0] = fb_datareader.GetString(0);
                    datos[1] = fb_datareader.GetString(1);
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
