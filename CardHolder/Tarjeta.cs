using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
        protected Cliente TitularTarjeta { get; set; }
        protected int CVV { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Numero Tarjeta: " + NumeroTarjeta);
            Console.WriteLine("Fecha de vencimiento: " + FechaVencimiento);
            Console.WriteLine("Titular: " + TitularTarjeta.Nombre); //ACÁ SE DEBERÍA LLAMAR AL NOMBRE
            Console.WriteLine("CVV: " + CVV);
        }

        public void AgregarInformacion(List<Tarjeta> listaTarjetas, List<Cliente> clienteList, bool esCredito)
        {
            string numeroTarjeta;
            string fechaVencimiento;
            int cVV;
            bool tieneSeguro;
            do
            {
                Console.Write("Ingrese Número de Tarjeta: ");
                numeroTarjeta = Console.ReadLine();
                int numeroValidacion;
                if (int.TryParse(numeroTarjeta, out numeroValidacion))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("El DPI esta en formato incorrecto\n\n");
                    Console.ResetColor();
                }
            } while (true);

            Console.Write("Ingrese Fecha de Vencimiento (MM/YY): ");
            fechaVencimiento = Console.ReadLine();

            Cliente titularTarjeta = new Cliente("", "", "");
            string dpi;
            int indice;
            do
            {
                Console.Write("Ingrese DPI del titular: ");
                dpi = Console.ReadLine();
                indice = titularTarjeta.BuscarCliente(clienteList, dpi); 
                
            } while (indice < 0);
            titularTarjeta = clienteList[indice];    
            Console.Write("Ingrese CVV: ");
            cVV = PedirInt();
            if (!esCredito)
            {
                Console.Write("¿La tarjeta tiene seguro? (y/n): ");
                string seguro = Console.ReadLine().ToLower().Trim();
                if (seguro == "y")
                {
                    tieneSeguro = true;
                }
                else tieneSeguro = false;
                TarjetaDebito NuevaTarjetaDebito = new TarjetaDebito(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV, tieneSeguro);
                listaTarjetas.Add(NuevaTarjetaDebito);
                return;
            }
            Console.Write("Límite de Crédito: Q");
            decimal limiteCredito = PedirPrecio();

            Console.Write("Saldo Utilizado: Q");
            decimal saldoUtilizado = PedirPrecio();

            Console.Write("Ingrese Interes (en decimal): ");
            decimal interes = PedirPrecio();

            Console.WriteLine("Ingrese deuda actual: (en caso que no aplique. coloque 0)");
            Console.Write("Q.");
            decimal deuda = PedirPrecio();

            listaTarjetas.Add(new TarjetaCredito(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV, limiteCredito, interes, deuda, saldoUtilizado));
        }      
        public void BuscarInformacion(List<Tarjeta> listaTarjetas)
        {
            bool Encontrado = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("            Buscar Tarjetas");
            Console.WriteLine("-----------------------------------------\n");
            Console.ResetColor();
            Console.Write("Ingresa el número de tarjeta: ");
            string NumeroTarjeta = Console.ReadLine();

            foreach (var Buscando in listaTarjetas)
            {
                if (Buscando.NumeroTarjeta == NumeroTarjeta)
                {
                    Buscando.MostrarInformacion();
                    Encontrado = true;

                }
            }
            if (!Encontrado)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Tarjeta no encontrada."); Console.ResetColor();
            }

        }
        decimal PedirPrecio()
        {
            do
            {
                try
                {
                    decimal precio;
                    precio = decimal.Parse(Console.ReadLine());
                    return precio;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
            } while (true);
        }
        int PedirInt()
        {
            do
            {
                try
                {
                    int monto;
                    monto = int.Parse(Console.ReadLine());
                    return monto;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Tarjeta-----");
                }
            } while (true);
        }


    }
}
