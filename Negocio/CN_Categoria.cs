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
    public class CN_Categoria
    {
        CD_Categoria cd = new CD_Categoria();

        public DataTable mostrar()
        {
            return cd.mostrar();
        }

        public DataTable mostrarTarjetas()
        {
            return cd.mostrarTarjetas();
        }

        public DataTable mostrarTipoTarjetas()
        {
            return cd.mostrarTipoTarjetas();
        }
        
        public AutoCompleteStringCollection LoadAutoCompleteTipoTarjetas()
        {
            return cd.LoadAutoCompleteTipoTarjetas();
        }

        public AutoCompleteStringCollection LoadAutoCompleteTarjetas()
        {
            return cd.LoadAutoCompleteTarjetas();
        }

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            return cd.LoadAutoComplete();
        }

        public void insertar(string descripcion)
        {
            cd.insertar(descripcion);
        }

        public string eliminar(string id)
        {
            return cd.eliminar(id);
        }
    }
}
