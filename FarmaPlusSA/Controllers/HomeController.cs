using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaPlusSA.Controllers;
using FarmaPlusSA.Models;
using EstructurasLineales.Linear;
using System.IO;


namespace FarmaPlusSA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Trabajador>());
        }

        [HttpPost]
       
        public ActionResult Index(HttpPostedFileBase postedFile)
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



       /* public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
        



    }
}