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
    public class ClinicaController : Controller
    {
        // GET: Clinica
        public ActionResult Index()
        {
            IEnumerable<Clinica> Clinicas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Clinica");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Clinica>>();
                    readTask.Wait();

                    Clinicas = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Clinicas = Enumerable.Empty<Clinica>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Clinicas);
        }

        //[HttpPost]
        public ActionResult Create(Clinica Clinica)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Clinica Clinica)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Clinica");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Clinica>("Clinica", Clinica);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Clinica);
        }

        public ActionResult Edit(int id)
        {
            Clinica Clinica = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Clinica?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Clinica>();
                    readTask.Wait();

                    Clinica = readTask.Result;
                }
            }

            return View(Clinica);
        }

        [HttpPost]
        public ActionResult Edit(Clinica Clinica)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Clinica");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Clinica>("Clinica", Clinica);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Clinica);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Clinica/" + id.ToString());
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
