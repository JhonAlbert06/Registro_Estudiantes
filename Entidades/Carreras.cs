using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroCarreras.Entidades
{
    public class Carreras
    {
        [key]
        public int CarreraID { get; set; }
        public string? Nombre { get; set; }

        Carreras (int carreraid, string nombre)
        {
            this.CarreraID = carreraid;
            this.Nombre = nombre;
        }

    }
}