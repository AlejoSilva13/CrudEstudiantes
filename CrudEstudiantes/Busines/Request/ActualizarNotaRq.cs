﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEstudiantes.Busines.Request
{
    public class ActualizarNotaRq
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public float Valor { get; set; }
    }
}