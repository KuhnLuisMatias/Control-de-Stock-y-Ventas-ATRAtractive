using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Caja
    {
        private CD_Caja caja = new CD_Caja();

        public void abrirCaja(string usuario,string efectivo)
        {
            caja.abrirCaja(usuario,efectivo);
        }

        public void cerrarCaja(string usuario,string efectivo,string debito,string credito,string cbu,string idCaja,string mercadoPago)
        {
            caja.cerrarCaja(usuario,efectivo,debito,credito,cbu,idCaja,mercadoPago);
        }

        public string[] detallesDelDia(string usuario, string idCaja)
        {
            return caja.detallesDelDia(usuario,idCaja);
        }

        public bool estadoUltimaCaja(string usuario)
        {
            if (caja.estadoUltimaCaja(usuario) == 3)
            {
                return true;
            }
            else { return false; }
            
        }

        public string ultimoIDCaja(string usuario)
        {
          return caja.ultimoIDCaja(usuario);
        }

        public void extraerDeCaja(string usuario, string idCaja, string monto, string razon)
        {
            caja.extraerDeCaja(usuario, idCaja, monto, razon);
        }

        public DataTable movimientosCaja(string usuario, string idCaja)
        {
            return caja.movimientoCaja(usuario,idCaja);
        }

        public void eliminarMovimiento(string idUsuario, string idCaja, string idMovimiento)
        {
            caja.eliminarMovimiento(idUsuario, idCaja, idMovimiento);
        }
    }
}
