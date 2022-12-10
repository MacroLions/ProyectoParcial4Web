using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApisParcial4.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public String HorarioApertura { get; set; }
        public String HorarioCierre { get; set; }
        public int IdClinicaAsignada { get; set; }
    }
}