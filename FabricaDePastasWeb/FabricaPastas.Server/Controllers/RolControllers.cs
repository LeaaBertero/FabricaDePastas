using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Rol")]
    public class RolControllers : ControllerBase
    {
        private readonly Context context;

        public RolControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> Get()
        {
            return await context.Rol.ToListAsync();
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var item = await context.Rol.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult<int>> Post(Rol rol)
        {
            context.Rol.Add(rol);
            await context.SaveChangesAsync();
            return rol.Rol_Id;
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rol rol)
        {
            if (id != rol.Rol_Id)
                return BadRequest();

            context.Entry(rol).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.Rol.FindAsync(id);
            if (item == null)
                return NotFound();

            context.Rol.Remove(item);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
