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

        //codigo para leer Archivos de Texto Separados Por comas
        /* public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<Trabajador> trabajador = new List<Trabajador>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                foreach (string row in csvData.Split('#'))
                {
                        if (!string.IsNullOrEmpty(row))
                        {
                            trabajador.Add(new Trabajador
                            {
                                Cod_empleado = row.Split(',')[0],
                                Nombre = row.Split(',')[1],
                                Total_horas_trabajadas = Convert.ToDouble(row.Split(',')[2]),
                                EstadiaOficina = row.Split(',')[3],
                                Salario = Convert.ToDouble(row.Split(',')[4])
                            });
                        }
                }
                
            }
            return View(trabajador);
        }
         */
    }
}