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
    public class MedicamentoController : Controller
    {
        // GET: Medicamento
        public ActionResult Index()
        {
            IEnumerable<Medicamento> Medicamentos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Medicamento");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Medicamento>>();
                    readTask.Wait();

                    Medicamentos = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Medicamentos = Enumerable.Empty<Medicamento>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Medicamentos);
        }

        //[HttpPost]
        public ActionResult Create(Medicamento Medicamento)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Medicamento Medicamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Medicamento");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Medicamento>("Medicamento", Medicamento);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Medicamento);
        }

        public ActionResult Edit(int id)
        {
            Medicamento Medicamento = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Medicamento?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Medicamento>();
                    readTask.Wait();

                    Medicamento = readTask.Result;
                }
            }

            return View(Medicamento);
        }

        [HttpPost]
        public ActionResult Edit(Medicamento Medicamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Medicamento");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Medicamento>("Medicamento", Medicamento);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Medicamento);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Medicamento/" + id.ToString());
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
