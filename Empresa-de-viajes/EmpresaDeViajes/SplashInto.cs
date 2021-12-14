using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace EmpresaDeViajes
{
    public class SplashInto
    {
        /// <summary>
        /// Pantalla Principal
        /// </summary>
        /// <returns></returns>
        public ConsoleKeyInfo MostrarPantallaPrincipal(Dominio.Empresa Emp)
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
                Console.WriteLine("4 - Ventas");
                Console.WriteLine("Esc - Para salir");
                opcion = Console.ReadKey();
            } while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '4'));
            return opcion;
        }

        /// <summary>
        /// Menu Cliente
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>
        public ConsoleKeyInfo MostrarMenuCliente()
        {
            ConsoleKeyInfo opcion;
            do {
                Console.Clear();
                Console.WriteLine("********** Menu Cliente ***********");
                Console.WriteLine("Eliga una de las siguientes opciones:");
                Console.WriteLine("1 - Crear un nuevo cliente");
                Console.WriteLine("2 - Ver datos de un cliente");
                Console.WriteLine("3 - Modificar datos de un cliente");
                Console.WriteLine("4 - Eliminar un cliente");
                opcion = Console.ReadKey();
            } while (((int)opcion.KeyChar != 27) && ((int)opcion.KeyChar >= 1 && (int)opcion.KeyChar <= 4));
            return opcion;
        }

        public ConsoleKeyInfo NuevoCliente()
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

        public void NuevoClienteParticular()
        {
            Dominio.Cliente oClipArt = new Dominio.Cliente();

            Console.Clear();
            Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");

            Console.WriteLine("Particular:"); // imprime "particular : true"
            oClipArt.EsParticular = true;

            Console.Write("Nombre:");
            oClipArt.Nombre = Console.ReadLine();

            Console.Write("Apellido:");
            oClipArt.Apellido = Console.ReadLine();

            Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
            var strfNac = Console.ReadLine();
            oClipArt.Fnac = DateTime.ParseExact(strfNac, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("DNI:");
            oClipArt.Dni = Console.ReadLine();

            Console.Write("Nacionalidad:");
            oClipArt.Nacionalidad = Console.ReadLine();

            Console.Write("Localidad:");
            oClipArt.Localidad = Console.ReadLine();

            Console.Write("Direccion:");
            oClipArt.Direccion = Console.ReadLine();

            Console.Write("Telefono:");
            oClipArt.Telefono = Console.ReadLine();

            Console.Write("Provincia:");
            oClipArt.Provincia = Console.ReadLine();

            //Grabo Cliente
            ClienteContext CCtx = new ClienteContext();
            var retorno = CCtx.PutCliente(oClipArt);
            if (retorno > 0) {
                Console.WriteLine("Se ha creado el Cliente exitosamente, su ID es: {0}", retorno.ToString());
            }
            else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
            Console.WriteLine("");
        }

        public void NuevoClienteCorporativo()
        {
            Dominio.Corporativo corp = new Dominio.Corporativo();

            Console.Clear();
            Console.WriteLine("***********// NUEVO CLIENTE CORPORATIVO \\***********");

            Console.WriteLine("Particular:"); // imprime "particular : true"
            corp.EsParticular = true;

            Console.WriteLine("Corporativo"); // imprime "particular : true"
            corp.EsCorporativo = true;

            Console.Write("Nombre:");
            corp.Nombre = Console.ReadLine();

            Console.Write("Apellido:");
            corp.Apellido = Console.ReadLine();

            Console.Write("Fecha de Nacimiento(DD-MM-AAAA):");
            var strfNac = Console.ReadLine();
            corp.Fnac = DateTime.ParseExact(strfNac, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("DNI:");
            corp.Dni = Console.ReadLine();

            Console.Write("Nacionalidad:");
            corp.Nacionalidad = Console.ReadLine();

            Console.Write("Localidad:");
            corp.Localidad = Console.ReadLine();

            Console.Write("Direccion:");
            corp.Direccion = Console.ReadLine();

            Console.Write("Telefono:");
            corp.Telefono = Console.ReadLine();

            Console.Write("CUIT:");
            corp.Cuit = Console.ReadLine();

            Console.Write("Razon social:");
            corp.RazonSocial = Console.ReadLine();


            //Grabo Cliente
            ClienteContext CCtx = new ClienteContext();
            var retorno = CCtx.PutCliente(corp);
            if (retorno > 0) {
                Console.WriteLine("Se ha creado el Cliente exitosamente, su ID es: {0}", retorno.ToString());
            }
            else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
            Console.WriteLine("");
        }


        public ConsoleKeyInfo QueDeseaHacer()
        {
            //!!!!!!Revisar, porque no vuleve al menu principal, solo redirecciona a "NuevoCliente"¡¡¡¡¡¡
            ConsoleKeyInfo opcionGuardado;
            do {
                Console.WriteLine("1 - Si");
                Console.WriteLine("2 - No");
                opcionGuardado = Console.ReadKey(false);
            } while (opcionGuardado.KeyChar < '1' || opcionGuardado.KeyChar > '2');
            return opcionGuardado;
        }

        public ConsoleKeyInfo VerInfoCli()
        {
            ConsoleKeyInfo opcionInfo;

            do {
                Console.Clear();
                Console.WriteLine("*********// VER INFORMACION DE CLIENTES \\********");
                Console.WriteLine();//Decoracion consola
                Console.WriteLine("Acontinuacion elija el tipo de cliente para acceder a la informacion del mismo:");
                Console.WriteLine();// Decoracion de consola
                Console.WriteLine("1 - Cliente particular");
                Console.WriteLine("2 - Cliente corporativo");
                Console.WriteLine("Backspace - Para volver al menu principal");
                Console.WriteLine();//Decoracion consola
                Console.WriteLine();//Decoracion consola
                //80-->BackSpace
                //27-->Escape
                opcionInfo = Console.ReadKey(false);
            } while (((int)opcionInfo.KeyChar != 08) && ((int)opcionInfo.KeyChar >= 1 && (int)opcionInfo.KeyChar <= 2) && (int)opcionInfo.KeyChar != 27);
            return opcionInfo;
        }

        public void VerUnParticular()
        {
            ConsoleKeyInfo opcionInfo;
            Console.WriteLine("*****************// VER CLIENTE PARTICULAR \\******************");

            ClienteContext CliCtx = new ClienteContext();
            Console.Write("Ingrese Apellido:");
            string ap = Console.ReadLine();
            List<Dominio.Cliente> ListaCliParticulares = CliCtx.GetClientes(ap);

            if (ListaCliParticulares.Count > 0) {
                Console.Clear();
                Console.WriteLine("---- Listado de Clientes Particulares encontrados----");
                foreach (var item in ListaCliParticulares) {
                    int Fechoy = DateTime.Now.Year;
                    int FNac = item.Fnac.Year;

                    Console.WriteLine($"ID:{item.Id} | Apellido:{item.Apellido} | Nombre:{item.Nombre} Localidad: {item.Localidad} Edad:{Fechoy - FNac}");
                }
            }
            else {
                Console.Clear();
                Console.WriteLine("---- No se encuentran datos para la consulta que esta realizando----");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Presione cualquier tecla para continuar");
            opcionInfo = Console.ReadKey(false);
        }

        public void VerUnCorporativo()
        {
            ConsoleKeyInfo opcionInfo;
            Console.WriteLine("*****************// VER CLIENTE CORPORATIVO \\******************");

            ClienteContext CliCtx = new ClienteContext();
            Console.Write("Ingrese razon Social:");
            string rz = Console.ReadLine();
            List<Dominio.Corporativo> ListaCorporativos = CliCtx.GetClientesCorporativos(rz);

            if (ListaCorporativos.Count > 0) {
                Console.Clear();
                Console.WriteLine("---- Listado de Empresas Corporativas Encontradas----");
                foreach (var item in ListaCorporativos) {
                    Console.WriteLine($"ID:{item.Id} | Razon Social :{item.RazonSocial} | CUIT:{item.Cuit} | Nombre:{item.Nombre} | Localidad: {item.Localidad}");
                }
            }
            else {
                Console.Clear();
                Console.WriteLine("---- No se encuentran datos para la consulta que esta realizando----");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Presione cualquier tecla para continuar");
            opcionInfo = Console.ReadKey(false);

        }

        public ConsoleKeyInfo ModificarCliente()
        {
            ConsoleKeyInfo opcionTipoCliente;

            do {
                Console.WriteLine("***********// MODIFICAR INFORMACION DE CLIENTES \\***********");
                Console.WriteLine();//Decoracion consola
                Console.WriteLine("Acontinuacion elija el tipo de cliente a modificar: ");
                Console.WriteLine();//Decoracion consola
                Console.WriteLine("1 -  Cliente particular");
                Console.WriteLine("2 - Cliente corporativo");
                Console.WriteLine("Backspace - Para volver al menu principal");
                Console.WriteLine();//Decoracion consola
                Console.WriteLine();//Decoracion consola

                opcionTipoCliente = Console.ReadKey(true);
            } while (((int)opcionTipoCliente.KeyChar != 08) && (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
            return opcionTipoCliente;
        }

    }
}
