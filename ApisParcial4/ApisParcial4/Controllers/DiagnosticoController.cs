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
    public class DiagnosticoController : ApiController
    {
        // GET para Select(Un elemento)
        public Diagnostico Get(int id)
        {
            return DiagnosticoData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Diagnostico> Get()
        {
            return DiagnosticoData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Diagnostico oDiagnostico)
        {
            return DiagnosticoData.Save(oDiagnostico);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Diagnostico oDiagnostico)
        {
            return DiagnosticoData.Edit(oDiagnostico);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return DiagnosticoData.Delete(id);
        }
    }
}