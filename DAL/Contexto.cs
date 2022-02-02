using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Registro_Estudiantes.Entidades;

namespace Registro_Estudiantes.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DATA/Estudiantes.db");            
        }
    }
}