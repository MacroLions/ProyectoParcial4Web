using ApisParcial4.Data;
using ApisParcial4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace ApisParcial4.Controllers
{
    public class DoctorController : ApiController
    {
        // GET para Select(Un elemento)
        public Doctor Get(int id)
        {
            return DoctorData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Doctor> Get()
        {
            return DoctorData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Doctor oDoctor)
        {
            return DoctorData.Save(oDoctor);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Doctor oDoctor)
        {
            return DoctorData.Edit(oDoctor);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return DoctorData.Delete(id);
        }
    }
}