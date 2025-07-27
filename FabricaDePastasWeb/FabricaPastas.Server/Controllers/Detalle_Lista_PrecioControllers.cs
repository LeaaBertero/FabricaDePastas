using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Lista_Precio")]
    public class Detalle_Lista_PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public Detalle_Lista_PrecioControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Detalle_Lista_Precio>>> Get()
        {
            return await context.Detalle_Lista_Precio.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Detalle_Lista_Precio>> Get(int id)
        {
            var detalle = await context.Detalle_Lista_Precio
                .FirstOrDefaultAsync(x => x.Detalle_Lista_Id == id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Detalle_Lista_Precio entidad)
        {
            try
            {
                context.Detalle_Lista_Precio.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Detalle_Lista_Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Detalle_Lista_Precio entidad)
        {
            if (id != entidad.Detalle_Lista_Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var detalle = await context.Detalle_Lista_Precio
                .FirstOrDefaultAsync(e => e.Detalle_Lista_Id == id);

            if (detalle == null)
            {
                return NotFound("No se encontró el detalle de la lista de precio.");
            }

            // Asignación de propiedades
            detalle.Lista_Precio_Id = entidad.Lista_Precio_Id;
            detalle.Producto_Id = entidad.Producto_Id;
            detalle.Precio_Personalizado = entidad.Precio_Personalizado;

            try
            {
                context.Detalle_Lista_Precio.Update(detalle);
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
            var existe = await context.Detalle_Lista_Precio
                .AnyAsync(x => x.Detalle_Lista_Id == id);

            if (!existe)
            {
                return NotFound($"El detalle con ID {id} no existe.");
            }

            var detalleABorrar = new Detalle_Lista_Precio { Detalle_Lista_Id = id };

            context.Remove(detalleABorrar);
            await context.SaveChangesAsync();

            return Ok($"El detalle {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
