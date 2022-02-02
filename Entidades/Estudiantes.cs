using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro_Estudiantes.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudiantesID { get; set; }
        public string? Nombres { get; set; }
        public string? Email { get; set; }
        public int CarreraID { get; set; }
        public bool Activo { get; set; }
/*
        Estudiantes (int estudiantesid, string nombres, string email, int carrera, bool activo)
        {
            this.EstudiantesID = estudiantesid;
            this.Nombres = nombres;
            this.Email = email;
            this.CarreraID = carrera;
            this.Activo = activo;
        }
*/
    }
}