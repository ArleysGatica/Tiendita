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
    public class DetallePedidoController : ControllerBase
    {
        private readonly AppDbContext context;
        public DetallePedidoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.DetallePedido.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name ="GetDetallePedido")]
        public ActionResult Get(Guid id)
        {
            try
            {
                return Ok(context.DetallePedido.Where(g => id == g.ArticuloID).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] DetallePedidos detallePedido)
        {
            try
            {
                context.DetallePedido.Add(detallePedido);
                context.SaveChanges();
                return CreatedAtRoute("GetDetallePedido", new { id = detallePedido.ArticuloID }, detallePedido);
                Ok(detallePedido);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
