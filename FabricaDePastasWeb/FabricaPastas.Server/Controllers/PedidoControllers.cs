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
    [Route("api/Pedido")]
    public class PedidoControllers : ControllerBase
    {
        private readonly IPedidoRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public PedidoControllers(IPedidoRepositorio repositorio, 
                                 IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> Get(int id)
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
        public async Task<ActionResult<int>> Post(CrearPedidoDTO entidadDTO)
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

                Pedido entidad = mapper.Map<Pedido>(entidadDTO);


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
        public async Task<ActionResult> Put(int id, [FromBody] Pedido entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            // Obtenemos el pedido existente
            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el pedido buscado");
            }

            // Actualizamos todas las propiedades que queremos permitir modificar
            dammy.Fecha_Pedido = entidad.Fecha_Pedido;
            dammy.Fecha_Entrega = entidad.Fecha_Entrega;
            dammy.Total = entidad.Total;
            dammy.Observaciones_Catering = entidad.Observaciones_Catering;

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


        //#region Método Put
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(int id, [FromBody] Pedido entidad)
        //{
        //    if (id != entidad.Id)
        //    {
        //        return BadRequest("Datos incorrectos");
        //    }

        //    var dammy = await repositorio.SelectById(id);

        //    if (dammy == null)
        //    {
        //        return NotFound("No se encontró el pedido buscado");
        //    }

        //    dammy.Fecha_Pedido = entidad.Fecha_Pedido;
        //    dammy.Fecha_Entrega = entidad.Fecha_Entrega;
        //    dammy.Total = entidad.Total;

        //    //dammy.Fecha_Registro = entidad.Fecha_Registro;

        //    try
        //    {
        //        await repositorio.Update(id, dammy);


        //        return Ok();

        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest(e.Message);
        //    }
        //}
        //#endregion
    }
}
