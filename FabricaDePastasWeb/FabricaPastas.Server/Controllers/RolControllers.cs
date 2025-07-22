using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

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
