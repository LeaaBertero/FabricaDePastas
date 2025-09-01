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
    [Route("api/Detalle_Lista_Precio")]
    public class Detalle_Lista_PrecioControllers : ControllerBase
    {
        private readonly IDetalle_Lista_PrecioRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

         #region constructor
        public Detalle_Lista_PrecioControllers(IDetalle_Lista_PrecioRepositorio repositorio, 
                                               IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Detalle_Lista_Precio>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion


        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearDetalle_Lista_PrecioDTO entidadDTO)
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

                Detalle_Lista_Precio entidad = mapper.Map<Detalle_Lista_Precio>(entidadDTO);


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
        public async Task<ActionResult> Put(int id, [FromBody] Detalle_Lista_Precio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el detalle de la lista de precio buscado");
            }

            dammy.Precio_Personalizado = entidad.Precio_Personalizado;
            

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
                return NotFound($"El detalle de la lista {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("El detalle no se pudo eliminar");
            }
        }
        #endregion

    }
}




