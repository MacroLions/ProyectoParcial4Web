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
    public class ExamenController : ApiController
    {
        // GET para Select(Un elemento)
        public Examen Get(int id)
        {
            return ExamenData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Examen> Get()
        {
            return ExamenData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Examen oExamen)
        {
            return ExamenData.Save(oExamen);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Examen oExamen)
        {
            return ExamenData.Edit(oExamen);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ExamenData.Delete(id);
        }
    }
}