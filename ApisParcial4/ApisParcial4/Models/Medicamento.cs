using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Medicamento
    {
        public int IdMedicamento { get; set; }
        public String NombreMedicamento { get; set; }
        public int IdPaciente { get; set; }
    }
}