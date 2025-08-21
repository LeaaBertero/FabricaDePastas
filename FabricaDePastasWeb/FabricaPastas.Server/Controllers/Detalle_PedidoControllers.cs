using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Pedido")]
    public class Detalle_PedidoControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public Detalle_PedidoControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Detalle_Pedido>>> Get()
        {
            return await context.Detalle_Pedido.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearDetalle_PedidoDTO entidadDTO)
        {
            try
            {
                //Detalle_Pedido entidad = new Detalle_Pedido();

                //entidad.Cantidad = entidadDTO.Cantidad;
                //entidad.Precio_Unitario = entidadDTO.Precio_Unitario;

                Detalle_Pedido entidad = mapper.Map<Detalle_Pedido>(entidadDTO);

                context.Detalle_Pedido.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}

        

       
