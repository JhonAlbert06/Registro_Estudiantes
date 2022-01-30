using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using RegistroCarreras.Entidades;

namespace RegistroCarreras.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Sourse=DATA/Estudiantes.db");            
        }
    }
}