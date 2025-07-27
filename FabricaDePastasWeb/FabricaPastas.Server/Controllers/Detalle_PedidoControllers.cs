using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Pedido")]
    public class Detalle_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public Detalle_PedidoControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Pedido>>> Get()
        {
            return await context.Detalle_Pedido.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle_Pedido>> GetById(int id)
        {
            var detalle = await context.Detalle_Pedido.FindAsync(id);
            if (detalle == null)
                return NotFound();

            return detalle;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Detalle_Pedido detalle)
        {
            context.Detalle_Pedido.Add(detalle);
            await context.SaveChangesAsync();
            return detalle.Detalle_Pedido_Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Detalle_Pedido detalle)
        {
            if (id != detalle.Detalle_Pedido_Id)
                return BadRequest();

            context.Entry(detalle).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await context.Detalle_Pedido.FindAsync(id);
            if (detalle == null)
                return NotFound();

            context.Detalle_Pedido.Remove(detalle);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
