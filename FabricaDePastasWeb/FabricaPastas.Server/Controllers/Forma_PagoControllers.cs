using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Forma_Pago")]
    public class Forma_PagoControllers : ControllerBase
    {
        private readonly Context context;

        public Forma_PagoControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forma_Pago>>> Get()
        {
            return await context.Forma_Pago.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Forma_Pago>> GetById(int id)
        {
            var formaPago = await context.Forma_Pago.FindAsync(id);
            if (formaPago == null)
                return NotFound();

            return formaPago;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Forma_Pago formaPago)
        {
            context.Forma_Pago.Add(formaPago);
            await context.SaveChangesAsync();
            return formaPago.Forma_Pago_Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Forma_Pago formaPago)
        {
            if (id != formaPago.Forma_Pago_Id)
                return BadRequest();

            context.Entry(formaPago).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var formaPago = await context.Forma_Pago.FindAsync(id);
            if (formaPago == null)
                return NotFound();

            context.Forma_Pago.Remove(formaPago);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
