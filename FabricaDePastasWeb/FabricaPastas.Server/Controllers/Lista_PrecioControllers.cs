using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Lista_Precio")]
    public class Lista_PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public Lista_PrecioControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lista_Precio>>> Get()
        {
            return await context.Lista_Precio.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lista_Precio>> GetById(int id)
        {
            var lista = await context.Lista_Precio.FindAsync(id);
            if (lista == null)
                return NotFound();

            return lista;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Lista_Precio lista)
        {
            context.Lista_Precio.Add(lista);
            await context.SaveChangesAsync();
            return lista.Lista_Precio_Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Lista_Precio lista)
        {
            if (id != lista.Lista_Precio_Id)
                return BadRequest();

            context.Entry(lista).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lista = await context.Lista_Precio.FindAsync(id);
            if (lista == null)
                return NotFound();

            context.Lista_Precio.Remove(lista);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
