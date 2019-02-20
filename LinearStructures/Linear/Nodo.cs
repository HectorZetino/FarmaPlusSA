using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales.Linear
{
    public class Nodo<T>
    {
        public Nodo(T value)
        {
            this.Value = value;
        }

        //Atributos
        public T Value
        {
            set;
            get;
        }

        public Nodo<T> Siguiente
        {
            set;
            get;
        }
    }

}

