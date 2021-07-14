using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TienditaApi.Context;
using TienditaApi.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TienditaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Arti_CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;
        public Arti_CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Arti_CategoriaController>
        [HttpGet]
        public ActionResult Get(int id)
        {
            try
            {
                //var SeleccionarProducto = context.Producto.Where(s => s.IdCategoria == id).ToList();
                var SeleccionarProducto = context.categoria.Where(s => s.CategoriaID == id)
                    .Join(
                        context.Articulo,
                        Categoria => Categoria.CategoriaID,
                        articulo => articulo.Categoria.CategoriaID,
                        (Categoria, articulo) => new
                        {
                            Categoria = Categoria.Nombre,
                            Descripcion = Categoria.Descripcion,
                            Producto = articulo.NombreArt,
                            Imagen = articulo.Imagen,
                            Precio = articulo.Precio,
                            Stock = articulo.Stock
                            
                        }
                    ).ToList();
                return Ok(SeleccionarProducto);
            }
            catch (Exception EX)
            {

                return BadRequest(EX.Message);
            }
        }

    }

    }

