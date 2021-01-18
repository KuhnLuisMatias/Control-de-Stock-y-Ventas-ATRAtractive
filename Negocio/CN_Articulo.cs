using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Articulo
    {
        CD_Articulo articulo = new CD_Articulo();

        public DataTable mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = articulo.mostrar();
            return tabla;
        }

        public string insertar(string codigo, string descripcion, string precio_compra, string precio_venta, string cantidad, string id_tipo,string idUsuario)
        {
           return articulo.insertar(codigo, descripcion, precio_compra, precio_venta, cantidad, id_tipo,idUsuario);
        }

        public string modificar(string codigo, string descripcion, string precio_compra, string precio_venta, string cantidad, string id_tipo, string idUsuario)
        {
            return articulo.modificar(codigo, descripcion, precio_compra, precio_venta, cantidad, id_tipo,idUsuario);
        }

        public string eliminar(string codigo)
        {
            return articulo.eliminar(codigo);
        }

        public DataTable filtrarProducto(string codigo)
        {
            return articulo.filtrar(codigo);
        }

        public DataTable filtrarProducto2(string codigo)
        {
            return articulo.filtrar2(codigo);
        }
    }
}
