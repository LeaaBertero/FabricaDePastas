using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Usuario")]
    public class Promocion_UsuarioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Promocion_UsuarioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion_Usuario>>> Get()
        {
            return await context.Promocion_Usuario.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPromocion_UsuarioDTO entidadDTO)
        {
            try
            {
                //Promocion_Usuario entidad = new Promocion_Usuario();

                //entidad.Fecha_Inicio_Promo = entidadDTO.Fecha_Inicio_Promo;
                //entidad.Fecha_Fin_Promo = entidadDTO.Fecha_Fin_Promo;

                Promocion_Usuario entidad = mapper.Map<Promocion_Usuario>(entidadDTO);

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

        //hacer un método PUT para actualizar las promociones
        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Promocion_Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Promocion_Usuario.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Fecha_Inicio_Promo = entidad.Fecha_Inicio_Promo;
            dammy.Fecha_Fin_Promo = entidad.Fecha_Fin_Promo;
           

            try
            {
                context.Promocion_Usuario.Update(dammy);
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
