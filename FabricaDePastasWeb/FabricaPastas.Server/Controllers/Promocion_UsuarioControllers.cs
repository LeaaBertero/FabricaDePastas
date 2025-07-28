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

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion_Usuario>>> Get()
        {
            return await context.Promocion_Usuario.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Promocion_Usuario entidad)
        {
            try
            {
                context.Promocion_Usuario.Add(entidad);
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
            var existe = await context.Promocion_Usuario.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La promoción del usuario {id} no existe.");
            }

            Promocion_Usuario EntidadAborrar = new Promocion_Usuario();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"La promoción del usuario {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
