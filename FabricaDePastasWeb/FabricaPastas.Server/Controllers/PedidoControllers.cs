using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Pedido")]
    public class PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public PedidoControllers(Context context)
        {
            this.context = context;
        }


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            return await context.Pedido.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var dammy = await context.Pedido.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Pedido entidad)
        {
            try
            {
                context.Pedido.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pedido entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Pedido.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Fecha_Pedido = entidad.Fecha_Pedido;
            dammy.Total = entidad.Total;
            

            try
            {
                context.Pedido.Update(dammy);
                await context.SaveChangesAsync();
                return Ok();

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
            var existe = await context.Pedido.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El pedido {id} no existe.");
            }

            Pedido EntidadAborrar = new Pedido();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El pedido {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
