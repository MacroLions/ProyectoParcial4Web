using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Clinica
    {
        public int IdClinica { get; set; }
        public String NombreClinica { get; set; }
        public int IdDoctorAsignado { get; set; }
    }
}