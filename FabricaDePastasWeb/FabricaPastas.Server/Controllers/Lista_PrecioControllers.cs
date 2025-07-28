using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Lista_Precio")]
    public class Lista_PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public Lista_PrecioControllers(Context context)
        {
            this.context = context;
        }


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Lista_Precio>>> Get()
        {
            return await context.Lista_Precio.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Lista_Precio>> Get(int id)
        {
            var dammy = await context.Lista_Precio.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Lista_Precio entidad)
        {
            try
            {
                context.Lista_Precio.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Lista_Precio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Lista_Precio.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró la lista de precio");
            }

            dammy.Fecha_Desde = entidad.Fecha_Desde;
            dammy.Fecha_Hasta = entidad.Fecha_Hasta;
          

            try
            {
                context.Lista_Precio.Update(dammy);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        
    }
}
