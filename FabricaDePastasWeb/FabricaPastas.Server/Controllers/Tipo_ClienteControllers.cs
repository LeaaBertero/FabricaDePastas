using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Tipo_Cliente")]
    public class Tipo_ClienteControllers : ControllerBase
    {
        private readonly Context context;

        public Tipo_ClienteControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Tipo_Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Cliente>>> Get()
        {
            return await context.Tipo_Cliente.ToListAsync();
        }

        // GET: api/Tipo_Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_Cliente>> GetById(int id)
        {
            var item = await context.Tipo_Cliente.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Tipo_Cliente
        [HttpPost]
        public async Task<ActionResult<int>> Post(Tipo_Cliente tipoCliente)
        {
            context.Tipo_Cliente.Add(tipoCliente);
            await context.SaveChangesAsync();
            return tipoCliente.Tipo_Cliente_Id;
        }

        // PUT: api/Tipo_Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tipo_Cliente tipoCliente)
        {
            if (id != tipoCliente.Tipo_Cliente_Id)
                return BadRequest();

            context.Entry(tipoCliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Tipo_Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.Tipo_Cliente.FindAsync(id);
            if (item == null)
                return NotFound();

            context.Tipo_Cliente.Remove(item);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
