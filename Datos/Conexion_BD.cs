using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATRActractive
{
    class Conexion_BD
    {
        public static FbConnectionStringBuilder Recuperar_cadena()
        {
            FbConnectionStringBuilder fb_conexion = new FbConnectionStringBuilder();
            fb_conexion.ServerType = FbServerType.Default;
            fb_conexion.UserID = "SYSDBA";
            fb_conexion.Password = "masterkey";
            fb_conexion.Dialect = 3;
            fb_conexion.Database = @"C:\ATRSistema\BD\DB_ATR.FDB";
            fb_conexion.DataSource = "IPHOST"; //Host
            //fb_conexion.DataSource = "IPCLIENT" Client;
            //fb_conexion.DataSource = "localhost";
            fb_conexion.Pooling = true;
            fb_conexion.Port = 3050;
            fb_conexion.ConnectionLifeTime = 15;
            fb_conexion.MinPoolSize = 0;
            fb_conexion.MaxPoolSize = 50;
            fb_conexion.PacketSize = 8192;
            fb_conexion.Charset = "None";
            //string patch = Application.StartupPath;
            //fb_conexion.Database = patch + @"\BD\DB_ATR.FDB";
            return fb_conexion;
        }
       
    }
}
