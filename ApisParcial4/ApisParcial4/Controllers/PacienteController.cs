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
    public class PacienteController : ApiController
    {
        // GET para Select(Un elemento)
        public Paciente Get(int id)
        {
            return PacienteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Paciente> Get()
        {
            return PacienteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Paciente oPaciente)
        {
            return PacienteData.Save(oPaciente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Paciente oPaciente)
        {
            return PacienteData.Edit(oPaciente);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return PacienteData.Delete(id);
        }
    }
}