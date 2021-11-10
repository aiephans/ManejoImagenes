using AutoMapper;
using ManejoImagenes.Models;
using ManejoImagenes.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Helpers
{
    public class Perfiles : Profile
    {
        public Perfiles()
        {
            CreateMap<Animal, AnimalModel>();
            CreateMap<AnimalCreacionModel, Animal>();
            CreateMap<AnimalEdicionModel, Animal>().ReverseMap();
        }
    }
}
