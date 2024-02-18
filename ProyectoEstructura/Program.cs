using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_1_Estructura_de_Datos

{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Pagos.Menu.MenuPrincipal();
        }
    }
    internal class Pagos
    {
        static int posicion = 1;
        static byte indice = 0;
        static int cant = 2;
        static int[] numero_de_pago = new int[cant];
        static Random aleatorio = new Random();
        static string[] fecha = new string[cant];
        static int[] hora = new int[cant];
        static int[] cedula = new int[cant];
        static string[] nombre = new string[cant];
        static string[] apellido1 = new string[cant];
        static string[] apellido2 = new string[cant];
        static int[] numero_de_caja = new int[cant];
        static int[] tipo_de_servicio = new int[cant];
        static int[] numero_factura = new int[cant];
        static double[] monto_a_pagar = new double[cant];
        static double[] monto_comision = new double[cant];
        static double[] monto_deducido = new double[cant];
        static double[] monto_paga_cliente = new double[cant];
        static double[] vuelto = new double[cant];
        static char respuesta = ' ';
        static int consulta_numero_pago = 0;

               internal class Menu
       
        {static int opcion = 0;
        public static void  MenuPrincipal()
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Menu principal");
                    Console.WriteLine("1-Inicializar Arreglos");
                    Console.WriteLine("2-Realizar Pagos");
                    Console.WriteLine("3-Consultar PAgos");
                    Console.WriteLine("4-Modificar Pagos");
                    Console.WriteLine("5-Eliminar Pagos");
                    Console.WriteLine("6-Submenu Reportes");
                    Console.WriteLine("Seleccione la opcion deseada");
                    int.TryParse(Console.ReadLine(), out opcion);

                    switch (opcion)
                    {
                        case 1:
                            Pagos.Inicializar();
                            break;
                        case 2:
                            Pagos.RealizarPagos();
                            break;
                        case 3:
                            Pagos.ConsultarPagos();
                            break;
                        case 4:
                            Pagos.ModificarPagos();
                            break;
                        case 5:
                            Pagos.EliminarPagos();
                            break;
                        case 6:
                            SubMenuReportes();
                            break;

                    }
                } while (opcion != 6);
            }
        }
        public static void SubMenuReportes()
        {
            int opcionReporte = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Submenú Reportes");
                Console.WriteLine("1. Ver todos los Pagos");
                Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                Console.WriteLine("3. Ver Pagos por código de caja");
                Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                Console.WriteLine("5. Regresar Menú Principal");
                Console.WriteLine("Seleccione la opción deseada");
                int.TryParse(Console.ReadLine(), out opcionReporte);

                switch (opcionReporte)
                {
                    case 1:
                        VerTodosLosPagos();
                        break;
                    case 2:
                        VerPagosPorTipoDeServicio();
                        break;
                    case 3:
                        VerPagosPorCodigoDeCaja();
                        break;
                    case 4:
                        VerDineroComisionadoPorServicios();
                        break;
                    case 5:
                        Console.WriteLine("Regresando al Menú Principal...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcionReporte != 5)
                {
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                }

            } while (opcionReporte != 5);
        }
        public static void Inicializar()
        {
            numero_de_pago = Enumerable.Repeat(0, cant).ToArray();
            fecha = Enumerable.Repeat("", cant).ToArray();
            hora = Enumerable.Repeat(0, cant).ToArray();
            cedula = Enumerable.Repeat(0, cant).ToArray();
            nombre = Enumerable.Repeat("", cant).ToArray();
            apellido1 = Enumerable.Repeat("", cant).ToArray();
            apellido2 = Enumerable.Repeat("", cant).ToArray();
            numero_de_caja = Enumerable.Repeat(0, cant).ToArray();
            tipo_de_servicio = Enumerable.Repeat(0, cant).ToArray();
            numero_factura = Enumerable.Repeat(0, cant).ToArray();
            monto_a_pagar = Enumerable.Repeat(0d, cant).ToArray();
            monto_comision = Enumerable.Repeat(0d, cant).ToArray();
            monto_deducido = Enumerable.Repeat(0d, cant).ToArray();
            vuelto = Enumerable.Repeat(0d, cant).ToArray();
            monto_paga_cliente = Enumerable.Repeat(0d, cant).ToArray();
            posicion = 1;
            indice = 0;
            Console.Clear();
            Console.WriteLine("***** ARREGLOS INICIALIZADOS *****");
            Console.ReadLine();

        }

        public static void VerTodosLosPagos()
        {
            Console.Clear();
            Console.WriteLine("Todos los Pagos:");
            for (int i = 0; i < cant; i++)
            {
                Console.WriteLine($"Fecha: {fecha[i]}, Monto a pagar: {monto_a_pagar[i]}");
            }
        }

        public static void VerPagosPorTipoDeServicio()
        {
            Console.Clear();
            Console.WriteLine("Pagos por tipo de Servicio:");
            Console.WriteLine("Elija el tipo de servicio:\n1-Electricidad\n2-Telefono\n3-Agua");
            int tipoServicio;
            if (int.TryParse(Console.ReadLine(), out tipoServicio) && (tipoServicio >= 1 && tipoServicio <= 3))
            {
                Console.WriteLine($"Pagos del tipo {tipoServicio}:");
                for (int i = 0; i < cant; i++)
                {
                    if (tipo_de_servicio[i] == tipoServicio)
                    {
                        Console.WriteLine($"Fecha: {fecha[i]}, Monto a pagar: {monto_a_pagar[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Tipo de servicio inválido.");
            }
        }

        public static void VerPagosPorCodigoDeCaja()
        {
            Console.Clear();
            Console.WriteLine("Pagos por Código de Caja:");
            Console.WriteLine("Ingrese el código de caja:");
            int codigoCaja;
            if (int.TryParse(Console.ReadLine(), out codigoCaja) && (codigoCaja >= 1 && codigoCaja <= 3))
            {
                Console.WriteLine($"Pagos realizados en la caja {codigoCaja}:");
                for (int i = 0; i < cant; i++)
                {
                    if (numero_de_caja[i] == codigoCaja)
                    {
                        Console.WriteLine($"Fecha: {fecha[i]}, Monto a pagar: {monto_a_pagar[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Código de caja inválido.");
            }
        }

        public static void VerDineroComisionadoPorServicios()
        {
            Console.Clear();
            Console.WriteLine("Dinero Comisionado por Servicios:");
            for (int i = 0; i < cant; i++)
            {
                Console.WriteLine($"Fecha: {fecha[i]}, Monto comisionado: {monto_comision[i]}");
            }
        }
        public static void RealizarPagos()
        {

            do
            {
                for (int i = 0; i < cant; i++)
                {
                    numero_de_pago[i] = aleatorio.Next(1, 10);
                }
                for (int i = 0; i < cant; i++)
                {
                    numero_de_caja[i] = aleatorio.Next(1, 3);
                }

                Console.WriteLine($"Digite la fecha ({posicion}): ");
                fecha[indice] = Console.ReadLine();
                Console.WriteLine($"Digite la hora ({posicion}): ");
                hora[indice] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite la cedula ({posicion}): ");
                cedula[indice] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite el nombre ({posicion}): ");
                nombre[indice] = Console.ReadLine();
                Console.WriteLine($"Digite el primer apellido ({posicion}): ");
                apellido1[indice] = Console.ReadLine();
                Console.WriteLine($"Digite el segundo apellido ({posicion}): ");
                apellido2[indice] = Console.ReadLine();
                Console.WriteLine("Elija el servicio a pagar: \n1-Electricidad \n2-Telefono \n3-Agua");
                tipo_de_servicio[indice] = int.Parse(Console.ReadLine());
                if (tipo_de_servicio[indice] == 1 || tipo_de_servicio[indice] == 2 || tipo_de_servicio[indice] == 3)
                {
                    Console.WriteLine("Opcion correcta");
                }
                else
                {
                    Console.WriteLine("Seleccion fuera de rango. Por favor, elija 1, 2 o 3.");
                }
                Console.WriteLine($"Digite el numero de factura ({posicion}): ");
                numero_factura[indice] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite el monto a pagar ({posicion}): ");
                monto_a_pagar[indice] = int.Parse(Console.ReadLine());
                if (tipo_de_servicio[indice] == 1)
                {
                    monto_comision[indice] = (monto_a_pagar[indice] * 0.04);
                    monto_deducido[indice] = monto_a_pagar[indice] - monto_comision[indice];
                }
                else if (tipo_de_servicio[indice] == 2)
                {
                    monto_comision[indice] = (monto_a_pagar[indice] * 0.055);
                    monto_deducido[indice] = monto_a_pagar[indice] - monto_comision[indice];
                }
                else if (tipo_de_servicio[indice] == 3)
                {
                    monto_comision[indice] = (monto_a_pagar[indice] * 0.065);
                    monto_deducido[indice] = monto_a_pagar[indice] - monto_comision[indice];
                }
                Console.WriteLine($"Con cuanto paga? ({posicion}): ");
                monto_paga_cliente[indice] = int.Parse(Console.ReadLine());
                vuelto[indice] = monto_paga_cliente[indice] - monto_a_pagar[indice];
                indice++;
                posicion++;

                Console.WriteLine($"\n\n                       Sistema Pago de Servicios Publicos \n                      Tienda La Favorita - Ingreso de Datos \n\n ");

                for (int i = 0; i < indice; i++)
                {
                    Console.WriteLine($"Numero de pago: {numero_de_pago[i]}\nFecha: {fecha[i]}           Hora:{hora[i]} \n\nCedula: {cedula[i]}                       Nombre: {nombre[i]}\nApellido1: {apellido1[i]}                            Apellido2: {apellido2[i]}\n\nTipo de Servicio:  {tipo_de_servicio[i]}                   [1-Electricidad 2-Telefono 3-Agua]\n\nNumero de Factura: {numero_factura[i]}                  Monto Pagar: {monto_a_pagar[i]}\nComision autorizada: {monto_comision[i]}                          Paga con: {monto_paga_cliente[i]}\nMonto deducido: {monto_deducido[i]}                            Vuelto: {vuelto[i]} ");
                }
                Console.WriteLine("\n\n                   Desea realizar otro pago? S/N");
                respuesta = char.Parse(Console.ReadLine().ToUpper());
            } while (respuesta != 'N');

            Console.Read();


        }
        public static void ConsultarPagos()
        {
            do
            {

                Console.WriteLine("                         Sistema Pago de Servicios Publicos\n                        Tienda La Favorita - Consulta de Datos\n\n");
                Console.WriteLine("Numero de Pago: ");
                consulta_numero_pago = int.Parse(Console.ReadLine());
                bool encontrado = false;
                for (int i = 0; i < cant; i++)
                {
                    if (consulta_numero_pago == numero_de_pago[i])
                    {
                        encontrado = true;

                        Console.WriteLine($"Numero de pago: {numero_de_pago[i]}\nFecha: {fecha[i]}           Hora:{hora[i]} \n\nCedula: {cedula[i]}                       Nombre: {nombre[i]}\nApellido1: {apellido1[i]}                            Apellido2: {apellido2[i]}\n\nTipo de Servicio:  {tipo_de_servicio[i]}                   [1-Electricidad 2-Telefono 3-Agua]\n\nNumero de Factura: {numero_factura[i]}                  Monto Pagar: {monto_a_pagar[i]}\nComision autorizada: {monto_comision[i]}                          Paga con: {monto_paga_cliente[i]}\nMonto deducido: {monto_deducido[i]}                            Vuelto: {vuelto[i]} ");
                    }
                }
                Console.WriteLine("\n\n                   Desea consultar otro pago? S/N");
                respuesta = char.Parse(Console.ReadLine().ToUpper());
                Console.Clear();
            } while (respuesta != 'N');
        }

        public static void ModificarPagos()
        {
            int numeroPago;
            bool pagoEncontrado = false;

            do
            {
                Console.Clear();
                Console.WriteLine("      Sistema Pago de Servicios Publicos");
                Console.WriteLine("      Tienda La Favorita - Modificar Pagos");
                Console.WriteLine();
                Console.WriteLine("Digite el número de pago que desea modificar: ");
                numeroPago = int.Parse(Console.ReadLine());

                for (int i = 0; i < cant; i++)
                {
                    if (numeroPago == numero_de_pago[i])
                    {
                        pagoEncontrado = true;
                        indice = (byte)i;
                        break;
                    }
                }

                if (!pagoEncontrado)
                {
                    Console.WriteLine("\nSistema Pago de Servicios Publicos\nTienda La Favorita - Consulta de Datos\n\n");
                    Console.WriteLine("Pago no se encuentra registrado.");
                    Console.ReadKey();
                    Console.WriteLine("Volviendo all menu principal...");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Console.WriteLine($"Numero de pago: {numero_de_pago[indice]}\nFecha: {fecha[indice]}      Hora:{hora[indice]} \n\nCedula: {cedula[indice]}            Nombre: {nombre[indice]}\nApellido1: {apellido1[indice]}              Apellido2: {apellido2[indice]}\n\nTipo de Servicio: {tipo_de_servicio[indice]}          [1-Electricidad 2-Telefono 3-Agua]\n\nNumero de Factura: {numero_factura[indice]}         Monto Pagar: {monto_a_pagar[indice]}\nComision autorizada: {monto_comision[indice]}             Paga con: {monto_paga_cliente[indice]}\nMonto deducido: {monto_deducido[indice]}              Vuelto: {vuelto[indice]} ");

                }

                //Muestra menu para proceder con modificacion
                Console.WriteLine("\n---¿Que desea modificar?---");
                Console.WriteLine("\n\n1. Fecha\n2. Hora\n3. Monto a pagar\n4. Tipo de servicio\n5. Número de factura\n6. Nombre\n7. Cédula\n8. Primer Apellido\n9. Segundo Apellido\n10. Número de Caja\n11. Monto que paga cliente\n12. Salir");
                Console.WriteLine("");

                int opcion;
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nDigite la nueva fecha: ");
                        fecha[indice] = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("\nDigite la nueva hora: ");
                        hora[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("\nDigite el nuevo monto a pagar: ");
                        monto_a_pagar[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("\nDigite el nuevo tipo de servicio: ");
                        tipo_de_servicio[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("\nDigite el nuevo número de factura: ");
                        numero_factura[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("\nDigite el nuevo nombre: ");
                        nombre[indice] = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("\nDigite la nueva cédula: ");
                        cedula[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.WriteLine("\nDigite el nuevo primer apellido: ");
                        apellido1[indice] = Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("\nDigite el nuevo segundo apellido: ");
                        apellido2[indice] = Console.ReadLine();
                        break;
                    case 10:
                        Console.WriteLine("\nDigite el nuevo número de caja: ");
                        numero_de_caja[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 11:
                        Console.WriteLine("\nDigite el nuevo monto que paga el cliente: ");
                        monto_paga_cliente[indice] = int.Parse(Console.ReadLine());
                        break;
                    case 12:
                        Console.WriteLine("\nSaliendo...");
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\n           Sistema Pago de Servicios Publicos\nTienda La Favorita - Modificar Datos\n\n");
                    Console.WriteLine($"Numero de pago: {numero_de_pago[indice]}\nFecha: {fecha[indice]}      Hora:{hora[indice]} \n\nCedula: {cedula[indice]}            Nombre: {nombre[indice]}\nApellido1: {apellido1[indice]}              Apellido2: {apellido2[indice]}\n\nTipo de Servicio: {tipo_de_servicio[indice]}          [1-Electricidad 2-Telefono 3-Agua]\n\nNumero de Factura: {numero_factura[indice]}         Monto Pagar: {monto_a_pagar[indice]}\nComision autorizada: {monto_comision[indice]}             Paga con: {monto_paga_cliente[indice]}\nMonto deducido: {monto_deducido[indice]}              Vuelto: {vuelto[indice]} ");
                    Console.WriteLine("\n\n           ¿Desea modificar otro dato? (S/N)");
                    respuesta = char.Parse(Console.ReadLine().ToUpper());

                    if (respuesta == 'N')
                    {
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1500);
                        break;
                    }
                }

            } while (respuesta == 'S');
        }
        public static void EliminarPagos()
        {
            int numeroPago;
            bool encontrado = false;
            int indice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Eliminar Pagos");
                Console.WriteLine("Ingrese el número de pago que desea eliminar: ");
                numeroPago = int.Parse(Console.ReadLine());

                for (int i = 0; i < cant; i++)
                {
                    if (numeroPago == numero_de_pago[i])
                    {
                        encontrado = true;
                        indice = i;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("\nPago no se encuentra registrado.");
                }
            } while (!encontrado);

            if (encontrado)
            {
                Console.Clear();
                Console.WriteLine("Eliminar Pagos");
                Console.WriteLine("\n           Sistema Pago de Servicios Publicos\nTienda La Favorita - Eliminar pagos\n\n");
                Console.WriteLine($"Numero de pago: {numero_de_pago[indice]}\nFecha: {fecha[indice]}      Hora:{hora[indice]} \n\nCedula: {cedula[indice]}            Nombre: {nombre[indice]}\nApellido1: {apellido1[indice]}              Apellido2: {apellido2[indice]}\n\nTipo de Servicio: {tipo_de_servicio[indice]}          [1-Electricidad 2-Telefono 3-Agua]\n\nNumero de Factura: {numero_factura[indice]}         Monto Pagar: {monto_a_pagar[indice]}\nComision autorizada: {monto_comision[indice]}             Paga con: {monto_paga_cliente[indice]}\nMonto deducido: {monto_deducido[indice]}              Vuelto: {vuelto[indice]} ");
                Console.WriteLine("\n\n           ¿Esta seguro que desea eliminar el pago? (S/N)");
                char respuesta = char.Parse(Console.ReadLine().ToUpper());

                if (respuesta == 'S')
                {
                    EliminarPago(indice);
                    Console.WriteLine("\n\n\n        La informacion ya fue eliminada.");
                    Console.WriteLine("Volviendo al menu principal...");
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.WriteLine("\n        La informacion no fue eliminada.");
                    Console.WriteLine("Volviendo al menu principal...");
                    Thread.Sleep(1500);
                }
            }

        }

        private static void EliminarPago(int indice)
        {
            numero_de_pago = numero_de_pago.Where((e, i) => i != indice).ToArray();
            fecha = fecha.Where((e, i) => i != indice).ToArray();
            hora = hora.Where((e, i) => i != indice).ToArray();
            cedula = cedula.Where((e, i) => i != indice).ToArray();
            nombre = nombre.Where((e, i) => i != indice).ToArray();
            apellido1 = apellido1.Where((e, i) => i != indice).ToArray();
            apellido2 = apellido2.Where((e, i) => i != indice).ToArray();
            numero_de_caja = numero_de_caja.Where((e, i) => i != indice).ToArray();
            tipo_de_servicio = tipo_de_servicio.Where((e, i) => i != indice).ToArray();
            numero_factura = numero_factura.Where((e, i) => i != indice).ToArray();
            monto_a_pagar = monto_a_pagar.Where((e, i) => i != indice).ToArray();
            monto_comision = monto_comision.Where((e, i) => i != indice).ToArray();
            monto_paga_cliente = monto_paga_cliente.Where((e, i) => i != indice).ToArray();
            monto_deducido = monto_deducido.Where((e, i) => i != indice).ToArray();
            vuelto = vuelto.Where((e, i) => i != indice).ToArray();

            cant--;
        }

    }
}

