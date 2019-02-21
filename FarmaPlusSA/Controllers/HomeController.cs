using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaPlusSA.Models;
using FarmaPlusSA.ViewModel;
using System.ComponentModel.DataAnnotations;

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
        public ActionResult Trabajadores(String Trabajador = "", Boolean estaEnOficina = false)
        {
            var viewModel = new citasTrabajador
            {
                Trabajdores = new List<Trabajador>
                {
                    new Trabajador {Nombre = "Fabrizzio", horasTrabajadas = 0, estaEnOficina = false, Citas = new List<Citas>(0)}
                }
            };

            if (HttpContext.Application["CitasEmpleado"] != null)
            {
                viewModel = (citasTrabajador)HttpContext.Application["CitasTrabajador"];
            }

            HttpContext.Application["CitasTrabajador"] = viewModel;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Trabajadores(string Nombre)
        {
            var viewModel = (citasTrabajador)HttpContext.Application["CitasTrabajador"];
            viewModel.Trabajdores.Add(new Trabajador
            {
                Nombre = Nombre, horasTrabajadas = 0, estaEnOficina = false, Citas = new List<Citas>(0)
            });
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Citas()
        {
            var viewModel = new citasTrabajador
            {
                Trabajdores = new List<Trabajador>
                {
                    new Trabajador {Nombre = "Lester", horasTrabajadas = 0, estaEnOficina = true, Citas = new List<Citas>(0)}
                }
            };

            if (HttpContext.Application["CitasTrabajador"] != null)
            {
                viewModel = (citasTrabajador)HttpContext.Application["CitasTrabajador"];
            }

            HttpContext.Application["CitasTrabajador"] = viewModel;
            return View(viewModel);
        }
    }
}