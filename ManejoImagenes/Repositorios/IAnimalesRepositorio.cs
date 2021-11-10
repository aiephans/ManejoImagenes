using ManejoImagenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Repositorios
{
    public interface IAnimalesRepositorio
    {
        Task Actualizar(AnimalEdicionModel model);
        Task<AnimalEdicionModel> BuscarPorId(int id);
        Task Eliminar(int id);
        Task Guardar(AnimalCreacionModel model);
        Task<List<AnimalModel>> ObtenerTodos();
    }
}
