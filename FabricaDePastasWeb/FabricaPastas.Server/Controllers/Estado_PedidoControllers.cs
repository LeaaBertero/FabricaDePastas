using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Estado_Pedido")]
    public class Estado_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public Estado_PedidoControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Estado_Pedido>>> Get()
        {
            return await context.Estado_Pedido.ToListAsync();
        }
        #endregion
    }
}

        
