using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Lista_Precio")]
    public class Detalle_Lista_PrecioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Detalle_Lista_PrecioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Detalle_Lista_Precio>>> Get()
        {
            return await context.Detalle_Lista_Precio.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearDetalle_Lista_PrecioDTO entidadDTO)
        {
            try
            {
                //Detalle_Lista_Precio entidad = new Detalle_Lista_Precio();

                //entidad.Precio_Personalizado = entidadDTO.Precio_Personalizado;

                Detalle_Lista_Precio entidad = mapper.Map<Detalle_Lista_Precio>(entidadDTO);



                context.Detalle_Lista_Precio.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Detalle_Lista_Precio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Detalle_Lista_Precio.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el detalle de la lista de precio");
            }

            dammy.Precio_Personalizado = entidad.Precio_Personalizado;
          

            try
            {
                context.Detalle_Lista_Precio.Update(dammy);
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
            var existe = await context.Detalle_Lista_Precio.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El detalle de la lista de precio {id} no existe.");
            }

            Detalle_Lista_Precio EntidadAborrar = new Detalle_Lista_Precio();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El detalle de la lista de precio {id} fue eliminado correctamente.");
        }
        #endregion
    }
}


