using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Models
{
    public class AnimalEdicionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo Nombre es requierido")]
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
