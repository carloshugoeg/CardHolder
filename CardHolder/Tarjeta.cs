using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHolder
{
    internal class Tarjeta
    {
        public Tarjeta(string numeroTarjeta, string fechaVencimiento, Cliente titularTarjeta, int cVV)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaVencimiento = fechaVencimiento;
            TitularTarjeta = titularTarjeta;
            CVV = cVV;
        }

        protected string NumeroTarjeta { get; set; }
        protected string FechaVencimiento { get; set; }
        //Para ingresar fecha de vencimiento se piden dos numeros (try catch) y
        //luego se unen en un string "mm / yy" si quieren lo hago luego
        protected Cliente TitularTarjeta { get; set; }
        protected int CVV { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("-----TARJETA-----");
            Console.WriteLine("\nNumero Tarjeta: " + NumeroTarjeta);
            //Aqui siguen ustedes
        }
    }
}
