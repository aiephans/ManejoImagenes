using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Models
{
    public class AnimalCreacionModel
    {
        [Required(ErrorMessage ="El Campo Nombre es requerido")]
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
