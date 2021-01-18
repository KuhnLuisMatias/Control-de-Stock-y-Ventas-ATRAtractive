using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Vendedores
    {
        private CD_Vendedores cdVendedores = new CD_Vendedores();

        public DataTable mostrarVendedores()
        {
            return cdVendedores.mostrarVendedores();
        }
    }
}
