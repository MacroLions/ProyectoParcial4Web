using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public String NombreDiagnostico { get; set; }
        public int IdPaciente { get; set; }
    }
}