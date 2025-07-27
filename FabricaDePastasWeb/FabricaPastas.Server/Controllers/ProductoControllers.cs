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

        public ProductoControllers(Context context)
        {
            this.context = context;
        }

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
            var producto = await context.Producto
                .FirstOrDefaultAsync(x => x.Producto_Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
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
                return entidad.Producto_Id;
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
            if (id != entidad.Producto_Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var producto = await context.Producto
                .FirstOrDefaultAsync(e => e.Producto_Id == id);

            if (producto == null)
            {
                return NotFound("No se encontró el producto");
            }

            // Asignación de propiedades
            producto.Nombre = entidad.Nombre;
            producto.Descripcion = entidad.Descripcion;
            producto.PrecioBase = entidad.PrecioBase;
            producto.Imagen_Url = entidad.Imagen_Url;
            producto.Stock = entidad.Stock;
            producto.Categoria_Producto_Id = entidad.Categoria_Producto_Id;

            try
            {
                context.Producto.Update(producto);
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
            var existe = await context.Producto
                .AnyAsync(x => x.Producto_Id == id);

            if (!existe)
            {
                return NotFound($"El producto con ID {id} no existe.");
            }

            var productoABorrar = new Producto { Producto_Id = id };

            context.Remove(productoABorrar);
            await context.SaveChangesAsync();

            return Ok($"El producto {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
