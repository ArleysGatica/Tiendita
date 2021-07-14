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
    public class ClienteController : ControllerBase 
        {

        private readonly AppDbContext context;
        
        public ClienteController (AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<GestorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                //var clientes = context.Cliente.ToList();
                return Ok(context.Cliente.ToList());
                
            } catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // GET api/<GestorController>/5
        [HttpGet("{id}", Name = "GetGestor" )]
        public ActionResult Get(Guid id)
        {
            try
            {
                var gestor = context.Cliente.FirstOrDefault(g => g.ClienteID == id);
                return Ok(gestor);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<GestorController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente gestor)
        {
            try
            {
                gestor.ClienteID = new Guid();
                context.Cliente.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.ClienteID}, gestor);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente gestor)
        {
            try
            {
                if(gestor.ClienteID == id)
                {
                    context.Cliente.Add(gestor);
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.ClienteID }, gestor);
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

        // DELETE api/<GestorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var gestor = context.Cliente.FirstOrDefault(g => g.ClienteID == id);
                if (gestor != null)
                {              
                    context.Cliente.Remove(gestor);
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
