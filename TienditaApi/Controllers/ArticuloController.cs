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
    public class ArticuloController : ControllerBase
    {
        private readonly AppDbContext context;
        public ArticuloController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
            
               // return Ok(context.Articulo.ToList());
              var articulos = context.Articulo.ToArray();
               return Ok(articulos);

            }catch(Exception Ex)
                {
                return BadRequest(Ex.Message);
            }

        }

        // GET api/<ValuesController>/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}", Name = "GetArticulo")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var articulo = context.Articulo.FirstOrDefault(g => g.ArticuloID == id);
                return Ok(articulo);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<ValuesController>
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public ActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                articulo.ArticuloID = new Guid();
                context.Articulo.Add(articulo);
                context.SaveChanges();
                return CreatedAtRoute("GetArticulo", new { id = articulo.ArticuloID }, articulo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Articulo articulo)
        {
            try
            {
                if (articulo.ArticuloID == id)
                {
                    context.Entry(articulo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetArticulo", new { id = articulo.ArticuloID }, articulo);
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
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var articulo = context.Articulo.FirstOrDefault(g => g.ArticuloID == id);
                if (articulo != null)
                {
                    context.Articulo.Remove(articulo);
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
