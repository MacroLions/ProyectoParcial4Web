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
    public class DiagnosticoController : Controller
    {
        // GET: Diagnostico
        public ActionResult Index()
        {
            IEnumerable<Diagnostico> Diagnosticos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Diagnostico");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Diagnostico>>();
                    readTask.Wait();

                    Diagnosticos = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Diagnosticos = Enumerable.Empty<Diagnostico>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Diagnosticos);
        }

        //[HttpPost]
        public ActionResult Create(Diagnostico Diagnostico)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Diagnostico Diagnostico)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Diagnostico");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Diagnostico>("Diagnostico", Diagnostico);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Diagnostico);
        }

        public ActionResult Edit(int id)
        {
            Diagnostico Diagnostico = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Diagnostico?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Diagnostico>();
                    readTask.Wait();

                    Diagnostico = readTask.Result;
                }
            }

            return View(Diagnostico);
        }

        [HttpPost]
        public ActionResult Edit(Diagnostico Diagnostico)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Diagnostico");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Diagnostico>("Diagnostico", Diagnostico);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Diagnostico);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Diagnostico/" + id.ToString());
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
