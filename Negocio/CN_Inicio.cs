using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Inicio
    {
        CD_Inicio cd_inicio = new CD_Inicio();

        public bool iniciarSesion(string user,string pass)
        {
            return cd_inicio.iniciarSesion(user,pass);
        }

        public string[] retornarUsuario(string user,string pass)
        {
            return cd_inicio.retornarUsuario(user,pass);
        }

    }
}
