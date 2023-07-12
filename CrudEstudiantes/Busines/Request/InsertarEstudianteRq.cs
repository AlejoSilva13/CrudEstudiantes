using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEstudiantes.Busines.Request
{
    public class InsertarEstudianteRq
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
    }
}