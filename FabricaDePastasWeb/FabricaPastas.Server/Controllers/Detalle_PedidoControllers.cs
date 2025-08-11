using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Pedido")]
    public class Detalle_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public Detalle_PedidoControllers(Context context)
        {
            this.context = context;
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
        public async Task<ActionResult<int>> Post(Detalle_Pedido entidad)
        {
            try
            {
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

        

       
