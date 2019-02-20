using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales.Linear
{
    class GenericQueue<T>
    {
        private Nodo<T> Head;
        private Nodo<T> tail;
        private int count = 0;


        public void Enqueue(T value)
        {
            Nodo<T> _newNodo = new Nodo<T>(value);
            if (Head == null)
            {
                Head = _newNodo;
                tail = Head;
            }
            else
            {
                tail.Siguiente = _newNodo;
                tail = tail.Siguiente;
            }
            count++;
        }

        public int Dequeue()
        {
            if (Head == null)
            {
                throw new Exception("La cola esta vacia || Queue is Empty");
            }
            T result = (T)Head.Value;
            Head = Head.Siguiente;
            int resultado = Convert.ToInt32(result);
            return resultado;

        }
    }

}
