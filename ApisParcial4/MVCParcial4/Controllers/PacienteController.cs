using ApisParcial4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVCParcial4.Permisos;

namespace MVCParcial4.Controllers
{
    [ValidarSesion]
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
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
            }
            return View(Pacientes);
        }

        //[HttpPost]
        public ActionResult Create(Paciente Paciente)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Paciente Paciente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Paciente");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Paciente>("Paciente", Paciente);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Paciente);
        }

        public ActionResult Edit(int id)
        {
            Paciente Paciente = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Paciente?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Paciente>();
                    readTask.Wait();

                    Paciente = readTask.Result;
                }
            }

            return View(Paciente);
        }

        [HttpPost]
        public ActionResult Edit(Paciente Paciente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Paciente");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Paciente>("Paciente", Paciente);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Paciente);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Paciente/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }


    }
}
