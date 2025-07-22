using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
