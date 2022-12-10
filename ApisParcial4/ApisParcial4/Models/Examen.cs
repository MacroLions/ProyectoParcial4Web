using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Examen
    {
        public int IdExamen { get; set; }
        public String NombreExamen { get; set; }
        public int IdPaciente { get; set; }
    }
}