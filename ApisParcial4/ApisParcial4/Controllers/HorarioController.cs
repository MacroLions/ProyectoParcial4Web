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
    public class HorarioController : ApiController
    {
        // GET para Select(Un elemento)
        public Horario Get(int id)
        {
            return HorarioData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Horario> Get()
        {
            return HorarioData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Horario oHorario)
        {
            return HorarioData.Save(oHorario);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Horario oHorario)
        {
            return HorarioData.Edit(oHorario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return HorarioData.Delete(id);
        }
    }
}