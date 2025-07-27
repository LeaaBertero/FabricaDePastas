using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Pedido")]
    public class PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public PedidoControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            return await context.Pedido.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            var pedido = await context.Pedido.FindAsync(id);
            if (pedido == null)
                return NotFound();

            return pedido;
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<ActionResult<int>> Post(Pedido pedido)
        {
            context.Pedido.Add(pedido);
            await context.SaveChangesAsync();
            return pedido.Pedido_Id;
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido pedido)
        {
            if (id != pedido.Pedido_Id)
                return BadRequest();

            context.Entry(pedido).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await context.Pedido.FindAsync(id);
            if (pedido == null)
                return NotFound();

            context.Pedido.Remove(pedido);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
