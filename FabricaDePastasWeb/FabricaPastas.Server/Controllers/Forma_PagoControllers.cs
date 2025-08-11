using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Forma_Pago")]
    public class Forma_PagoControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public Forma_PagoControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Forma_Pago>>> Get()
        {
            return await context.Forma_Pago.ToListAsync();
        }
        #endregion
    }
}

        
