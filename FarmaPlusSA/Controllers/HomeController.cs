using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaPlusSA.Models;
using FarmaPlusSA.ViewModel;
using System.IO;

namespace FarmaPlusSA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Empleados(String empleado = "", Boolean office = false)
        {
            var viewModel = new citasEmpleado
            {
                Empleados = new List<Empleado>
                {
                    new Empleado {Nombre = "Lester", Horas = 0, estaEnOficina = false, Citas = new List<Cita>(0)}
                }
            };

            if (HttpContext.Application["CitasEmpleado"] != null)
            {
                viewModel = (citasEmpleado)HttpContext.Application["CitasEmpleado"];
            }

            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Empleados(string name)
        {
            var viewModel = (citasEmpleado)HttpContext.Application["CitasEmpleado"];
            viewModel.Empleados.Add(new Empleado
            {
                Nombre = name, Horas = 0, estaEnOficina = false, Citas = new List<Cita>(0)
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Citas()
        {
            var viewModel = new citasEmpleado
            {
                Empleados = new List<Empleado>
                {
                    new Empleado {Nombre = "Héctor", Horas = 0, estaEnOficina = true, Citas = new List<Cita>(0)}
                }
            };

            if (HttpContext.Application["CitasEmpleado"] != null)
            {
                viewModel = (citasEmpleado)HttpContext.Application["CitasEmpleado"];
            }

            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Citas(String i)
        {
            var viewModel = (citasEmpleado)HttpContext.Application["CitasEmpleado"];
            Random rnd = new Random();
            foreach (var empleado in viewModel.Empleados)
            {
                var nCitas = rnd.Next(1, 5);
                for (int o = 0; o < nCitas; o++)
                {
                    TimeSpan tSpan = new TimeSpan(2 * o, 0, 0);
                    empleado.Citas.Add(new Cita { Cliente = "Cliente " + o, horaFecha = DateTime.Now + tSpan });
                }
            }
            HttpContext.Application["CitasEmpleado"] = viewModel;
            return View(viewModel);
        }
    }
}