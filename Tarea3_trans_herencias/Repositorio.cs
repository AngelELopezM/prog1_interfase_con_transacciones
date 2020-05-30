using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_trans_herencias
{
    public sealed class Repositorio //sealed para que esta clase no se pueda heredar
    {
       public List<c_transacciones> transacciones { get; set; } = new List<c_transacciones>();
        public List<c_transacciones> transacciones_canceladas { get; set; } = new List<c_transacciones>();
        public List<c_transacciones> transacciones_eliminadas { get; set; } = new List<c_transacciones>();

        public static Repositorio instancia { get; } = new Repositorio();

        private Repositorio() 
        {

        }
    }
}
