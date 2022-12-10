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
    public class ClinicaController : ApiController
    {
        // GET para Select(Un elemento)
        public Clinica Get(int id)
        {
            return ClinicaData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Clinica> Get()
        {
            return ClinicaData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Clinica oClinica)
        {
            return ClinicaData.Save(oClinica);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Clinica oClinica)
        {
            return ClinicaData.Edit(oClinica);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ClinicaData.Delete(id);
        }
    }
}