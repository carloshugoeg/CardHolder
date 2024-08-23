using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardHolder
{
    internal class Tarjeta 
    {
        private static List<Tarjeta> listaTarjetas = new List<Tarjeta>();
        public Tarjeta(string numeroTarjeta, string fechaVencimiento, Cliente titularTarjeta, int cVV)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaVencimiento = fechaVencimiento;
            TitularTarjeta = titularTarjeta;
            CVV = cVV;
            
        }
         

        protected string NumeroTarjeta { get; set; }
        protected string FechaVencimiento { get; set; }
        protected Cliente TitularTarjeta { get; set; }
        protected int CVV { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("-----TARJETA-----");
            Console.WriteLine("\nNumero Tarjeta: " + NumeroTarjeta);

        }
        
        public void AgregarInformacionDebito()
        {
            Console.Write("Ingrese Número de Tarjeta: ");
            string numeroTarjeta = Console.ReadLine();

            Console.Write("Ingrese Fecha de Vencimiento (MM/YY): ");
            string fechaVencimiento = Console.ReadLine();

            Console.Write("Ingrese CVV: ");
            int cVV = Convert.ToInt32(Console.ReadLine());

            Console.Write("¿La tarjeta tiene seguro? (si/no): ");
            bool tieneSeguro = Convert.ToBoolean(Console.ReadLine());

            TarjetaDebito NuevaTarjetaDebito = new TarjetaDebito(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV, tieneSeguro);
            listaTarjetas.Add(NuevaTarjetaDebito);
                    }
        public  void AgregarInformacionCredito()
        {
            Console.Write("Ingrese Número de Tarjeta: ");
            string numeroTarjeta = Console.ReadLine();

            Console.Write("Ingrese Fecha de Vencimiento (MM/YY): ");
            string fechaVencimiento = Console.ReadLine();

            Console.Write("Ingrese Nombre del Titular de la Tarjeta: ");
            string nombreTitular = Console.ReadLine();

            Console.Write("Ingrese CVV: ");
            int NuevoCvv = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese Límite de Crédito: ");
            double limiteCredito = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese Saldo Utilizado: ");
            double saldoUtilizado = Convert.ToDouble(Console.ReadLine());

            TarjetaCredito NuevaTarjetaCredito = new TarjetaCredito(numeroTarjeta, fechaVencimiento, titularTarjeta, NuevoCvv, limiteCredito, saldoUtilizado);
            listaTarjetas.Add(NuevaTarjetaCredito);
        }        
        public void BuscarInformacion()
        {
            bool Encontrado = false;
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("     BUSCAR TARJETA");
Console.WriteLine("------------------------\n");
Console.Write("Número de cuenta: ");
string NumeroTarjeta = Console.ReadLine();

foreach (var Buscando in listaTarjetas)
{
    if (Buscando.NumeroTarjeta == NumeroTarjeta)
    {
        Console.WriteLine("Cliente Encontrado");
        Buscando.MostrarInformacion();
        Encontrado = true;

    }
}
if (!Encontrado)
{
    Console.WriteLine("Cliente no encontrado...");
}

        }
      
    }
}
