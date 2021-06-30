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
    public class ArtiuloController : ControllerBase
    {
        private readonly AppDbContext context;
        public ArtiuloController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var articulos = context.articulo.ToList();
                return Ok(articulos);

            }catch(Exception Ex)
                {
                return BadRequest(Ex.Message);
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetArticulo")]
        public ActionResult Get(int id)
        {
            try
            {
                var articulo = context.articulo.FirstOrDefault(g => g.Id_Articulo == id);
                return Ok(articulo);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                context.articulo.Add(articulo);
                context.SaveChanges();
                return CreatedAtRoute("GetArituclo", new { id = articulo.Id_Articulo }, articulo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Articulo articulo)
        {
            try
            {
                if (articulo.Id_Articulo == id)
                {
                    context.articulo.Add(articulo);
                    context.SaveChanges();
                    return CreatedAtRoute("GetArticulo", new { id = articulo.Id_Articulo }, articulo);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var articulo = context.articulo.FirstOrDefault(g => g.Id_Articulo == id);
                if (articulo != null)
                {
                    context.articulo.Remove(articulo);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }

            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
