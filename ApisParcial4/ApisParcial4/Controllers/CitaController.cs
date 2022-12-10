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
    public class CitaController : ApiController
    {
        // GET para Select(Un elemento)
        public Cita Get(int id)
        {
            return CitaData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Cita> Get()
        {
            return CitaData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Cita oCita)
        {
            return CitaData.Save(oCita);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Cita oCita)
        {
            return CitaData.Edit(oCita);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return CitaData.Delete(id);
        }
    }
}