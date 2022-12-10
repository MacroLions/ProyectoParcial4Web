using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdClinica { get; set; }
        public String FechaCita { get; set; }
        public String HoraCita { get; set; }
    }
}