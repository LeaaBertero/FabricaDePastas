using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Usuario")]
    public class Promocion_UsuarioControllers : ControllerBase
    {
        private readonly Context context;

        public Promocion_UsuarioControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Promocion_Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promocion_Usuario>>> Get()
        {
            return await context.Promocion_Usuario.ToListAsync();
        }

        // GET: api/Promocion_Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocion_Usuario>> GetById(int id)
        {
            var item = await context.Promocion_Usuario.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Promocion_Usuario
        [HttpPost]
        public async Task<ActionResult<int>> Post(Promocion_Usuario promocionUsuario)
        {
            context.Promocion_Usuario.Add(promocionUsuario);
            await context.SaveChangesAsync();
            return promocionUsuario.Promocion_Usuario_Id;
        }

        // PUT: api/Promocion_Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Promocion_Usuario promocionUsuario)
        {
            if (id != promocionUsuario.Promocion_Usuario_Id)
                return BadRequest();

            context.Entry(promocionUsuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Promocion_Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.Promocion_Usuario.FindAsync(id);
            if (item == null)
                return NotFound();

            context.Promocion_Usuario.Remove(item);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
