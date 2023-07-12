using CrudEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEstudiantes.Busines.Response
{
    public class ConsultarAlumnoRs
    {
        public int IdError { get; set; }
        public string Mensaje { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
    }
}