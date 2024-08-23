using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHolder
{
    internal class TarjetaCredito : Tarjeta
    {
       private decimal CreditoMaximo {  get; set; }
       private decimal Interes {  get; set; } // este se pone en decimal tipo 0.10
       private decimal Deuda {  get; set; } // en caso de no tener deuda se queda como 0 y se calcula sobre el saldo mensual
       private decimal SaldoMensual {  get; set; }
       public TarjetaCredito(string numeroTarjeta, string fechaVencimiento, Cliente titularTarjeta, int cVV, decimal creditoMaximo, decimal interes, decimal deuda, decimal saldoMensual)
       : base(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV)
        {
            CreditoMaximo = creditoMaximo;
            Interes = interes;
            Deuda = deuda;
            SaldoMensual = saldoMensual;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("\nTipo tarjeta: CREDITO");
            Console.WriteLine("Credito Maximo: Q." + CreditoMaximo);
            Console.WriteLine("Interes: " + (Interes*100)+"%");
            if (Deuda > 0)
            {
                Console.WriteLine($"Deuda : Q.{Deuda}"); 
            }
            Console.WriteLine("Saldo Utilizado: Q."+SaldoMensual);
        }
    }
}
