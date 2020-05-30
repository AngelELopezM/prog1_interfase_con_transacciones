using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_trans_herencias
{
    public class c_transacciones

    { 
        public string nombre_cliente { get; set; }
        public double monto { get; set; }
        public string estado { get; set; }
        public int numero_trans { get; set; }

        public c_transacciones(string cliente, double monto, int numero, string estado)
        {
            this.nombre_cliente = cliente;
            this.monto = monto;
            this.estado = estado;
            this.numero_trans = numero;
            
        }
    }
}
