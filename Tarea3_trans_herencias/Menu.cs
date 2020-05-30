using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_trans_herencias
{
    class Menu
    {
        
        public void menu() {
            try
            {
                proceso_transacciones transacciones = new proceso_transacciones();
                Console.Clear();
                Console.WriteLine("Que tipo de operacion desea realizar \n1-Agregar transaccion \n2-Editar\n3-Eliminar\n4-Listar");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        transacciones.agregar();
                        break;
                    case 2:
                        transacciones.editar();
                        break;
                    case 3:
                        transacciones.eliminar();
                        break;
                    case 4:
                        transacciones.listar();
                        break;
                        
                    default:
                        Console.WriteLine("Error volviendo al menu . . .");
                        Console.ReadKey();
                        menu();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error volviendo al menu . . .");
                Console.ReadKey();
                menu();
                throw;
            }
            
        }

    }
}