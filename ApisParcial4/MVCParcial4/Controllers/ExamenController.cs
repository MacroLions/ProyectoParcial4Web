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
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult Index()
        {
            IEnumerable<Examen> Examens = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Examen");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Examen>>();
                    readTask.Wait();

                    Examens = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Examens = Enumerable.Empty<Examen>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Examens);
        }

        //[HttpPost]
        public ActionResult Create(Examen Examen)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Examen Examen)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Examen");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Examen>("Examen", Examen);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Examen);
        }

        public ActionResult Edit(int id)
        {
            Examen Examen = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Examen?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Examen>();
                    readTask.Wait();

                    Examen = readTask.Result;
                }
            }

            return View(Examen);
        }

        [HttpPost]
        public ActionResult Edit(Examen Examen)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Examen");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Examen>("Examen", Examen);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Examen);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Examen/" + id.ToString());
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
