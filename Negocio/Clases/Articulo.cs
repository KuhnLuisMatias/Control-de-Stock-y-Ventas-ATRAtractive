using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Articulo
    {
        string codigo, descripcion;

        int cantidad=1;

        float precio;

        public string Codigo { get => codigo; set => codigo = value; }

        public string Descripcion { get => descripcion; set => descripcion = value; }

        public int Cantidad { get => cantidad; set => cantidad = value; }

        public float Precio { get => precio; set => precio = value; }
    }
}
