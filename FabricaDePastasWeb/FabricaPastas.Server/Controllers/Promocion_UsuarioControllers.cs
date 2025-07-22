using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Usuario")]

    public class Promocion_UsuarioControllers : ControllerBase
    {
        private readonly Context context;

        public Promocion_UsuarioControllers(Context context)
        {
            this.context = context;
        }
    }
}
