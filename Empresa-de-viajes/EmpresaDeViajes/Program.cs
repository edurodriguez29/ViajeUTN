using System;
using Datos;
using Dominio;

namespace EmpresaDeViajes
{
    internal class Program
    {

<<<<<<< HEAD
        // MGN
=======
        /// <summary>
        /// Pantalla Principal
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>
        static public ConsoleKeyInfo MostrarPantallaPrincipal(Dominio.Empresa Emp)
        {
            ConsoleKeyInfo opcion;
            do {
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("*********// Empresa de viajes : {0} \\**************", Emp.Nombre);
                Console.WriteLine(" Web Page:{0}                                     *", Emp.Webpage);
                Console.WriteLine(" Telefono de Contacto:{0}                        *", Emp.Telefono);
                Console.WriteLine("===================================================");
                Console.WriteLine();
                Console.WriteLine("Bienvenido ingrese una de las siguientes opciones para continuar:");
                Console.WriteLine();
                Console.WriteLine("1 - Clientes");
                Console.WriteLine("2 - Facturas");
                Console.WriteLine("3 - Paquetes");
                Console.WriteLine("Esc - Para salir");
                opcion = Console.ReadKey();
            } while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '3'));
            return opcion;
        }

        /// <summary>
        /// Menu Cliente
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>
        static public ConsoleKeyInfo MostrarMenuCliente()
        {
            ConsoleKeyInfo opcionCliente;
            do {
                Console.Clear();
                Console.WriteLine("********** Menu Cliente ***********");
                Console.WriteLine("Eliga una de las siguientes opciones:");
                Console.WriteLine("1 - Crear un nuevo cliente");
                Console.WriteLine("2 - Ver datos de un cliente");
                Console.WriteLine("3 - Modificar datos de un cliente");
                Console.WriteLine("4 - Eliminar un cliente");
                opcionCliente = Console.ReadKey();
            } while (((int)opcionCliente.KeyChar != 08) && (opcionCliente.KeyChar < '1' || opcionCliente.KeyChar > '4'));
            return opcionCliente;
        }

        static public ConsoleKeyInfo NuevoCliente()
        {
            ConsoleKeyInfo opcion;
            do {
                Console.Clear();
                Console.WriteLine("********** Nuevo Cliente ***********");
                Console.WriteLine("1 - Crear cliente particular");
                Console.WriteLine("2 - Crear cliente corporativo");
                Console.WriteLine("Backspace - Para volver hacia atras");
                opcion = Console.ReadKey();
            } while (((int)opcion.KeyChar != 08) && (opcion.KeyChar < '1' || opcion.KeyChar > '2'));
            return opcion;
        }

        static public void NuevoClienteParticular()
        {
            Dominio.Cliente oClipArt = new Dominio.Cliente();

            Console.Clear();
            Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");

            Console.WriteLine("Particular:"); // imprime "particular : true"
            oClipArt.EsParticular = true;

            Console.Write("Nombre:");
            oClipArt.Nombre = Console.ReadLine();

            Console.Write("Apellido:");
            oClipArt.Apellido= Console.ReadLine();

            Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
            var strfNac = Console.ReadLine();
            oClipArt.Fnac = DateTime.ParseExact(strfNac, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("DNI:");
            oClipArt.Dni= Console.ReadLine();

            Console.Write("Nacionalidad:");
            oClipArt.Nacionalidad= Console.ReadLine();

            Console.Write("Localidad:");
            oClipArt.Localidad= Console.ReadLine();

            Console.Write("Direccion:");
            oClipArt.Direccion= Console.ReadLine();

            Console.Write("Telefono:");
            oClipArt.Telefono= Console.ReadLine();

            Console.Write("Provincia:");
            oClipArt.Provincia= Console.ReadLine();

            //Grabo Cliente
            ClienteContext CCtx = new ClienteContext();
            var retorno = CCtx.PutCliente(oClipArt);
            if (retorno > 0) {
                Console.WriteLine("Se ha creado el Cliente exitosamente, su ID es: {0}", retorno.ToString());
            }
            else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
            Console.WriteLine("");
        }

        static public void NuevoClienteCorporativo()
        {
            Dominio.Corporativo clieCorp = new Dominio.Corporativo();

            Console.Clear();
            Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");

            Console.WriteLine("Particular:"); // imprime "particular : true"
            clieCorp.EsParticular = true;

            Console.Write("Nombre:");
            clieCorp.Nombre = Console.ReadLine();

            Console.Write("Apellido:");
            clieCorp.Apellido = Console.ReadLine();

            Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
            var strfNac = Console.ReadLine();
            clieCorp.Fnac = DateTime.ParseExact(strfNac, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("DNI:");
            clieCorp.Dni = Console.ReadLine();

            Console.Write("Nacionalidad:");
            clieCorp.Nacionalidad = Console.ReadLine();

            Console.Write("Localidad:");
            clieCorp.Localidad = Console.ReadLine();

            Console.Write("Direccion:");
            clieCorp.Direccion = Console.ReadLine();

            Console.Write("Telefono:");
            clieCorp.Telefono = Console.ReadLine();

            Console.Write("Provincia:");
            clieCorp.Provincia = Console.ReadLine();

            Console.Write("CUIT:");
            clieCorp.Cuit = Console.ReadLine();

            Console.Write("Razon social:");
            clieCorp.RazonSocial = Console.ReadLine();

            //Grabo Cliente
            ClienteContext CCtx = new ClienteContext();
            var retorno = CCtx.PutCliente(clieCorp);
            if (retorno > 0) {
                Console.WriteLine("Se ha creado el Cliente exitosamente, su ID es: {0}", retorno.ToString());
            }
            else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
            Console.WriteLine("");
        }

       static public ConsoleKeyInfo QueDeseaHacer()
        {
            ConsoleKeyInfo opcionGuardado;
            do {
                Console.WriteLine();
                Console.WriteLine("1 - Si");
                Console.WriteLine("2 - No");
                Console.WriteLine();
            
                opcionGuardado = Console.ReadKey(true);
            } while (opcionGuardado.KeyChar < '1' || opcionGuardado.KeyChar > '2');
            return opcionGuardado;
        }


        static public ConsoleKeyInfo InfoDeUnCliente()
        {
            ConsoleKeyInfo opcionInfo;
            do {
                Console.Clear();
                Console.WriteLine("*********// VER INFORMACION DE CLIENTES \\********");
                Console.WriteLine();
                Console.WriteLine("Acontinuacion elija el tipo de cliente para acceder a la informacion del mismo:");
                Console.WriteLine("1 - Cliente particular");
                Console.WriteLine("2 - Cliente corporativo");
                Console.WriteLine("Backspace - Para volver al menu principal");
                Console.WriteLine();
                opcionInfo = Console.ReadKey();
            } while (((int)opcionInfo.KeyChar != 08) && (opcionInfo.KeyChar < '1' || opcionInfo.KeyChar > '2'));
            return opcionInfo;
        }

        static public void VerInfoDeUnCliParticular()
        {
            Console.Clear();
            Console.WriteLine("*****************// PARTICULAR \\******************");
            Console.WriteLine();
            Console.Write("Ingrese el numero de cliente: ");

            // Por que dato se va a buscar al cliente???, el ID es autoincremental y uno no tiene forma de saver que ID le toca a cada cliente.

            /*int.TryParse(Console.ReadLine(), out nroCliente);
            Console.WriteLine(deco.b2); // Decoracion de consola
                                        // Por cada elemento (x) de la lista dame el primero que su atributo sea igual a "nroCliente"
            cli = liClientes.Find(x => x.NroCliente == nroCliente);
            if (cli != null) {
                cli.mostrarDatos(); // No me muestra la info del cliente
            }
            else {
                // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                Console.WriteLine(deco.b2);//Decoracion consola
                Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                Console.WriteLine(deco.b2);//Decoracion consola
            }*/
        }

        static public void VerInfoDeUnCliCorporativo()
        {
            Console.Clear();
            Console.WriteLine("*****************// PARTICULAR \\******************");
            Console.WriteLine();
            Console.Write("Ingrese el numero de cliente: ");

            // Por que dato se va a buscar al cliente???, el ID es autoincremental y uno no tiene forma de saver que ID le toca a cada cliente.

            /*int.TryParse(Console.ReadLine(), out nroCliente);
            Console.WriteLine(deco.b2); // Decoracion de consola
                                        // Por cada elemento (x) de la lista dame el primero que su atributo sea igual a "nroCliente"
            cli = liClientes.Find(x => x.NroCliente == nroCliente);
            if (cli != null) {
                cli.mostrarDatos(); // No me muestra la info del cliente
            }
            else {
                // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                Console.WriteLine(deco.b2);//Decoracion consola
                Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                Console.WriteLine(deco.b2);//Decoracion consola
            }*/
        }




        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="args"></param>


>>>>>>> master
        static void Main(string[] args)
        {
            EmpresaContext empresaContext = new Datos.EmpresaContext();
            Dominio.Empresa Emp = empresaContext.GetEmpresa();
            ConsoleKeyInfo RetPantalla;
            SplashInto MainScreen = new SplashInto();

            do {
                //Pantalla Principal
                
                RetPantalla = MainScreen.MostrarPantallaPrincipal(Emp);
                
                switch (RetPantalla.KeyChar) { 
                    case '1':
                        //Muestra Pantalla de Clientes
<<<<<<< HEAD
                        RetPantalla = MainScreen.MostrarMenuCliente();
=======
                        MostrarMenuCliente();
>>>>>>> master
                        switch (RetPantalla.KeyChar) {
                            
                            //Cliente NUevo
                            case '1':
                                RetPantalla = MainScreen.NuevoCliente();
                                switch (RetPantalla.KeyChar) {
                                    case '1':
                                        MainScreen.NuevoClienteParticular();
                                        Console.WriteLine("Desea cargar otro cliente?");
<<<<<<< HEAD
                                        RetPantalla = MainScreen.QueDeseaHacer();
                                        switch(RetPantalla.KeyChar) {
                                            case '1':
                                                MainScreen.NuevoCliente();
                                                break;
                                            case '2':
                                                MainScreen.MostrarPantallaPrincipal(Emp);
=======
                                        QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1': // revisar, no redirecciona
                                                NuevoCliente();
                                                break;
                                            case '2':// revisar, no redirecciona
                                                MostrarMenuCliente();
>>>>>>> master
                                                break;
                                        }
                                        break;
                                    case '2':
                                        MainScreen.NuevoClienteCorporativo();
                                        Console.WriteLine("Desea cargar otro cliente?");
<<<<<<< HEAD
                                        MainScreen.QueDeseaHacer();
                                        switch(RetPantalla.KeyChar) {
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
                                                //Ver infoCliCorporativo !!! Pendiente
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
=======
                                        QueDeseaHacer();
                                        switch (RetPantalla.KeyChar) {
                                            case '1': // revisar, no redirecciona
                                                NuevoCliente();
                                                break;
                                            case '2':// revisar, no redirecciona
                                                MostrarMenuCliente();
>>>>>>> master
                                                break;
                                        }
                                        break;
                                }
                                break;

<<<<<<< HEAD
                            case '3':
                                MainScreen.ModificarCliente(); //Me quede por aca
                                break;
=======
                            // VER INFO DE UN CLIENTE
                            case '2': //Falla, me redirecciona a el menu de crear un nuevo cliente.
                                InfoDeUnCliente();
                               break; 
>>>>>>> master
                        }
                        break;

                    case '2':
                        //Muestra Pantalla de Facturas
                        break;
                    case '3':
                        //Muestra Pantalla de Facturas
                        break;
                }
            } while ((int)RetPantalla.KeyChar != 27);



            Console.Write("FIN");
        
        }

    }
}
