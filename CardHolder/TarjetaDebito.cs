using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHolder
{
    internal class TarjetaDebito : Tarjeta
    {
        private bool TieneSeguro {  get; set; } //NO SABIA QUE PONER
        public TarjetaDebito(string numeroTarjeta, string fechaVencimiento, Cliente titularTarjeta, int cVV, bool tieneSeguro)
        : base(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV)
        {
            TieneSeguro = tieneSeguro;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("\nTipo tarjeta: DEBITO");
            if(TieneSeguro) Console.WriteLine("\nTU TARJETA DE DEBITO CUENTA CON SEGURO");
        }
    }
}
