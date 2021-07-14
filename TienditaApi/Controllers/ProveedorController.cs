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
    public class ProveedorController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProveedorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var proveedor = context.Proveedores .ToList();
                return Ok(proveedor);

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetProveedor")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var proveedor = context.Proveedores.FirstOrDefault(g => g.ProveedorID == id);
                return Ok(proveedor);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedor proveedor)
        {
            try
            {
                proveedor.ProveedorID = new Guid();
                context.Proveedores.Add(proveedor);
                context.SaveChanges();
                return CreatedAtRoute("GetProveedor", new { id = proveedor.ProveedorID }, proveedor);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}", Name ="GetProveedor")]
        public ActionResult Put(Guid id, [FromBody] Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorID == id)
                {
                    context.Proveedores.Add(proveedor);
                    context.SaveChanges();
                    return CreatedAtRoute("GetArticulo", new { id = proveedor.ProveedorID }, proveedor);
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
        [HttpDelete("{id}", Name = "GetProveedor")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var Proveedor = context.Proveedores.FirstOrDefault(g => g.ProveedorID == id);
                if (Proveedor != null)
                {
                    context.Proveedores.Remove(Proveedor);
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
