using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;
        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.categoria.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult Get(int id)
        {
            try
            {
                var SeleccionarCategoria = context.categoria.FirstOrDefault(g => g.CategoriaID == id);
                return Ok(SeleccionarCategoria);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult Post([FromBody] Categoria NewCategoria)
        {
            try
            {
                context.categoria.Add(NewCategoria);
                context.SaveChanges();
                return CreatedAtRoute("GetCategoria", new { id = NewCategoria.CategoriaID }, NewCategoria);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria NewCategoria)
        {
            try
            {
                if (NewCategoria.CategoriaID == id)
                {
                    context.Entry(NewCategoria).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCategoria", new { id = NewCategoria.CategoriaID }, NewCategoria);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var EliminarCategoria = context.categoria.FirstOrDefault(g => g.CategoriaID == id);

                if (EliminarCategoria != null)
                {
                    context.categoria.Remove(EliminarCategoria);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}