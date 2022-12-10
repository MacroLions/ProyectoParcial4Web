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
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            IEnumerable<Doctor> Doctors = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Doctor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Doctor>>();
                    readTask.Wait();

                    Doctors = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Doctors = Enumerable.Empty<Doctor>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Doctors);
        }

        //[HttpPost]
        public ActionResult Create(Doctor Doctor)
        {
            return View();

        }

        [HttpPost]
        public ActionResult create(Doctor Doctor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Doctor");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Doctor>("Doctor", Doctor);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Doctor);
        }

        public ActionResult Edit(int id)
        {
            Doctor Doctor = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Doctor?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Doctor>();
                    readTask.Wait();

                    Doctor = readTask.Result;
                }
            }

            return View(Doctor);
        }

        [HttpPost]
        public ActionResult Edit(Doctor Doctor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/Doctor");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Doctor>("Doctor", Doctor);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Doctor);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54028/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Doctor/" + id.ToString());
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
