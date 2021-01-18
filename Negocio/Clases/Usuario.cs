using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Usuario
    {
        private string id_usuario;

        private string nombre;

        private string idCaja;

        public void setIdCaja(string idCaja) { this.idCaja = idCaja; }

        public string getIdCaja() { return this.idCaja; }

        public void setID_USUARIO(string id_usuario){ this.id_usuario = id_usuario; }

        public string getID_USUARIO(){ return this.id_usuario; }

        public void setNombre(string nombre) { this.nombre = nombre; }

        public string getNombre() { return this.nombre; }


    }
}
