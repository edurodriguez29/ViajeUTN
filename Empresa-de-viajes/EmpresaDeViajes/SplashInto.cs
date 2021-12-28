using System;
using System.Collections.Generic;
using System.Data;
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
                Console.WriteLine("4 - Ventas - Facturación");
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

        /// <summary>
        /// Muestra menus de Paquetes
        /// </summary>
        /// <returns></returns>
        public ConsoleKeyInfo MostrarMenuPaquete()
        {
            ConsoleKeyInfo opcionGuardado;
            do {
                Console.Clear();
                Console.WriteLine("*********// MENU DE PAQUETES \\********");
                Console.WriteLine("1 - Crear Nuevo Paquete");
                Console.WriteLine("2 - Listar Paquetes");
                opcionGuardado = Console.ReadKey(false);
            } while (((int)opcionGuardado.KeyChar <= 1 && (int)opcionGuardado.KeyChar >= 2) && (int)opcionGuardado.KeyChar != 27);
            return opcionGuardado;
        }

        
        public ConsoleKeyInfo MostrarMenuVentas()
        {
            ConsoleKeyInfo opcionGuardado;
            do {
                Console.Clear();
                Console.WriteLine("*********// MENU DE VENTA DE PAQUETES \\********");
                Console.WriteLine("1 - Facturar a Cliente");
                Console.WriteLine("2 - Listar Factura");
                opcionGuardado = Console.ReadKey(false);
            } while (((int)opcionGuardado.KeyChar <= 1 && (int)opcionGuardado.KeyChar >= 2) && (int)opcionGuardado.KeyChar != 27);
            return opcionGuardado;
        }
        /// <summary>
        /// Lista facturas de Clientes
        /// </summary>
        public void ListarFacturaCliente() {
            ConsoleKeyInfo opcionInfo;
            Console.WriteLine("*****************// LISTAR FACTURAS DE CLIENTES \\******************");

            FacturaContext FactCtx = new FacturaContext();
            Console.Write("Ingrese Apellido:");
            string ap = Console.ReadLine();
            DataTable DTFacturas = FactCtx.GetFacturas(ap);

            if (DTFacturas.Rows.Count > 0) {
                DataRow row;
                for (int i = 0; i < DTFacturas.Rows.Count; i++) {
                    row = DTFacturas.Rows[i];
                    string subtotal=string.Format("{0:N2}", row["SUBTOTAL"]);
                    DateTime fechaFact = Convert.ToDateTime(row["FECHA"]);
                    Console.WriteLine($"{row["IDCLIENTE"].ToString(),10}" +
                                        $"{row["DNI"],10}" +
                                        $"{row["APELLIDO"],10}" +
                                        $"{row["NOMBRE"],15}" +
                                        $"{row["IDpaquete"],5}" +
                                        $"{row["paqueteNombre"],20}" +
                                        $"{fechaFact.ToString("dd/MM/yyyy"),12}" +
                                        $"{subtotal,15}");
                }
            }

      
            Console.WriteLine("**** presione cualquier tecla para continuar");
            opcionInfo = Console.ReadKey(false);
        }

        /// <summary>
        /// Se genera una factura a un Cliente x los Paquetes Solicitados
        /// </summary>
        public void FacturarACliente() {
            string introTeclado = "";
            bool Salir = false;
            ConsoleKeyInfo opcionInfo;
            Dominio.Cliente oCliente=new Dominio.Cliente();
            Datos.ClienteContext oClienteContext = new Datos.ClienteContext();
            Dominio.Factura oFactura=new Dominio.Factura();
            Datos.PaqueteContext oPaqContext= new Datos.PaqueteContext();
            List<Dominio.Paquete> LstPaquetes;
            int Cantitem=0;

            //Busco un Cliente
            do {
                Console.Clear();
                Console.WriteLine("***********// VENTA DE PAQUETES - FACTURAR A CLIENTE - VENTA \\***********");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Ingrese el DNI del Cliente ('Salir'):");
                introTeclado= Console.ReadLine().Trim().ToUpper();
                if (introTeclado.Equals("SALIR")) { 
                    Salir = true;
                }
                else {
                    oCliente = oClienteContext.SearchByDNI(introTeclado);
                    if (oCliente.Id == 0) {
                        Console.WriteLine("****** El Cliente no existe. Presione cualquier tecla para continuar");
                        opcionInfo = Console.ReadKey(false);
                        Console.Clear();
                    }
                    else {
                        Console.WriteLine("**************Datos del Cliente*******************");
                        Console.WriteLine($"ID:{oCliente.Id} | Apellido:{oCliente.Apellido} | Nombre:{oCliente.Dni} | Direccion:{oCliente.Direccion}");
                        Console.WriteLine("");
                        Salir=true;
                    }
                }
            } while (oCliente.Id==0 && !Salir);

            //Si no selecciona ningun cliente
            if (oCliente.Id == 0) { return; }

            //Asigno Cliente seleccionado
            oFactura.OCliente = oCliente;
            Salir = false;

            //Agrego de Paquetes como detalle de Factura
            do {
                Console.WriteLine("*********** Agregado de Paquetes ***********");
                Console.WriteLine("");
                Console.Write("Ingrese el nombre del paquete a buscar ('Salir'):");
                introTeclado = Console.ReadLine().Trim().ToUpper();
                if (introTeclado.Equals("SALIR")) {
                    Salir = true;
                }
                else {
                    LstPaquetes = oPaqContext.buscar(introTeclado);
                    if (LstPaquetes.Count > 0) {
                        foreach (var item in LstPaquetes) {
                            Console.WriteLine($"ID:{item.Id} Nombre:{item.Nombre}");
                        }

                        //Que especifique que ID quiere Agregar
                        Console.Write("Ingrese el ID del Paquete:");
                        introTeclado = Console.ReadLine().Trim().ToUpper();
                        var oPaquete =LstPaquetes.FirstOrDefault(x => x.Id == Convert.ToInt32(introTeclado));
                        if (oPaquete == null) {
                            Console.WriteLine("EL ID no se encuentra.");
                        }
                        else {
                            Dominio.FactDetalle fDet=new Dominio.FactDetalle();
                            fDet.paquete = oPaquete;
                            
                            //ingreso de Cantidad de Cuotas
                            Console.Write("Ingrese Cantidad de Paquetes a Comprar:");
                            introTeclado = Console.ReadLine().Trim().ToUpper();
                            fDet.CantPaquetes = Convert.ToInt32(introTeclado); //Cant de paquetes
                            fDet.Item = Cantitem++; //item del detalle de factura
                            if (oPaquete.CantCuotas == 1) {
                                Console.WriteLine("*** Este paquete solo admite 1 cuota");
                            }
                            else {
                                Console.Write($"Ingrese Cantidad de cuotas (1-{oPaquete.CantCuotas}):");
                                introTeclado = Console.ReadLine().Trim().ToUpper();
                                int cantCuotas=Convert.ToInt32(introTeclado);
                                if (!(cantCuotas > 0 && cantCuotas <= oPaquete.CantCuotas)) {
                                    Console.WriteLine("La cantidad de cuotas no se encuentra delntreo del rango especificado del paquete.Presione cualqiuoer tecla para salir");
                                    introTeclado = Console.ReadLine().Trim().ToUpper();
                                    break;
                                }
                                else {
                                    fDet.CantCuotas = cantCuotas;
                                }
                            }
                            if (oPaquete.EsNacional) {

                                //debo calcular los subtotales para paquetes Nacionales
                                fDet.Subtotal = ((oPaquete.Precio * oPaquete.ImpuestoNacional / 100) + oPaquete.Precio) * fDet.CantPaquetes;
                            }
                            else {
                                fDet.Subtotal = oPaquete.Precio + oPaquete.ImpuestoInt;
                            }
                            //Agreggo el detalle
                            oFactura.LFacturaDet.Add(fDet);
                            Console.WriteLine("---->Paquete agregado a la factura");
                        }
                    }
                }
            } while (!Salir);

            //Imprimo el detalle y persisto
            if (oFactura.LFacturaDet.Count > 0) {
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("Detalle de Paquetes de la Factura");

                foreach (var item in oFactura.LFacturaDet) {
                    string monto = string.Format("{0:N2}", item.Subtotal);
                    string tipo = item.paquete.EsNacional ? "Nacional" : "Internacional";
                    Console.WriteLine($"Paquete:{item.paquete.Id} | Nombre{item.paquete.Nombre} | Tipo de Paquete:{tipo} | Cant: {item.CantCuotas} Subtotal:{monto}");
                }
                FacturaContext fContext=new FacturaContext();
                if (fContext.PutFactura(oFactura)) {
                    Console.WriteLine($"La factura {oFactura.IDFactura} ha sido insertada en BD con todo su detalle");
                }
                else {
                    Console.WriteLine($"Error en la insercion de la Factura");
                }
                Console.WriteLine("Su factura ha sido creada. Pulse cualquier tecla para continuar.");
                introTeclado = Console.ReadLine().Trim().ToUpper();
            }
        }

        /// <summary>
        /// Crea un  nuevo Paquete
        /// </summary>
        public void CrearNuevoPaquete()
        {
            ConsoleKeyInfo opcion;
            Dominio.Paquete oPaquete = new Dominio.Paquete();
            Dominio.Lugares oLugares;
            try {
                Console.Clear();
                Console.WriteLine("***********// NUEVO PAQUETE \\***********");

                Console.Write("¿Que tipo de Paquete desea crear?, ¿Nacional ó Internaciona? (Int/Nac):");
                oPaquete.EsNacional = Console.ReadLine().ToUpper() == "NAC";

                Console.WriteLine("");
                Console.WriteLine("");
                if (oPaquete.EsNacional) { 
                    Console.WriteLine("******************* PAQUETE NACIONAL ***************"); 
                }
                else {
                    Console.WriteLine("******************* PAQUETE INTERNACIONAL ***************");
                }

                Console.Write("Nombre del Paquete:");
                oPaquete.Nombre = Console.ReadLine();

                Console.Write("Precio:");
                oPaquete.Precio = Convert.ToDouble(Console.ReadLine());

                Console.Write("Fecha de Inicio de Disponibilidad  (DD-MM-AAAA):");
                var strfecha = Console.ReadLine();
                oPaquete.Fecha_Inicio = DateTime.ParseExact(strfecha, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                Console.Write("Fecha de Fin de Disponibilidad(DD-MM-AAAA):");
                strfecha = Console.ReadLine();
                oPaquete.Fecha_Fin = DateTime.ParseExact(strfecha, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                Console.Write("cantidad de Días:");
                oPaquete.CantDias = Convert.ToInt32(Console.ReadLine());

                if (oPaquete.EsNacional) {
                    //Nacional
                    
                    Console.Write("¿Que % de Impuestos se aplicara?(0-100):");
                    oPaquete.ImpuestoNacional = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Cantidad de Cuotas (1-12):");
                    oPaquete.CantCuotas = Convert.ToInt32(Console.ReadLine());
                    if (oPaquete.CantCuotas <= 0 || oPaquete.CantCuotas > 12) {
                        Console.WriteLine("Ups!!!, ha ingresado un valor incorrecto.Pruebe de Nuevo :-P");
                        return;
                    }
                }
                else {
                    //Internacional
                    Console.Write("Cotizacion del Dolar:");
                    oPaquete.CotizacionDol = Convert.ToDouble(Console.ReadLine());

                    Console.Write("El Paquete ¿Requiere VISA? (No/Si):");
                    oPaquete.RequiereVisa = Console.ReadLine().ToUpper() == "SI";

                    Console.Write("Impuesto de Valor Fijo:");
                    oPaquete.ImpuestoInt = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Cantidad de Cuotas (1-6):");
                    oPaquete.CantCuotas = Convert.ToInt32(Console.ReadLine());
                    if (oPaquete.CantCuotas<=0 || oPaquete.CantCuotas > 6) {
                        Console.WriteLine("Ups!!!, ha ingresado un valor incorrecto.Pruebe de Nuevo :-P");
                        return;
                    }
                }
                
                oPaquete.Activo = true;
                string destino;
                do {
                    Console.Clear();
                    Console.WriteLine("*********// INGRESO DE DESTINOS \\********");
                    Console.WriteLine("");
                    Console.WriteLine("para terminar->fin");
                    Console.WriteLine("");
                    Console.Write("Nombre del Destino:");
                    destino = Console.ReadLine().Trim().ToUpper();
                    if (destino=="FIN" || destino=="") { break;}

                    //Ya existe el Destino?
                    var lugar = oPaquete.Lugares.FirstOrDefault(x => x.Nombre == destino);
                    if (lugar == null) {
                        //Lo inserto
                        oLugares = new Dominio.Lugares();
                        oLugares.Nombre = destino;
                        oPaquete.Lugares.Add(oLugares);
                    }
                    else {
                        Console.WriteLine("El destino que ha ingresado ya existe en este Paquete");
                        Console.WriteLine("Presione cualquier tecla para constinuar");
                        destino=Console.ReadLine();
                    }
                }
                while (true);

                //Insercion de Objetos en la base de Datos
                PaqueteContext opaqueteContext = new PaqueteContext();
                if (opaqueteContext.PutPaquete(oPaquete)) {
                    Console.WriteLine($"Se ha creado el paquete con el Identificador:{oPaquete.Id}");
                }
                else {
                    Console.WriteLine("Se ha detectado un error en la insercion del Paquete");
                }
                
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla parac Continuar");
                opcion = Console.ReadKey();
            }
            catch (Exception Ex) {
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.Message);
                Console.WriteLine("Error en la insercion del Paquete: " + Ex.InnerException);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla parac ontinuar");
                opcion = Console.ReadKey();
            }
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
