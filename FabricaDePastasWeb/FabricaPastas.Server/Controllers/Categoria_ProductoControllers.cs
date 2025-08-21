using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Categoria_Producto")]
    public class Categoria_ProductoControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Categoria_ProductoControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Categoria_Producto>>> Get()
        {
            return await context.Categoria_Producto.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCategoria_ProductoDTO entidadDTO)
        {
            try
            {
                //Categoria_Producto entidad = new Categoria_Producto();

                //entidad.Nombre_Categoria = entidadDTO.Nombre_Categoria;
                //context.Categoria_Producto.Add(entidad);

                Categoria_Producto entidad = mapper.Map<Categoria_Producto>(entidadDTO);



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
        public async Task<ActionResult> Put(int id, [FromBody] Categoria_Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Categoria_Producto.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Nombre_Categoria = entidad.Nombre_Categoria;
            

            try
            {
                context.Categoria_Producto.Update(dammy);
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
            var existe = await context.Categoria_Producto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La categoria {id} no existe.");
            }

            Categoria_Producto EntidadAborrar = new Categoria_Producto();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"La categoría {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
