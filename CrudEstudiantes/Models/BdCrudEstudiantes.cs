using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CrudEstudiantes.Models
{
    public partial class BdCrudEstudiantes : DbContext
    {
        public BdCrudEstudiantes()
            : base("name=BdCrudEstudiantes")
        {
        }

        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);
        }
    }
}
