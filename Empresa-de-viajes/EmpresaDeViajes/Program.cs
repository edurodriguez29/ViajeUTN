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
                                NuevoCliente();
                                switch (RetPantalla.KeyChar) {
                                    case '1':
                                        NuevoClienteParticular();
                                        break;
                                }
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
        
        }

    }
}
