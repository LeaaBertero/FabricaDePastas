using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public ProductoControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Producto.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var dammy = await context.Producto.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto entidad)
        {
            try
            {
                context.Producto.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Producto.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Descripcion = entidad.Descripcion;
            dammy.PrecioBase = entidad.PrecioBase;
            dammy.Imagen_Url = entidad.Imagen_Url;
            dammy.Stock = entidad.Stock;
            

            try
            {
                context.Producto.Update(dammy);
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
            var existe = await context.Producto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }

            Producto EntidadAborrar = new Producto();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El producto {id} fue eliminado correctamente.");
        }
        #endregion


    }
}
