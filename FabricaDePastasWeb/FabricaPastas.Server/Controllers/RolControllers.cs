using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Rol")]
    public class RolControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public RolControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            return await context.Rol.ToListAsync();
        }
        #endregion

    }
}
