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

        public RolControllers(Context context)
        {
            this.context = context;
        }

       
    }
}
