using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]

    public class UsuarioControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public UsuarioControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuario.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var dammy = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario entidad)
        {
            try
            {
                context.Usuario.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Usuario.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Apellido = entidad.Apellido;
            dammy.Email = entidad.Email;
            dammy.Contraseña = entidad.Contraseña;
            dammy.Teléfono = entidad.Teléfono;
            dammy.Dirección = entidad.Dirección;
            dammy.Cuit_Cuil = entidad.Cuit_Cuil;
            dammy.Fecha_Registro = entidad.Fecha_Registro;

            try
            {
                context.Usuario.Update(dammy);
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
            var existe = await context.Usuario.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El usuario {id} no existe.");
            }

            Usuario EntidadAborrar = new Usuario();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El usuario {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
