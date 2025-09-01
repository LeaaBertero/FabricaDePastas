using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Server.Repositorio;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Usuario")]
    public class Promocion_UsuarioControllers : ControllerBase
    {
        private readonly IPromocion_UsuarioRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Promocion_UsuarioControllers(IPromocion_UsuarioRepositorio repositorio, 
                                            IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion_Usuario>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promocion_Usuario>> Get(int id)
        {
            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPromocion_UsuarioDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.Email = entidadDTO.Email;
                //entidad.Contraseña = entidadDTO.Contraseña;
                //entidad.Teléfono = entidadDTO.Teléfono;
                //entidad.Dirección = entidadDTO.Dirección;
                //entidad.Cuit_Cuil = entidadDTO.Cuit_Cuil;
                //entidad.Fecha_Registro = entidadDTO.Fecha_Registro;

                Promocion_Usuario entidad = mapper.Map<Promocion_Usuario>(entidadDTO);


                return await repositorio.Insert(entidad);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Promocion_Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el registro buscado");
            }

            dammy.Fecha_Inicio_Promo = entidad.Fecha_Inicio_Promo;
            dammy.Fecha_Fin_Promo = entidad.Fecha_Fin_Promo;
            
            //dammy.Fecha_Registro = entidad.Fecha_Registro;

            try
            {
                await repositorio.Update(id, dammy);


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
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La promocion del usuario {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo eliminar la promoción");
            }
        }
        #endregion
    }
}
