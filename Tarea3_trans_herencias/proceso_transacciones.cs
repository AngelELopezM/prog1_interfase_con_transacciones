using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_trans_herencias
{
    class proceso_transacciones : Itrans// : c_transacciones
    {
        /* public proceso_transacciones(string cliente, double monto, bool aprobada = true): base(cliente, monto, aprobada)
         {

         }*/
        private Menu menu_principal;
        private Program program;
        public proceso_transacciones()
        {
             menu_principal = new Menu();
            program = new Program();
            }
        
        
        public void agregar()
        {
            Console.Clear();
            int contador = 0; //este contador me va a servir para poner el numero de trans
            try
            {
                foreach (var item in Repositorio.instancia.transacciones)/*aqui me va a recorrer todo el list y va a ir incrementando el contador
                    para de esta manera poder contar a donde nos quedamos y poder arreglar el numero de transaccion*/
                {
                    contador++;
                }
               // program.numero_transaccion++;
                Console.WriteLine("AGREGAR TRANSACCIONES \nIngrese el nombre del cliente");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el monto de la transaccion");
                double monto = Convert.ToDouble(Console.ReadLine());

                string estado;//aqui declaro la variable para mas adelante poder sacarla del bucle, porque si no no se saca
                    bool valido;
                do
                {
                    Console.WriteLine("Esta transaccion esta APROBADA O RECHAZADA?");
                    estado = Console.ReadLine().ToUpper();
                    if (estado == "APROBADA" || estado == "RECHAZADA")
                    {
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                } while (valido == false);//aqui dice que mientras valido sea igual falso este bucle se repetira
                Console.WriteLine("==================RESUMEN DE LA TRANSACCION=================");
                Console.WriteLine("Nombre del cliente : " + nombre + "\nMonto : " + monto + "\nEstado de la transaccion : " +estado);
                Console.WriteLine("======================================= \nSeguro que desea registrar esta transaccion? S/N");
                string opcion = Console.ReadLine().ToUpper();
                switch (opcion)
                {
                    case "S":

                        c_transacciones registro = new c_transacciones(nombre, monto, contador, estado);
                        Repositorio.instancia.transacciones.Add(registro);
                        Console.WriteLine("Transaccion registrada exitosamente!!!");

                        Console.ReadKey();
                        menu_principal.menu();
                        break;
                    case "N":
                        Console.WriteLine("Usted ha cancelado el registro de esta transaccion\nVOLVIENDO AL MENU . . .");
                        Console.ReadKey();
                        menu_principal.menu();
                        break;
                    default:
                        Console.WriteLine("Error, volviendo al menu . . .");
                        Console.ReadKey();
                        menu_principal.menu();
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                menu_principal.menu();
                throw;
            }
        }
        public void editar()
        {
            Console.Clear();
            int contador = 0; //este contador me va a servir para medir el indice del foreach para editar la trans correcta
            try
            {
                Console.WriteLine("EDITAR TRANSACCION \nDigite el numero de la transaccion que desea editar");
                int transaccion = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in Repositorio.instancia.transacciones)

                {
                    contador++;
                    if(transaccion == item.numero_trans)//Aqui verificamos si el numero de trans existe
                    {
                        //Aqui mostramos la transaccion elegida para el usuario confirme
                        Console.WriteLine("==================RESUMEN DE LA TRANSACCION=================");
                        Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado);
                        Console.WriteLine("======================================= \nSeguro que desea editar esta transaccion? S/N");
                        string opcion = Console.ReadLine().ToUpper();
                        switch (opcion)
                        {
                            case "S":
                                Console.WriteLine("Digite el nuevo nombre");
                                string nombre = Console.ReadLine();
                                Console.WriteLine("Digite el nuevo monto");
                                double monto = Convert.ToDouble(Console.ReadLine());

                                c_transacciones transaccion_editada = new c_transacciones(nombre, monto, item.numero_trans, item.estado);

                                Repositorio.instancia.transacciones[contador - 1] = transaccion_editada;
                                Console.WriteLine("Transaccion editada con exito!!");
                                Console.ReadKey();
                                menu_principal.menu();

                                break;
                            case "N":
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                menu_principal.menu();
                                break;
                            default:
                                Console.WriteLine("Error, volviendo al menu . . .");
                                Console.ReadKey();
                                menu_principal.menu();
                                break;
                        }
                        
                    }
                    
                    
                        
                    

                }
                Console.WriteLine("este numero de transaccion no exites\nDesea realizar otra busqueda? S/N");
                string opcion2 = Console.ReadLine().ToUpper();
                switch (opcion2)
                {
                    case "S":
                        editar();
                        break;
                    case "N":
                        Console.WriteLine("volviendo al menu . . .");
                        Console.ReadKey();
                        menu_principal.menu();
                        break;
                    default:
                        Console.WriteLine("Error, volviendo al menu . . .");
                        Console.ReadKey();
                        menu_principal.menu();
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                menu_principal.menu();
                throw;
            }
        }
        public void eliminar()
        {
            int contador = 0;
            Console.Clear();
            try
            {
                Console.WriteLine("ELIMINAR TRANSACCION \nDigite el numero de la transaccion que desea eliminar");
                int opcion = Convert.ToInt32(Console.ReadLine());
                foreach (var item in Repositorio.instancia.transacciones)
                {
                    contador++;
                    if (opcion == item.numero_trans)
                    {
                        Console.WriteLine("==================RESUMEN DE LA TRANSACCION=================");
                        Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado);
                        Console.WriteLine("======================================= \nSeguro que desea eliminar esta transaccion? S/N");
                        string opcion2 = Console.ReadLine().ToUpper();
                        switch (opcion2)
                        {
                            case "S":
                                //a partir de aqui vamos a determinar cual es el estado de la transaccion para saber a que
                                //listado la mandamos
                                if (item.estado == "APROBADA")
                                {//si esta aprobada al eliminarse se movera al listado de trans canceladas
                                    Repositorio.instancia.transacciones[contador - 1].estado = "CANCELADA";
                                    Repositorio.instancia.transacciones_canceladas.Add(Repositorio.instancia.transacciones[contador-1]);
                                    Repositorio.instancia.transacciones.RemoveAt(contador-1);
                                    Console.WriteLine("Transaccion cancelada con exito!!");
                                    Console.ReadKey();
                                    menu_principal.menu();
                                }
                                else if (item.estado == "RECHAZADA")
                                {//si esta aprobada al eliminarse se movera al listado de trans eliminadas
                                    Repositorio.instancia.transacciones[contador - 1].estado = "ELIMINADA";
                                    Repositorio.instancia.transacciones_eliminadas.Add(Repositorio.instancia.transacciones[contador - 1]);
                                    Repositorio.instancia.transacciones.RemoveAt(contador - 1);
                                    Console.WriteLine("Transaccion eliminada con exito!!");
                                    Console.ReadKey();
                                    menu_principal.menu();
                                }

                                break;
                            case "N":
                                Console.WriteLine("VOLVIENDO AL MENU . . .");
                                Console.ReadKey();
                                menu_principal.menu();
                                break;
                            default:
                                Console.WriteLine("Error, volviendo al menu . . .");
                                Console.ReadKey();
                                menu_principal.menu();
                                break;
                        }
                    }

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error, volviendo al menu . . .");
                Console.ReadKey();
                menu_principal.menu();
                throw;
            }
        }

        public void listar()
        {
            Console.WriteLine("LISTADO DE TRANSACCIONES\n====================TRANSACCIONES APROBADAS======================");
            foreach (var item in Repositorio.instancia.transacciones)
            {
                if (item.estado == "APROBADA")
                {
                    Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado+"--------------");
                }
            }
            Console.WriteLine("====================TRANSACCIONES RECHAZADAS======================");
            foreach (var item in Repositorio.instancia.transacciones)
            {
                if (item.estado == "RECHAZADA")
                {
                    Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado + "--------------");
                }
            }
            Console.WriteLine("====================TRANSACCIONES CANCELADAS======================");
            foreach (var item in Repositorio.instancia.transacciones_canceladas)
            {
                if (item.estado == "CANCELADA")
                {
                    Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado + "--------------");
                }
            }
            Console.WriteLine("====================TRANSACCIONES ELIMINADAS======================");
            foreach (var item in Repositorio.instancia.transacciones_eliminadas)
            {
                if (item.estado == "ELIMINADA")
                {
                    Console.WriteLine("Nombre del cliente : " + item.nombre_cliente + "\nMonto : " + item.monto + "\nEstado de la transaccion : " + item.estado + "--------------");
                }
            }
        }
       
        
    }
}
