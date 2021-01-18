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
    public class CD_Vendedores
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public DataTable mostrarVendedores()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());

                conexion.Open();

                sentencia = "SELECT u.ID_USUARIO,p.NOMBRE FROM USUARIO u INNER JOIN PERSONA p ON p.ID_PERSONA=u.ID_PERSONA where p.ID_TIPO='3'";

                FbCommand cmd = new FbCommand(sentencia, conexion);

                FbDataReader fb_datareader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(fb_datareader);

                dt.Rows.Add(3, "Todos");

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
