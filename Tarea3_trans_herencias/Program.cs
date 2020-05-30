using System;

namespace Tarea3_trans_herencias
{
    class Program
    {
        //public int numero_transaccion = 0;
        static void Main(string[] args)
        {
            
        Menu menu_principal = new Menu(); //aqui como no ponemos las clases en static, tenemos que instanciar
            //para despues poder llamar a los metodos pertenecientes a esas clases
            menu_principal.menu();
        }
    }
}
