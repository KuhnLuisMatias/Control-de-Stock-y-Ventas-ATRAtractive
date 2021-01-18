using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class CN_Cadete
    {
        CD_Cadete cadete = new CD_Cadete();

        public DataTable mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = cadete.mostrar();
            return tabla;
        }

        public DataTable mostrarCadete()
        {
            DataTable tabla = new DataTable();
            tabla = cadete.cargarComboCadete();
            return tabla;
        }

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            return cadete.LoadAutoComplete();
        }

        public string insertar(string nombre, string apellido, string direccion, string telefono, string celular, string patente)
        {
            return cadete.insertar(nombre, apellido, direccion, telefono, celular, patente);
        }

        public string modificar(string id,string nombre, string apellido, string direccion, string telefono, string celular, string patente) {
            return cadete.modificar(id,nombre, apellido, direccion, telefono, celular, patente);
        }

        public string eliminar(string id) {
            return cadete.eliminar(id);
        }
    }
}
