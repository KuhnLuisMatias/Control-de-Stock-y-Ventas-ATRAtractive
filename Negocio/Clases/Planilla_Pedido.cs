using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Planilla_Pedido
    {
        private string numeroPedido;

        private string id_cliente, nombre, apellido, direccion, telefono, celular,nombreCadete,fechaEnvio,precioEnvio;

        private  List<Articulo> articulos = new List<Articulo>();

        public string NumeroPedido { get => numeroPedido; set => numeroPedido = value; }

        public List<Articulo> Articulos { get => articulos; set => articulos = value; }

        public string Id_cliente { get => id_cliente; set => id_cliente = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public string Direccion { get => direccion; set => direccion = value; }

        public string Telefono { get => telefono; set => telefono = value; }

        public string Celular { get => celular; set => celular = value; }

        public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }

        public string FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }

        public string PrecioEnvio { get => precioEnvio; set => precioEnvio = value; }

    }

}
