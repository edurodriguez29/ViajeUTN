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
                opcion = Console.ReadKey(true);
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
                Console.WriteLine("Esc - Para ir hacia atras");
                opcion = Console.ReadKey(true);
            } while (((int)opcion.KeyChar != 27) && ((int)opcion.KeyChar >= 1 && (int)opcion.KeyChar <= 3));
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
                opcion = Console.ReadKey(true);
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
                opcionGuardado = Console.ReadKey(true);
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
                opcionInfo = Console.ReadKey(true);
            } while (((int)opcionInfo.KeyChar != 08) && ((int)opcionInfo.KeyChar >= 1 && (int)opcionInfo.KeyChar <= 2) && (int)opcionInfo.KeyChar != 27);
            return opcionInfo;
        }

        public void VerUnParticular()
        {
            Console.Clear();
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
            opcionInfo = Console.ReadKey(true);
        }

        public void VerUnCorporativo()
        {
            Console.Clear();
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
            opcionInfo = Console.ReadKey(true);

        }

        public ConsoleKeyInfo ModificarCliente()
        {
            ConsoleKeyInfo opcionTipoCliente;

            do {
                Console.Clear();
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
            } while (((int)opcionTipoCliente.KeyChar != 08) && ((int)opcionTipoCliente.KeyChar >= 1 && (int)opcionTipoCliente.KeyChar <= 2) && (int)opcionTipoCliente.KeyChar != 27);
            return opcionTipoCliente;
        }


        // Revisar, no modifica los usuarios
        public void ModificarParticular()
        {
            Console.Clear();
            Dominio.Cliente oClipArt = new Dominio.Cliente();
            ClienteContext cliContx = new ClienteContext();
            int id;
            Console.WriteLine("*****************// PARTICULAR \\******************");
            Console.WriteLine();
            Console.Write("Ingrese el ID del cliente a modificar: ");
            int.TryParse(Console.ReadLine(), out id);
            List<Dominio.Cliente> ListaCliParticulares = cliContx.SetClientes(id);
            oClipArt = ListaCliParticulares.Find(x => x.Id == id);
            if (oClipArt != null) {
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

                //Regrabo Cliente
                var retorno = cliContx.SetParticular(oClipArt);
                if (retorno > 0) {
                    Console.WriteLine("Se ha modificado el Cliente exitosamente", retorno.ToString());
                }
                else { Console.WriteLine("Se ha detectado un error en al intentar modificar el Cliente"); };
                Console.WriteLine("");
            }
            else {
                Console.Clear();
                Console.WriteLine("---- No se encuentran datos para la consulta que esta realizando----");
            }
            return;

        }

        // Revisar, no modifica los usuarios
        public void ModificarCorporativo()
        {
            Console.Clear();
            Dominio.Corporativo corp = new Dominio.Corporativo();
            ClienteContext cliCtx = new ClienteContext();
            int id;;
            Console.WriteLine("*****************// PARTICULAR \\******************");
            Console.WriteLine();
            Console.Write("Ingrese el ID del cliente a modificar: ");
            int.TryParse(Console.ReadLine(), out id);
            List<Dominio.Corporativo> ListaCorporativos = cliCtx.SetCorporativo(id);
            corp = ListaCorporativos.Find(x => x.Id == id);
            if (corp != null) {
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

                Console.Write("Provincia:");
                corp.Provincia = Console.ReadLine();
                Console.Write("CUIT:");
                corp.Cuit = Console.ReadLine();

                Console.Write("Razon social:");
                corp.RazonSocial = Console.ReadLine();


                //Grabo Cliente
                ClienteContext CCtx = new ClienteContext();
                var retorno = CCtx.PutCliente(corp);
                if (retorno > 0) {
                    Console.WriteLine("Se ha modificado el Cliente exitosamente", retorno.ToString());
                }
                else { Console.WriteLine("Se ha detectado un error en la creacion del Cliente"); };
                Console.WriteLine("");
            }
            return;
        }

        //------------------- Aqui arranca el menu de paquetes ------------------- //

        /// <summary>
        /// Menu Paquetes
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>
        public ConsoleKeyInfo MostrarMenuPaquetes()
        {
            ConsoleKeyInfo opcion;
            do {
                Console.Clear();
                Console.WriteLine("********** Menu Paquetes ***********");
                Console.WriteLine("Eliga una de las siguientes opciones:");
                Console.WriteLine("1 - Crear un nuevo paquete");
                Console.WriteLine("2 - Ver datos de un paquete");
                Console.WriteLine("3 - Modificar datos de un paquete");
                Console.WriteLine("Esc - Para ir hacia atras");
                opcion = Console.ReadKey(true);
            } while (((int)opcion.KeyChar != 27) && ((int)opcion.KeyChar >= 1 && (int)opcion.KeyChar <= 3));
            return opcion;
        }

        public void NuevoPaquete()
        {
            Dominio.Paquete nuevoPaq = new Dominio.Paquete();

            Console.Clear();
            Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");

            Console.Write("Nombre:");
            nuevoPaq.Nombre = Console.ReadLine();

            Console.Write("Precio:");
            nuevoPaq.Precio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //Formatea la entrada sin importar si lleva una "," o un "."

            Console.Write("Fecha de Inicio(DD-MM-AAAA):");
            var strfInc = Console.ReadLine();
            nuevoPaq.Fecha_Inicio = DateTime.ParseExact(strfInc, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("Fecha de Fin(DD-MM-AAAA):");
            var strfFin = Console.ReadLine();
            nuevoPaq.Fecha_Fin = DateTime.ParseExact(strfFin, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("Fecha de Viaje(DD-MM-AAAA):");
            var strfVia = Console.ReadLine();
            nuevoPaq.Fecha_Viaje = DateTime.ParseExact(strfVia, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.Write("Indique ingresando \"true\" o \"false\" si el paquete es NACIONAL:");
            nuevoPaq.EsNacional = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Cotizacion en dolar (si el paquete es INTERNACIONAL, de lo contrario solo ingrese un \"0\"):");
            nuevoPaq.CotizacionDol = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Si el paquete es INTERNACIONAL inque con \"true\" o \"false\" si requeire visa:");
            nuevoPaq.RequiereVisa = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Si el paquete es NACIONAL, a continuacion ingrese el porcentaje del \"Impuesto Nacional\":");
            nuevoPaq.ImpuestoNacional = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Si el paquete es INTERNACIONAL, a continuacion ingrese el valor fijo del \"Impuesto Nacional\":");
            nuevoPaq.ImpuestoInt = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Cantidad de cuotas:");
            nuevoPaq.CantCuotas = Convert.ToInt32(Console.ReadLine());

            Console.Write("Monto de cuotas:");
            nuevoPaq.MontoCuota = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Indique ingresando \"true\" o \"false\" si el paquete se encuentra activo:");
            nuevoPaq.Activo = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Cantidad de dias:");
            nuevoPaq.CantDias = Convert.ToInt32(Console.ReadLine());

            // Problemas con la variable retorno

            //Grabo Paquete
            /*PaqueteContext PCtx = new PaqueteContext();
            var retorno = PCtx.PutPaquete(nuevoPaq);
            if (retorno > 0) {
                Console.WriteLine("Se ha creado el Paquete exitosamente, su ID es: {0}", retorno.ToString());
            }
            else { Console.WriteLine("Se ha detectado un error en la creacion del Paquete"); };
            Console.WriteLine(""); */ 
        }

        public void VerPaquete()
        {
            Console.Clear();
            ConsoleKeyInfo opcionInfo;
            Console.WriteLine("*****************// VER INFORMACIÓN DE UN PARTICULAR \\******************");

            PaqueteContext PaqCtx = new PaqueteContext();
            Console.Write("Ingrese Nombre:");
            string nom = Console.ReadLine();
            List<Dominio.Paquete> ListaPaquetes = PaqCtx.GetPaquetes(nom);

            if (ListaPaquetes.Count > 0) {
                Console.Clear();
                Console.WriteLine("---- Listado de Paquetes encontrados----");
                foreach (var item in ListaPaquetes) {

                    Console.WriteLine($"ID:{item.Id} | Nombre:{item.Nombre} Precio: {item.Precio} Fecha Inicio:{item.Fecha_Inicio} Fecha Fin:{item.Fecha_Fin}");
                }
            }
            else {
                Console.Clear();
                Console.WriteLine("---- No se encuentran datos para la consulta que esta realizando----");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Presione cualquier tecla para continuar");
            opcionInfo = Console.ReadKey(true);
        }



        // Terminar
        /*public void ModificarPaquete()
        {
            Console.Clear();
            Dominio.Paquete modPaq = new Dominio.Paquete();
            PaqueteContext paqContx = new PaqueteContext();
            string nombre;
            Console.WriteLine("*****************//* PAQUETE \\******************");
            Console.WriteLine();
            Console.Write("Ingrese el nombre del paquete a modificar: ");
            nombre = Console.ReadLine();
            List<Dominio.Paquete> ListaPaquetes = paqContx.SetPaquete();
            modPaq = ListaPaquetes.Find(x => x.Nombre == nombre);
            if (modPaq != null) {

                Console.Write("Nombre:");
                modPaq.Nombre = Console.ReadLine();

                Console.Write("Precio:");
                modPaq.Precio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //Formatea la entrada sin importar si lleva una "," o un "."

                Console.Write("Fecha de Inicio(DD-MM-AAAA):");
                var strfInc = Console.ReadLine();
                modPaq.Fecha_Inicio = DateTime.ParseExact(strfInc, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                Console.Write("Fecha de Fin(DD-MM-AAAA):");
                var strfFin = Console.ReadLine();
                modPaq.Fecha_Fin = DateTime.ParseExact(strfFin, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                Console.Write("Fecha de Viaje(DD-MM-AAAA):");
                var strfVia = Console.ReadLine();
                modPaq.Fecha_Viaje = DateTime.ParseExact(strfVia, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                Console.Write("Indique ingresando \"true\" o \"false\" si el paquete es NACIONAL:");
                modPaq.EsNacional = Convert.ToBoolean(Console.ReadLine());

                Console.Write("Cotizacion en dolar (si el paquete es INTERNACIONAL, de lo contrario solo ingrese un \"0\"):");
                modPaq.CotizacionDol = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Si el paquete es INTERNACIONAL inque con \"true\" o \"false\" si requeire visa:");
                modPaq.RequiereVisa = Convert.ToBoolean(Console.ReadLine());

                Console.Write("Si el paquete es NACIONAL, a continuacion ingrese el porcentaje del \"Impuesto Nacional\":");
                modPaq.ImpuestoNacional = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Si el paquete es INTERNACIONAL, a continuacion ingrese el valor fijo del \"Impuesto Nacional\":");
                modPaq.ImpuestoInt = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Cantidad de cuotas:");
                modPaq.CantCuotas = Convert.ToInt32(Console.ReadLine());

                Console.Write("Monto de cuotas:");
                modPaq.MontoCuota = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Indique ingresando \"true\" o \"false\" si el paquete se encuentra activo:");
                modPaq.Activo = Convert.ToBoolean(Console.ReadLine());

                Console.Write("Cantidad de dias:");
                modPaq.CantDias = Convert.ToInt32(Console.ReadLine());

                //Regrabo Cliente
                var retorno = paqContx.SetPaquete(modPaq);
                if (retorno > 0) {
                    Console.WriteLine("Se ha modificado el paquete exitosamente", retorno.ToString());
                }
                else { Console.WriteLine("Se ha detectado un error en al intentar modificar el paquete"); };
                Console.WriteLine("");
            }
            else {
                Console.Clear();
                Console.WriteLine("---- No se encuentran datos para la consulta que esta realizando----");
            }
            return;

        }*/

    }
}
