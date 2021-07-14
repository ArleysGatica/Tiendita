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
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext context;
        public PedidoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            {
                try
                {
                    var pedido = context.pedido .ToList();
                    return Ok(pedido);

                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex.Message);
                }

            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name= "GetPedido")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var pedido = context.pedido.FirstOrDefault(g => g.PedidoID == id);
                return Ok(pedido);
            }

            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Pedido pedido)
        {
            try
            {

                pedido.PedidoID = new Guid();
                context.Add(pedido);
                context.SaveChanges();
                return CreatedAtRoute("GetPedido", new { id = pedido.PedidoID }, pedido);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido pedido)
        {
            try
            {
                if (pedido.PedidoID == id)
                {
                    context.pedido.Add(pedido);
                    context.SaveChanges();
                    return CreatedAtRoute("GetPedido", new { id = pedido.PedidoID }, pedido);
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
        public ActionResult Delete(Guid id)
        {
            try
            {
                var pedido = context.pedido.FirstOrDefault(g => g.PedidoID == id);
                if (pedido != null)
                {
                    context.pedido.Remove(pedido);
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
