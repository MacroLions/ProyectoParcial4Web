using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public String NombrePaciente { get; set; }
        public String ApellidoPaciente { get; set; }
        public String Correo { get; set; }
        public String Usuario { get; set; }
        public String Pass { get; set; }
    }
}