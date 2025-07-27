using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Estado_Pedido")]
    public class Estado_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public Estado_PedidoControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado_Pedido>>> Get()
        {
            return await context.Estado_Pedido.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado_Pedido>> GetById(int id)
        {
            var estado = await context.Estado_Pedido.FindAsync(id);
            if (estado == null)
                return NotFound();

            return estado;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Estado_Pedido estado)
        {
            context.Estado_Pedido.Add(estado);
            await context.SaveChangesAsync();
            return estado.Estado_Pedido_Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estado_Pedido estado)
        {
            if (id != estado.Estado_Pedido_Id)
                return BadRequest();

            context.Entry(estado).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estado = await context.Estado_Pedido.FindAsync(id);
            if (estado == null)
                return NotFound();

            context.Estado_Pedido.Remove(estado);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
