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
        static List<Cliente> listaClientes = new List<Cliente>();
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

        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"DPI: {DPI}");
            Console.WriteLine($"Numero de Cuenta: {NumeroCuenta}");

        }
        public void AgregarTarejas(List<Tarjeta> tarjetas)
        {
            TarjetasCliente.AddRange(tarjetas);
        }
        public void AgregarCliente(string nombre, string dpi, string numeroCuenta)
        {
            Cliente nuevoCliente = new Cliente(nombre, dpi, numeroCuenta);
            listaClientes.Add(nuevoCliente);
        }
        public bool EliminarCliente(string dPI)
        {
            int indice = listaClientes.FindIndex(c => c.DPI == dPI);
            if (indice != -1)
            {
                listaClientes.RemoveAt(indice);
                return true;
            }
            return false;
        }
        public void BuscarCliente(string dPI)
        {
            int indice = listaClientes.FindIndex(c => c.DPI == dPI);

            if (indice != -1)
            {
                Console.WriteLine($"Cliente encontrado en el índice {indice}:");
                listaClientes[indice].MostrarInfo();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
