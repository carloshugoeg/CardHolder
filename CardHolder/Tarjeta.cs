﻿using System;
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
            Console.WriteLine("-----TARJETA-----");
            Console.WriteLine("\nNumero Tarjeta: " + NumeroTarjeta);

        }

        public void AgregarInformacion(List<Tarjeta> listaTarjetas, List<Cliente> clienteList, bool esCredito)
        {
            string numeroTarjeta;
            string fechaVencimiento;
            int cVV;
            bool tieneSeguro;
            Console.Write("Ingrese Número de Tarjeta: ");
            numeroTarjeta = Console.ReadLine();

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
            cVV = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("Límite de Crédito ");
            decimal limiteCredito = PedirPrecio();

            Console.WriteLine("Saldo Utilizado");
            decimal saldoUtilizado = PedirPrecio();

            Console.WriteLine("Ingrese Interes (en decimal)");
            decimal interes = PedirPrecio();

            Console.WriteLine("Ingrese deuda actual: (en caso que no aplique. coloque 0)");
            decimal deuda = PedirPrecio();

            listaTarjetas.Add(new TarjetaCredito(numeroTarjeta, fechaVencimiento, titularTarjeta, cVV, limiteCredito, interes, deuda, saldoUtilizado));
        }      
        public void BuscarInformacion(List<Tarjeta> listaTarjetas)
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
        decimal PedirPrecio()
        {
            do
            {
                try
                {

                        decimal precio;
                        Console.Write("Ingrese el monto: Q.");
                        precio = decimal.Parse(Console.ReadLine());
                        if (precio == 0 || precio == null)
                        {
                            Console.WriteLine("Valor no puede ser 0");
                            Console.ReadLine();
                        }
                    return precio;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("INPUT INVALIDO");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("EL numero es demasiado grande");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-----Nueva Venta-----");
                }
            } while (true);
        }


    }
}
