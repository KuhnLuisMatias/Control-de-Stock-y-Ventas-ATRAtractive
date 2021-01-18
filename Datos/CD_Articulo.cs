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
    public class CD_Articulo
    {
        private FbConnection conexion = new FbConnection();

        private string sentencia;

        public string insertar(string codigo, string descripcion, string precio_compra, string precio_venta, string cantidad, string id_tipo,string idUsuario)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "INSERT INTO ARTICULO(ID_ARTICULO,CODIGO, DESCRIPCION, PRECIO_COMPRA,PRECIO_VENTA, CANTIDAD, ID_TIPOARTICULO,ID_USUARIO)VALUES(NULL,'" + codigo + "','" + descripcion + "','" + precio_compra + "','" + precio_venta + "','" + cantidad + "','" + id_tipo +"','"+idUsuario+"')";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Articulo registrado con éxito .";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Código Existente , intente nuevamente .";
            }
        }

        public string modificar(string codigo, string descripcion, string precio_compra, string precio_venta, string cantidad, string id_tipo,string idUsuario)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "UPDATE ARTICULO SET DESCRIPCION = '" + descripcion + "',PRECIO_COMPRA = '" + precio_compra + "',PRECIO_VENTA = '" + precio_venta + "',CANTIDAD = '" + cantidad + "',ID_TIPOARTICULO = '" + id_tipo +"',ID_USUARIO='"+idUsuario+"',FECHA_MODIFICACION=CURRENT_DATE WHERE CODIGO = '" + codigo + "'";
                Console.WriteLine(sentencia);
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Artículo modificado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Artículo imposible de modificar";
            }
        }

        public string eliminar(string codigo)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "DELETE FROM ARTICULO WHERE CODIGO='" + codigo + "'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                cmd.ExecuteNonQuery();
                cmd = null;
                conexion.Close();
                return "Artículo eliminado con éxito";
            }
            catch (Exception)
            {
                conexion.Close();
                return "Artículo imposible de eliminar";
            }
        }

        public DataTable mostrar()
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT a.CODIGO,a.DESCRIPCION,a.PRECIO_COMPRA,a.PRECIO_VENTA,a.CANTIDAD,a.ID_TIPOARTICULO,ta.descripcion,p.NOMBRE,a.FECHA_MODIFICACION FROM ARTICULO a INNER JOIN TIPOARTICULO ta ON ta.ID_TIPOARTICULO = a.ID_TIPOARTICULO INNER JOIN USUARIO u ON u.ID_USUARIO = a.ID_USUARIO INNER JOIN PERSONA p ON p.ID_PERSONA = u.ID_PERSONA";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "Codigo";
                dt.Columns[1].ColumnName = "Descripción";
                dt.Columns[2].ColumnName = "Precio Compra";
                dt.Columns[3].ColumnName = "Precio Venta";
                dt.Columns[4].ColumnName = "Stock Disponible";
                dt.Columns[6].ColumnName = "Categoría";
                dt.Columns[7].ColumnName = "Vendedor";
                dt.Columns[8].ColumnName = "Fecha Modificacion";
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

        public DataTable filtrar(string codigo)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT a.CODIGO,a.DESCRIPCION,a.PRECIO_VENTA,a.CANTIDAD,ta.DESCRIPCION FROM ARTICULO a INNER JOIN TIPOARTICULO ta ON ta.ID_TIPOARTICULO = a.ID_TIPOARTICULO where ( UPPER(a.CODIGO)like UPPER('%" + codigo + "') OR UPPER(a.DESCRIPCION) like UPPER('%" + codigo + "') OR UPPER(a.DESCRIPCION) like UPPER('%" + codigo + "%') OR UPPER(a.DESCRIPCION) like UPPER('" + codigo + "%')) and a.cantidad >='1'";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "Codigo";
                dt.Columns[1].ColumnName = "Descripción";
                dt.Columns[2].ColumnName = "Precio Venta";
                dt.Columns[3].ColumnName = "Stock Disponible";
                dt.Columns[4].ColumnName = "Categoría";
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

        public DataTable filtrar2(string codigo)
        {
            try
            {
                conexion.ConnectionString = Convert.ToString(Conexion_BD.Recuperar_cadena());
                conexion.Open();
                sentencia = "SELECT a.CODIGO,a.DESCRIPCION,a.PRECIO_COMPRA,a.PRECIO_VENTA,a.CANTIDAD,a.ID_TIPOARTICULO ,ta.DESCRIPCION FROM ARTICULO a INNER JOIN TIPOARTICULO ta  ON ta.ID_TIPOARTICULO = a.ID_TIPOARTICULO  where ( UPPER(a.CODIGO)like UPPER('%" + codigo + "') OR UPPER(a.DESCRIPCION) like UPPER('%" + codigo + "') OR UPPER(a.DESCRIPCION) like UPPER('%" + codigo + "%') OR UPPER(a.DESCRIPCION) like UPPER('" + codigo + "%')) ";
                FbCommand cmd = new FbCommand(sentencia, conexion);
                FbDataReader fbDataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(fbDataReader);
                dt.Columns[0].ColumnName = "Codigo";
                dt.Columns[1].ColumnName = "Descripción";
                dt.Columns[2].ColumnName = "Precio Compra";
                dt.Columns[3].ColumnName = "Precio Venta";
                dt.Columns[4].ColumnName = "Stock Disponible";
                dt.Columns[6].ColumnName = "Categoría";
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
