using AutoMapper;
using ManejoImagenes.Models;
using ManejoImagenes.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Repositorios
{
    public class AnimalesRepositorio : IAnimalesRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnimalesRepositorio(ApplicationDbContext context, IMapper  mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AnimalModel>> ObtenerTodos()
        {
            var entidades = await _context.Animales.ToListAsync();
            var listaModel = _mapper.Map<List<AnimalModel>>(entidades);
            return listaModel;
        }

        public async Task Guardar(AnimalCreacionModel model)
        {
            var entidad = _mapper.Map<Animal>(model);
            _context.Animales.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<AnimalEdicionModel> BuscarPorId(int id)
        {
            var entidad = await _context.Animales.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<AnimalEdicionModel>(entidad);
            return model;
        }

        public async Task Actualizar(AnimalEdicionModel model)
        {
            var entidad = await _context.Animales.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            entidad.ImagenUrl = model.ImagenUrl;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var entidad = await _context.Animales.FirstOrDefaultAsync(x => x.Id == id);
            _context.Animales.Remove(entidad);
            await _context.SaveChangesAsync();
        }

    }
}
