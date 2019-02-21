using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaPlusSA.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int horasTrabajadas { get; set; }
        public int Salario { get; set; }
        public Boolean estaEnOficina { get; set; }
        public List<Citas> Citas { get; set; }
    }
}