using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Metodo_Entrega")]
    public class Metodo_EntregaControllers : ControllerBase
    {
        private readonly Context context;

        public Metodo_EntregaControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metodo_Entrega>>> Get()
        {
            return await context.Metodo_entrega.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Metodo_Entrega>> GetById(int id)
        {
            var metodo = await context.Metodo_entrega.FindAsync(id);
            if (metodo == null)
                return NotFound();

            return metodo;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Metodo_Entrega metodo)
        {
            context.Metodo_entrega.Add(metodo);
            await context.SaveChangesAsync();
            return metodo.Metodo_Entrega_Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Metodo_Entrega metodo)
        {
            if (id != metodo.Metodo_Entrega_Id)
                return BadRequest();

            context.Entry(metodo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var metodo = await context.Metodo_entrega.FindAsync(id);
            if (metodo == null)
                return NotFound();

            context.Metodo_entrega.Remove(metodo);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
