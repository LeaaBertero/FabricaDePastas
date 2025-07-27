using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Categoria_Producto")]
    public class Categoria_ProductoControllers : ControllerBase
    {
        private readonly Context context;

        public Categoria_ProductoControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Categoria_Producto>>> Get()
        {
            return await context.Categoria_Producto.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria_Producto>> Get(int id)
        {
            var categoria = await context.Categoria_Producto
                .FirstOrDefaultAsync(x => x.Categoria_Producto_Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria_Producto entidad)
        {
            try
            {
                context.Categoria_Producto.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Categoria_Producto_Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria_Producto entidad)
        {
            if (id != entidad.Categoria_Producto_Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var categoria = await context.Categoria_Producto
                .FirstOrDefaultAsync(e => e.Categoria_Producto_Id == id);

            if (categoria == null)
            {
                return NotFound("No se encontró la categoría");
            }

            // Asignación de propiedades
            categoria.Nombre_Categoria = entidad.Nombre_Categoria;

            try
            {
                context.Categoria_Producto.Update(categoria);
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
            var existe = await context.Categoria_Producto
                .AnyAsync(x => x.Categoria_Producto_Id == id);

            if (!existe)
            {
                return NotFound($"La categoría con ID {id} no existe.");
            }

            var categoriaABorrar = new Categoria_Producto { Categoria_Producto_Id = id };

            context.Remove(categoriaABorrar);
            await context.SaveChangesAsync();

            return Ok($"La categoría {id} fue eliminada correctamente.");
        }
        #endregion
    }
}
