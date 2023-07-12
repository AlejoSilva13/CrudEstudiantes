namespace CrudEstudiantes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nota")]
    public partial class Nota
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nomre { get; set; }

        public int? IdProfesor { get; set; }

        public int? IdEstudiante { get; set; }

        public double? valor { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
