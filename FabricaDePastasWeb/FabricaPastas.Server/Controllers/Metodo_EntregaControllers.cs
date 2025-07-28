using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Metodo_Entrega")]
    public class Metodo_EntregaControllers : ControllerBase
    {
        private readonly Context context;

        public Metodo_EntregaControllers(Context context)
        {
            this.context = context;
        }


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Metodo_Entrega>>> Get()
        {
            return await context.Metodo_entrega.ToListAsync();
        }
        #endregion

        
    }
}
