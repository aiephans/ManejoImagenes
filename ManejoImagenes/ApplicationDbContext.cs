﻿using ManejoImagenes.Models;
using ManejoImagenes.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {

        }

        public DbSet<Animal> Animales { get; set; }
    }
}
