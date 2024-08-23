using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHolder
{
    internal class Cliente
    {
        public Cliente(string nombre, string dPI, string numeroCuenta)
        {
            Nombre = nombre;
            DPI = dPI;
            NumeroCuenta = numeroCuenta;
        }

        private string Nombre { get; set; }
        private string DPI { get; set; }
        private string NumeroCuenta { get; set; }
        private List<Tarjeta> TarjetasCliente { get; set; } //se crea un metodo publico agregar tarjetas que reciba una List

    }
}
