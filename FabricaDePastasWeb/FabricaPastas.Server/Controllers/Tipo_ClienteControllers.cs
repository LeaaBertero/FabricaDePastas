using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Tipo_Cliente")]
    public class Tipo_ClienteControllers : ControllerBase
    {
        private readonly Context context;

        public Tipo_ClienteControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Tipo_Cliente>>> Get()
        {
            return await context.Tipo_Cliente.ToListAsync();
        }
        #endregion

    }
}

       

       

        

        

       

        
