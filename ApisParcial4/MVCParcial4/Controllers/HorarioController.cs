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
    public class HorarioController : Controller
    {
        // GET: Horario
        public ActionResult Index()
        {
            IEnumerable<Horario> Horarios = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Horario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Horario>>();
                    readTask.Wait();

                    Horarios = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Horarios = Enumerable.Empty<Horario>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Horarios);
        }

        //[HttpPost]
        public ActionResult Create(Horario Horario)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Horario Horario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Horario");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Horario>("Horario", Horario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Horario);
        }

        public ActionResult Edit(int id)
        {
            Horario Horario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Horario?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Horario>();
                    readTask.Wait();

                    Horario = readTask.Result;
                }
            }

            return View(Horario);
        }

        [HttpPost]
        public ActionResult Edit(Horario Horario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Horario");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Horario>("Horario", Horario);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Horario);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Horario/" + id.ToString());
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
