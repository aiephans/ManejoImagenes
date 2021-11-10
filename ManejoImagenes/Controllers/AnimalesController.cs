using ManejoImagenes.Helpers;
using ManejoImagenes.Models;
using ManejoImagenes.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoImagenes.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly IAnimalesRepositorio _repositorio;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string NombreCarpeta = "imagenes_animales";

        public AnimalesController(IAnimalesRepositorio repositorio, IAlmacenadorArchivos almacenadorArchivos )
        {
            _repositorio = repositorio;
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _repositorio.ObtenerTodos();
            return View(list);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(AnimalCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Imagen != null)
                {
                    //Guardar la imagen como archivo
                    //obtener la url de esa imagen guardada
                    //asignar esa url a la propiedad del modelo

                    var urlImagen = await _almacenadorArchivos.GuardarArchivo(model.Imagen, NombreCarpeta);
                    model.ImagenUrl = urlImagen;

                }

                await _repositorio.Guardar(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }
        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            var model = await _repositorio.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AnimalEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Imagen != null)
                {
                    //Eliminar la imagen
                    await _almacenadorArchivos.EliminarArchivo(model.ImagenUrl, NombreCarpeta);
                    //Guardar la nueva imagen
                    var nuevaImagenUrl = await _almacenadorArchivos.GuardarArchivo(model.Imagen, NombreCarpeta);
                    //Obtener la nueva url
                    //Actualizar el registro con la nueva url
                    model.ImagenUrl = nuevaImagenUrl;
                }
                await _repositorio.Actualizar(model);
                return RedirectToAction("Index");
            }

            return View("Editar", model);
        }
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            //Eliminar la imagen
            var entidad =await _repositorio.BuscarPorId(id);
            await _almacenadorArchivos.EliminarArchivo(entidad.ImagenUrl, NombreCarpeta);
            //Eliminamos el registro
            await _repositorio.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}
