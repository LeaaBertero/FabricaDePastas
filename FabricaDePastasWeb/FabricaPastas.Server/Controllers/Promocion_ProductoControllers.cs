using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Producto")]
    public class Promocion_ProductoControllers : ControllerBase
    {
        private readonly Context context;

        public Promocion_ProductoControllers(Context context)
        {
            this.context = context;
        }

        // GET: api/Promocion_Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promocion_Producto>>> Get()
        {
            return await context.Promocion_Producto.ToListAsync();
        }

        // GET: api/Promocion_Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocion_Producto>> GetById(int id)
        {
            var promocionProducto = await context.Promocion_Producto.FindAsync(id);
            if (promocionProducto == null)
                return NotFound();

            return promocionProducto;
        }

        // POST: api/Promocion_Producto
        [HttpPost]
        public async Task<ActionResult<int>> Post(Promocion_Producto promocionProducto)
        {
            context.Promocion_Producto.Add(promocionProducto);
            await context.SaveChangesAsync();
            return promocionProducto.Promocion_Producto_Id;
        }

        // PUT: api/Promocion_Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Promocion_Producto promocionProducto)
        {
            if (id != promocionProducto.Promocion_Producto_Id)
                return BadRequest();

            context.Entry(promocionProducto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Promocion_Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var promocionProducto = await context.Promocion_Producto.FindAsync(id);
            if (promocionProducto == null)
                return NotFound();

            context.Promocion_Producto.Remove(promocionProducto);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
