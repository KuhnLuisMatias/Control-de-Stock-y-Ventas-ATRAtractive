using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Cliente
    {
        CD_Cliente cliente = new CD_Cliente();

        public DataTable mostrar()
        {
            DataTable tabla = new DataTable();

            tabla = cliente.mostrar();

            return tabla;
        }

        public void insertar(string nombre, string apellido, string direccion, string telefono, string celular,string usuario)
        {
            cliente.insertar(nombre, apellido, direccion, telefono, celular,usuario);
        }

        public string modificar(string id, string nombre, string apellido, string direccion, string telefono, string celular)
        {
            return cliente.modificar(id, nombre, apellido, direccion, telefono, celular);
        }

        public string eliminar(string id)
        {
            return cliente.eliminar(id);
        }

        public string obtenerIDCliente(string usuario)
        {
            return cliente.obtenerIDCliente(usuario);
        }

        public DataTable filtrar(int opcion,string texto)
        {
            DataTable tabla = new DataTable();

            tabla = cliente.filtrar(opcion,texto);

            return tabla;
        }
    }
}
