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
    public class MedicamentoController : ApiController
    {
        // GET para Select(Un elemento)
        public Medicamento Get(int id)
        {
            return MedicamentoData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Medicamento> Get()
        {
            return MedicamentoData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Medicamento oMedicamento)
        {
            return MedicamentoData.Save(oMedicamento);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Medicamento oMedicamento)
        {
            return MedicamentoData.Edit(oMedicamento);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return MedicamentoData.Delete(id);
        }
    }
}