using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Datos;
using Dominio;

namespace EmpresaDeViajes
{
    internal class Program
    {

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
            ConsoleKeyInfo opcion;
            do {
                Console.Clear();
                Console.WriteLine("********** Menu Cliente ***********");
                Console.WriteLine("Eliga una de las siguientes opciones:");
                Console.WriteLine("1 - Crear un nuevo cliente");
                Console.WriteLine("2 - Ver datos de un cliente");
                Console.WriteLine("3 - Modificar datos de un cliente");
                Console.WriteLine("4 - Ver listado de clientes");
                Console.WriteLine("5 - Eliminar un cliente");
                opcion = Console.ReadKey();
            } while (((int)opcion.KeyChar != 08) && (opcion.KeyChar < '1' || opcion.KeyChar > '5'));
            return opcion;
        }

        static public ConsoleKeyInfo MostrarMenuNuevoCliente()
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


        static void Main(string[] args)
        {
            //Nuevo Modelos de Datos
            EmpresaContext empresaContext = new Datos.EmpresaContext();
            Dominio.Empresa Emp = empresaContext.GetEmpresa();
            ConsoleKeyInfo RetPantalla;
            //Nuevo Modelos de Datos

            do {
                //Pantalla Principal
                RetPantalla = MostrarPantallaPrincipal(Emp);
                
                switch (RetPantalla.KeyChar) { 
                    case '1':
                        //Muestra Pantalla de Clientes
                        RetPantalla = MostrarMenuCliente();
                        switch (RetPantalla.KeyChar) {
                            case '1':
                                RetPantalla = MostrarMenuCliente();
                                break;
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


            ConsoleKeyInfo opcion;
            string nombre, apellido, dni, nacionalidad, localidad, direccion, telefono,Provincia;
            string cuit, razonSocial;
            byte edad;
            int id;
            bool esParticular;
            ConsoleKeyInfo opcionCliente;
            Cliente cli;
            List<Cliente> liClientes = new List<Cliente>();
            List<Corporativo> clienteCorp = new List<Corporativo> ();
            ConsoleKeyInfo opcionTipoCliente;
            ConsoleKeyInfo opcionGuardado;



            // Menu principal
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
            } while (((int) opcion.KeyChar != 27) && (opcion.KeyChar< '1' || opcion.KeyChar> '3'));

            // Menu principal
            do {
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("*********// Empresa de viajes : {0} \\**************", Emp.Nombre);
                Console.WriteLine(" Web Page:{0}                                     *",Emp.Webpage);
                Console.WriteLine(" Telefono de Contacto:{0}                        *", Emp.Telefono);
                Console.WriteLine("===================================================");
                Console.WriteLine();
                Console.WriteLine("Bienvenido ingrese una de las siguientes opciones para continuar:");
                Console.WriteLine();
                Console.WriteLine("1 - Clientes");
                Console.WriteLine("2 - Facturas");
                Console.WriteLine("3 - Paquetes");
                Console.WriteLine("Esc - Para salir");
                    
                    do {
                        opcion = Console.ReadKey(true);// Con TRUE evito que se muestre el numero de opcion elegido
                    } while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '3'));

                    switch (opcion.KeyChar) {

                        // Submenu cliente
                        case '1':
                            Console.Clear();
                            Console.WriteLine("********** Menu Cliente ***********");
                            Console.WriteLine("Eliga una de las siguientes opciones:");
                            Console.WriteLine("1 - Crear un nuevo cliente");
                            Console.WriteLine("2 - Ver datos de un cliente");
                            Console.WriteLine("3 - Modificar datos de un cliente");
                            Console.WriteLine("4 - Ver listado de clientes");
                            Console.WriteLine("5 - Eliminar un cliente");
                            Console.WriteLine("Backspace - Para volver hacia atras");
                            do {/*
                                 *  El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola.El "O8"
                                 *  corresponde al codico ASCII de la tecla retroceso.
                                 */
                              opcionCliente = Console.ReadKey(true);
                            } while (((int)opcionCliente.KeyChar != 08) && (opcionCliente.KeyChar < '1' || opcionCliente.KeyChar > '5'));

                            ClienteContext CCtx;

                            switch (opcionCliente.KeyChar) {
                                // Menu para crear tipos de clientes
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("********** Nuevo Cliente ***********");
                                    Console.WriteLine("1 - Crear cliente particular");
                                    Console.WriteLine("2 - Crear cliente corporativo");
                                    Console.WriteLine("Backspace - Para volver hacia atras");
                                    do {/* El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola. El "O8" 
                                         * corresponde al codico ASCII de la tecla retroceso.
                                         */
                                        opcionTipoCliente = Console.ReadKey(true);
                                    } while (((int)opcionTipoCliente.KeyChar != 08) && (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                    switch (opcionTipoCliente.KeyChar) {
                                   
                                     //Cliente Particular
                                    case '1':
                                    
                                        Console.Clear();
                                        Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");

                                        Console.WriteLine("Particular:"); // imprime "particular : true"
                                        esParticular = true;

                                        Console.Write("Nombre:");
                                        nombre = Console.ReadLine();

                                        Console.Write("Apellido:");
                                        apellido = Console.ReadLine();

                                        Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
                                        var strfNac = Console.ReadLine();

                                        DateTime fNacimiento = DateTime.ParseExact("01-12-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture);

                                        Console.Write("DNI:");
                                        dni = Console.ReadLine();

                                        Console.Write("Nacionalidad:");
                                        nacionalidad = Console.ReadLine();

                                        Console.Write("Localidad:");
                                        localidad = Console.ReadLine();

                                        Console.Write("Direccion:");
                                        direccion = Console.ReadLine();

                                        Console.Write("Telefono:");
                                        telefono = Console.ReadLine();

                                        Console.Write("Provincia:");
                                        Provincia = Console.ReadLine();

                                        //Creo Cliente
                                        Dominio.Cliente ocliente = new Dominio.Cliente(esParticular, nombre, apellido, fNacimiento, dni, nacionalidad, localidad, direccion, telefono, Provincia);
                                        
                                        //Grabo Cliente
                                        CCtx = new ClienteContext();
                                        var retorno = CCtx.PutCliente(ocliente);
                                        if (retorno > 0) {
                                            Console.WriteLine("Se ha creado el Cliente exitosamente, su ID es: {0}", retorno.ToString());
                                        }
                                        else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
                                        Console.WriteLine("");
                                        break;

                                    //Cliente Corporativo
                                    case '2':

                                        Console.Clear();
                                        Console.WriteLine("***********// NUEVO CLIENTE CORPORATIVO \\***********");

                                        esParticular = false;

                                        Console.Write("Nombre:");
                                        nombre = Console.ReadLine();

                                        Console.Write("Apellido:");
                                        apellido = Console.ReadLine();

                                        Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
                                        strfNac = Console.ReadLine();

                                        fNacimiento = DateTime.ParseExact("01-12-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture);

                                        Console.Write("DNI del cliente:");
                                        dni = Console.ReadLine();

                                        Console.Write("Nacionalidad:");
                                        nacionalidad = Console.ReadLine();

                                        Console.Write("Localidad:");
                                        localidad = Console.ReadLine();

                                        Console.Write("Direccion:");
                                        direccion = Console.ReadLine();

                                        Console.Write("Telefono:");
                                        telefono = Console.ReadLine();

                                        Console.Write("Provincia:");
                                        Provincia = Console.ReadLine();

                                        Console.Write("CUIT:");
                                        cuit = Console.ReadLine();

                                        Console.Write("Razon social:");
                                        razonSocial = Console.ReadLine();

                                        Dominio.Corporativo cliCorp = new Dominio.Corporativo(esParticular, nombre, apellido, fNacimiento, dni, nacionalidad, localidad, direccion, telefono, cuit, razonSocial, true, Provincia);

                                        CCtx = new ClienteContext();
                                        retorno = CCtx.PutClienteCorp(cliCorp);
                                        if (retorno > 0) {
                                            Console.WriteLine("Se ha creado el Cliente Corporativo exitosamente, su ID es: {0}", retorno.ToString());
                                        }
                                        else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
                                        Console.WriteLine("");
                                        break;
                                }
                                break;

                            case '2':
                                Console.WriteLine("Ingrese el ID de cliente:");
                                /*
                                 * Generar codigo para leer info de cliente
                                 * 
                                 * Tambien tiene que tener la opcion de volver hacia atras para ver info de otro cliente.
                                 */

// TE QUEDASTE POR Acaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
// No sabes que clase de cliente va a mostrar, porque son de dos tipo corp y parti. Como vas a hacer para que muestre la info del cliente, sin inportar el tipo de cliente
                                Console.WriteLine("Ingrese ID de cliente:");
                                int.TryParse(Console.ReadLine(), out id);


                                break;
                            case '3':
                                Console.WriteLine("Ingrese el ID del cliente para modificar los datos del mismo:");
                                /*
                                 * Codigo a generar para modificar los datos de un cliente
                                 * 
                                 * 
                                 * Tambien tiene que tener la opcion de volver hacia atras para modificar otro cliente.
                                 * 
                                 * antes de volver a atras o guardar cambios, se debe confirmar con dos opciones, una para
                                 * guardar cambios y otra para cancelar los mismos.
                                 * 
                                 */
                                break;

                            case '4':
                                Console.WriteLine("Acontinuacion se detalla la lista de clientes registrados:");
                                /*
                                 * Se puede SOLO ver todos los clientes registrados con sus datos
                                 * 
                                 * 
                                 * Tiene que tener la opcion de volver al menu de clientes
                                 * 
                                 */
                                break;

                            case '5':
                                Console.WriteLine("Ingrese ID del cliente a eliminar:");
                                /*
                                 * Codigo para eliminar a cliente por ID.
                                 * 
                                 * Debe haber una confirmacion para la elimin acion del usuario con un mensaje de salida 
                                 * para ambas opciones a elegir.
                                 * 
                                 */
                                break;

                            } 
                        while ((int)opcionCliente.KeyChar != 08) ;
                        break; // Fin seccion de menu de clientes.

                    // Menu factura
                    case '2':
                        break;
                }
            } while ((int)opcion.KeyChar != 27);// Codigo ASCII del boton "Esc"
        
        
        }

    }
}
