using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaPlusSA.Models
{
    public class Trabajador
    {

            public string Nombre { get; set; }

            public string Cod_empleado { get; set; }

            public double Total_horas_trabajadas { get; set; }

            public string EstadiaOficina { get; set; }

            public double Salario { get; set; }
       
    }
}