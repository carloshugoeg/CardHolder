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
        public void AgregarInformacionDebito()
        {
            Console.Write("Ingrese Numero de Tarjeta: ");
            string NuevoNumero = Console.ReadLine(); 
            Console.Write("Ingrese Fecha de Vencimiento(MM/YY): ");
            string NuevoVencimiento = Console.ReadLine();
            Console.Write("Ingrese Nuevo CVV: ");
            int NuevoCvv = Convert.ToInt32(Console.ReadLine);
            Console.Write("Ingrese Nombre del titular de Tarjeta: ");
            string NuevoNombre = Console.ReadLine();
            Tarjeta NuevaTarjeta = new Tarjeta(NuevoNumero, NuevoVencimiento, NuevoCvv);
            TarjetaDebito.Add(NuevaTarjeta);
        }
        public void BuscarInformacion()
        {


        }
        public void EliminarInformacion()
        {

        }
    }
}
