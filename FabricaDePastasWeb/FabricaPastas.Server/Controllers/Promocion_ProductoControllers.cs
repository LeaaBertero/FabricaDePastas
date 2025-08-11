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

        #region constructor
        public Promocion_ProductoControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion_Producto>>> Get()
        {
            return await context.Promocion_Producto.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Promocion_Producto entidad)
        {
            try
            {
                context.Promocion_Producto.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion
      
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Promocion_Producto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La promoción del producto {id} no existe.");
            }

            Promocion_Producto EntidadAborrar = new Promocion_Producto();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"La promoción {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
