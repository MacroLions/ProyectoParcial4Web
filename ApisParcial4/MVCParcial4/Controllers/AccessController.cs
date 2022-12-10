using ApisParcial4.Data;
using ApisParcial4.Models;
using MVCParcial4.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ApisParcial4.Controllers
{
    public class AccessController : Controller
    {

        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string user, string password)
        {
            try
            {
                IEnumerable<Paciente> Pacientes = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54028/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("Paciente");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Paciente>>();
                        readTask.Wait();

                        Pacientes = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        Pacientes = Enumerable.Empty<Paciente>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                    //select * from --- >Esto es LINQ
                    // select * from MIS_DATOS as d 
                    String passwordEdit = Encriptar.GetSHA256(password);
                    var lst = from d in Pacientes
                              where d.Usuario == user && d.Pass == passwordEdit
                              select d;  //select * from MIS_DATOS
                    if (lst.Count() > 0)
                    {
                        Paciente oPaciente = lst.First();

                        Session["Usuario"] = oPaciente;

                        return Content("1");

                    }
                    else
                    {
                        return Content("Usuario sin Acceso ");
                    }

                }




            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }

    }
}