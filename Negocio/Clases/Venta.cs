using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Venta
    {
        private Articulo articulo = new Articulo();

        private Usuario usuario = new Usuario();

        private List<Articulo> articulos = new List<Articulo>();

        private float total,montoTarjeta,montoEfectivo,descuentoPorcentaje=0,montoPorcentaje=0;

        public float Total { get => total; set => total = value; }

        public float MontoTarjeta { get => montoTarjeta; set => montoTarjeta = value; }

        public float MontoEfectivo { get => montoEfectivo; set => montoEfectivo = value; }

        public float DescuentooPorcentaje { get => descuentoPorcentaje; set => descuentoPorcentaje = value; }

        public float MontoPorcentaje { get => montoPorcentaje; set => montoPorcentaje = value; }

        public Usuario Usuario { get => usuario; set => usuario = value; }

        public List<Articulo> Articulos { get => articulos; set => articulos = value; }

        public DataTable tablaPresentacion()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Codigo", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("Cantidad", typeof(decimal));
            table.Columns.Add("Precio Unitario", typeof(string));
            table.Columns.Add("Precio Total", typeof(decimal));
            return table;
        }

        public DataTable tablaArticulos()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Codigo", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("Cantidad", typeof(decimal));
            table.Columns.Add("Precio Unitario", typeof(string));
            table.Columns.Add("Precio Total", typeof(decimal));

            foreach (Articulo articulo in Articulos)
            {
                DataRow row = table.NewRow();
                row["Codigo"] = articulo.Codigo;
                row["Descripcion"] = articulo.Descripcion;
                row["Cantidad"] = articulo.Cantidad;
                row["Precio Unitario"] = articulo.Precio;
                row["Precio Total"] = articulo.Cantidad * articulo.Precio;
                table.Rows.Add(row);
            }
            return table;
        }

        public void addArticulos(Articulo articulo)
        {
            bool find = false;

            for (int i = 0; i < Articulos.Count; i++)
            {
                if (articulo.Codigo == Articulos[i].Codigo)
                {
                    Articulos[i].Cantidad += 1;
                    find = true;
                }
            }
            if (!find) { Articulos.Add(articulo); }

        }

        public float sumarListado()
        {
            Total = 0;

            foreach (Articulo aux in Articulos)
            {
                Total += aux.Cantidad * aux.Precio;
            }

            if (descuentoPorcentaje != 0)
            {
                MontoPorcentaje = Total * (descuentoPorcentaje / 100);

                Total = Total - MontoPorcentaje;
            }
            else
            {
                MontoPorcentaje = 0;
            }

            return Total;
        }

        public void modificarArticulo(string codigo, int cantidad)
        {
            bool find = false;

            for (int i = 0; i < Articulos.Count; i++)
            {
                if (codigo == Articulos[i].Codigo)
                {
                    Articulos[i].Cantidad = cantidad;
                    find = true;
                }
            }
            if (!find) { Articulos.Add(articulo); }
        }

        public void eliminarArticulo(string codigo)
        {
            for (int i = 0; i < Articulos.Count; i++)
            {
                if (codigo == Articulos[i].Codigo)
                {
                    Articulos.RemoveAt(i);
                }
            }
        }
    }
}
