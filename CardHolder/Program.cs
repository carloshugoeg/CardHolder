﻿using CardHolder;
List<Tarjeta> listaTarjetas = new List<Tarjeta>();
List<Cliente> listaClientes = new List<Cliente>(); //cada metodo que trabaje con tarjetas y/o clientes recibe como atributo la lista, ingresarla cuando declaren los metodos aqui
int opcion = 0;
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------");
    Console.WriteLine("      BIENVENIDO");
    Console.WriteLine("------------------------"); Console.ResetColor();
    Console.WriteLine("1. Agregar usuario");
    Console.WriteLine("2. Agregar tarjeta");
    Console.WriteLine("3. Mostrar usuario");
    Console.WriteLine("4. Mostrar tarjeta");
    Console.WriteLine("5. Buscar usuario");
    Console.WriteLine("6. Buscar tarjeta");
    Console.WriteLine("7. Salir");
    Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkYellow; ;
    Console.Write("Ingresa la opcion: ");
    try
    {
        opcion = Convert.ToInt32(Console.ReadLine()); Console.ResetColor ();
        switch (opcion)
        {
            case 1:
                Console.Clear();
                AgregarCliente(listaClientes);
                break;
            case 2: 
                if(listaClientes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Aun no hay usuarios..."); Console.ReadKey(); Console.Clear(); break;
                }
                Console.Clear();
                AgregarTarjeta(listaTarjetas);
                break;
            case 3:
                if (listaClientes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Aun no hay usuarios..."); Console.ReadKey(); Console.Clear(); break;
                }
                Console.Clear();
                MostrarClientes(listaClientes);
                break;
            case 4:
                if (listaTarjetas.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Aun no hay tarjetas..."); Console.ReadKey(); Console.Clear(); break;
                }
                Console.Clear();
                MostrarTarjetas(listaTarjetas);
                break;
            case 5:
                if (listaClientes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Aun no hay usuarios..."); Console.ReadKey(); Console.Clear(); break;
                }
                Console.Clear();
                MensajeContinuar();
                break;
            case 6:
                if (listaTarjetas.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Aun no hay tarjetas..."); Console.ReadKey(); Console.Clear(); break;
                }
                Console.Clear();
                MensajeContinuar();
                break;
            case 7:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------");
                Console.WriteLine("        ADIÓS :)");
                Console.WriteLine("------------------------"); Console.ResetColor();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Esta opción no existe. Intenta de nuevo");
                MensajeContinuar();
                break;
        }
    }
    catch (FormatException)
    {
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine("Error de formato. Intenta de nuevo");
        MensajeContinuar();
    }
} while (opcion != 7);

void MensajeContinuar()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("Presiona ENTER para continuar");
    Console.ReadKey(); Console.Clear(); Console.ResetColor();
}

void AgregarCliente(List<Cliente> listaClientes)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------");
    Console.WriteLine("     Agregar Usuario");
    Console.WriteLine("------------------------"); Console.ResetColor();
    Console.WriteLine(); Console.ResetColor();
    Console.Write("Nombre: ");
    string nombreCliente = Console.ReadLine();
    Console.Write("DPI: ");
    string dpi = Console.ReadLine();
    Console.Write("Numero de cuenta: ");
    string numeroCuenta = Console.ReadLine();

    Cliente nuevoCliente = new Cliente(nombreCliente, dpi, numeroCuenta);
    listaClientes.Add(nuevoCliente);

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Cliente agregado con éxito.");
    MensajeContinuar();
}

void MostrarClientes(List<Cliente> listaClientes)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------");
    Console.WriteLine("     Mostrar Clientes");
    Console.WriteLine("------------------------");
    Console.ResetColor();

    foreach (var cliente in listaClientes)
    {
        cliente.MostrarInfo();
        Console.WriteLine();
    }

    MensajeContinuar();
}

void AgregarTarjeta(List<Tarjeta> listaTarjetas)
{
    int opcionTarjeta = 0;
    Tarjeta tarjeta = new Tarjeta("", "", null, 0);
    do
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("                      Agregar Tarjeta");
        Console.WriteLine("------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine("¿Qué tipo de tarjeta desea agregar? ");
        Console.WriteLine("(1: Débito, 2: Crédito, 3: Regresar a menú principal): ");
        try
        {
            opcionTarjeta = Convert.ToInt32(Console.ReadLine());
            
            switch(opcionTarjeta)
            {
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------TARJETA DE DÉBITO------");
                    Console.ResetColor();
                    tarjeta.AgregarInformacion(listaTarjetas, listaClientes, esCredito: false);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Tarjeta agregada con éxito.");
                    MensajeContinuar();
                    break;
                case 2:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------TARJETA DE CRÉDITO------");
                    Console.ResetColor();
                    tarjeta.AgregarInformacion(listaTarjetas, listaClientes, esCredito: true);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Tarjeta agregada con éxito.");
                    MensajeContinuar();
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Esta opción no existe. Intenta de nuevo");
                    MensajeContinuar();
                    break;
            }
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error de formato. Intenta de nuevo");
            MensajeContinuar();
        }
    } while (opcionTarjeta != 3);
}

void MostrarTarjetas(List<Tarjeta> listaTarjetas)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------");
    Console.WriteLine("     Mostrar Tarjetas");
    Console.WriteLine("------------------------");
    Console.ResetColor();

    foreach(var tarjeta in listaTarjetas)
    {
        tarjeta.MostrarInformacion();
        Console.WriteLine();
    }
    MensajeContinuar();
}