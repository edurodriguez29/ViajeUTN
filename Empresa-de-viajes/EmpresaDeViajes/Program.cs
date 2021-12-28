using System;
using Datos;
using Dominio;

namespace EmpresaDeViajes
{
    internal class Program
    {

        // MGN
        static void Main(string[] args)
        {
            EmpresaContext empresaContext = new Datos.EmpresaContext();
            Empresa Emp = empresaContext.GetEmpresa();
            ConsoleKeyInfo RetPantalla;
            SplashInto MainScreen = new SplashInto();

            do {
                //Pantalla Principal

                RetPantalla = MainScreen.MostrarPantallaPrincipal(Emp);

                switch (RetPantalla.KeyChar) {
                    case '1':
                        //Muestra Pantalla de Clientes
                        RetPantalla = MainScreen.MostrarMenuCliente();
                        switch (RetPantalla.KeyChar) {

                            //Cliente NUevo
                            case '1':
                                RetPantalla = MainScreen.NuevoCliente();
                                switch (RetPantalla.KeyChar) {
                                    case '1':
                                        MainScreen.NuevoClienteParticular();
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        RetPantalla = MainScreen.QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1':
                                                MainScreen.NuevoCliente();
                                                break;
                                            case '2':
                                                MainScreen.MostrarPantallaPrincipal(Emp);
                                                break;
                                        }
                                        break;

                                    case '2':
                                        MainScreen.NuevoClienteCorporativo();
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        MainScreen.QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1':
                                                MainScreen.NuevoCliente();
                                                break;
                                            case '2':
                                                MainScreen.MostrarPantallaPrincipal(Emp);
                                                break;
                                        }
                                        break;
                                }
                                break;
                            //Ver Cliente
                            case '2':
                                RetPantalla = MainScreen.VerInfoCli();
                                switch (RetPantalla.KeyChar) {
                                    case '1':
                                        MainScreen.VerUnParticular();
                                        Console.Clear();
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        RetPantalla = MainScreen.QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1':
                                                MainScreen.VerUnParticular();
                                                break;
                                            case '2':
                                                MainScreen.VerUnCorporativo();
                                                break;
                                        }
                                        break;

                                    case '2':
                                        MainScreen.VerUnCorporativo();//terminar, esta incompleto
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        MainScreen.QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1':
                                                MainScreen.VerInfoCli();
                                                break;
                                            case '2':
                                                MainScreen.MostrarPantallaPrincipal(Emp);
                                                break;
                                        }
                                        break;
                                }
                                break;

                            case '3':
                                MainScreen.ModificarCliente(); //Me quede por aca
                                break;
                        }
                        break;
                    case '2':
                        //Muestra Pantalla de Facturas
                        break;
                    case '3':
                        //Paquetes
                        RetPantalla = MainScreen.MostrarMenuPaquete();
                        switch (RetPantalla.KeyChar) {
                            //1 - Crear Nuevo Paquete
                            case '1':
                                MainScreen.CrearNuevoPaquete();
                                break;
                            //2 - Listar Paquetes
                            case '2':
                                break;
                        }
                        break;
                    case '4':
                        //Facturacion
                        RetPantalla = MainScreen.MostrarMenuVentas();
                        switch (RetPantalla.KeyChar) {
                            //Facturar a Cliente
                            case '1':
                                MainScreen.FacturarACliente();
                                break;
                            //2 - Listar Factura
                            case '2':
                                MainScreen.ListarFacturaCliente();
                                break;
                        }
                        break;
                }
            } while ((int)RetPantalla.KeyChar != 27);



            Console.Write("FIN");


        }

    }
}
