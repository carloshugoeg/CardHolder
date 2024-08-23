using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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

        public string Nombre { get; set; }
        private string DPI { get; set; }
        private string NumeroCuenta { get; set; }
        private List<Tarjeta> TarjetasCliente { get; set; } //se crea un metodo publico agregar tarjetas que reciba una List

        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"DPI: {DPI}");
            Console.WriteLine($"Numero de Cuenta: {NumeroCuenta}");
            if( TarjetasCliente != null)
            {
                foreach(Tarjeta tarjeta in TarjetasCliente)
                {
                    tarjeta.MostrarInformacion();
                }
            }

        }
        public void AgregarTarejas(List<Tarjeta> tarjetas)
        {
            TarjetasCliente.AddRange(tarjetas);
        }
        public void AgregarCliente(string nombre, string dpi, string numeroCuenta, List<Cliente> listaClientes)
        {
            //este metodo mejor creanlo en el main usando la lista que esta en el main
        }
        public bool EliminarCliente(string dPI, List<Cliente> listaClientes)
        {
            int indice = listaClientes.FindIndex(c => c.DPI == dPI);
            if (indice != -1)
            {
                listaClientes.RemoveAt(indice);
                return true;
            }
            return false;
            //este metodo mejor creanlo en el main usando la lista que esta en el main
        }
        public int BuscarCliente(List<Cliente> clientes, string dPI)
        {
            int indice = clientes.FindIndex(c => c.DPI == dPI);
            if (indice != -1)
            {
                return indice;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Usuario no encontrado."); Console.ResetColor();
                return -1;
            }
        }
        public int BuscarCliente(List<Cliente> clientes, string dPI, bool esValidacion)
        {
            int indice = clientes.FindIndex(c => c.DPI == dPI);
            if (indice != -1)
            {
                return indice;
            }
            return -1;
            
        }
    }
}
